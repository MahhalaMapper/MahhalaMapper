# AutoMapper Compatibility

If you're migrating an existing project from AutoMapper to MahhalaMapper, the `MahhalaMapper.AutoMapper.Compatibility`
package lets you do it without touching your mapping code. It exposes MahhalaMapper's public types under the
`AutoMapper` namespace, so code written as:

```c#
using AutoMapper;

public class OrderProfile : Profile
{
    public OrderProfile() => CreateMap<Order, OrderDto>();
}

var configuration = new MapperConfiguration(cfg => cfg.AddProfile<OrderProfile>());
var mapper = configuration.CreateMapper();
var dto = mapper.Map<OrderDto>(order);
```

keeps compiling and running exactly as before, with MahhalaMapper doing the actual mapping underneath.

## Installing

```
dotnet add package MahhalaMapper.AutoMapper.Compatibility
```

This pulls in `MahhalaMapper` as a dependency. You do not reference `MahhalaMapper` directly unless you also want
to use its APIs going forward.

## How it works

.NET does not let one namespace transparently re-export another, so the shim provides real, independent types
under `AutoMapper` that either:

* **Subclass** the equivalent MahhalaMapper type directly, when it isn't sealed. `AutoMapper.Profile` is a plain
  subclass of `MahhalaMapper.Profile` — a custom profile written against `AutoMapper.Profile` *is* a
  `MahhalaMapper.Profile`, so it's picked up by `AddProfile`, `AddMaps`, and assembly scanning with no extra work.
  `AutoMapper.AutoMapperMappingException`, `AutoMapper.AutoMapperConfigurationException`, and
  `AutoMapper.DuplicateTypeMapConfigurationException` work the same way.
* **Wrap and delegate**, when the MahhalaMapper type is sealed (`Mapper`, `MapperConfiguration`,
  `MapperConfigurationExpression`). `AutoMapper.MapperConfiguration` and `AutoMapper.Mapper` build and hold a real
  MahhalaMapper configuration/mapper internally and forward every call to it. Configuration built through
  `cfg.CreateMap<TSource, TDestination>()` returns MahhalaMapper's own fluent `IMappingExpression<TSource,
  TDestination>`, so the entire `ForMember`/`ForPath`/`ReverseMap`/... fluent API is available unchanged — it's
  never re-wrapped.

`AutoMapperMappingException`, `AutoMapperConfigurationException`, and `DuplicateTypeMapConfigurationException` are
thrown from the shim's `Map` / `AssertConfigurationIsValid` entry points by catching MahhalaMapper's own exceptions
and re-throwing as the AutoMapper-named type (with the original exception preserved as `InnerException`), so
existing `catch (AutoMapperMappingException ex)` blocks keep working.

## What's covered

* `IMapper` / `IMapperBase`, `Mapper`, `MapperConfiguration`, `IConfigurationProvider`
* `Profile`, `IMapperConfigurationExpression`, `IProfileExpression` (including the full fluent `CreateMap` /
  `ForMember` / `ReverseMap` / `Include` / ... configuration surface, via MahhalaMapper's own types)
* `AutoMapperMappingException`, `AutoMapperConfigurationException`, `DuplicateTypeMapConfigurationException`
* `AddAutoMapper` service collection extensions (the most common overloads: assemblies, marker types, and a
  config action, with or without either)
* `AutoMapper.QueryableExtensions.Extensions.ProjectTo`

## Known gaps

A handful of less common AutoMapper surface area isn't included, since it depends on features that MahhalaMapper's
sealed/internal types don't expose a way to hook into from a separate assembly:

* Attribute-based mapping (`[AutoMap]` and friends) — assembly scanning for `AutoMapAttribute` only recognizes
  MahhalaMapper's own attribute type. Use `MahhalaMapper.AutoMapAttribute`, or the fluent `CreateMap` API, instead.
* The `TypeMapConfigErrors[]`-based constructor of `MahhalaMapperConfigurationException` isn't exposed on
  `AutoMapperConfigurationException` (only the `string`-based ones are); the shim still translates configuration
  errors built that way into `AutoMapperConfigurationException` at `AssertConfigurationIsValid()`, you just can't
  construct one directly from `TypeMapConfigErrors[]` yourself.
* `MemberList` is used directly from MahhalaMapper (there's no `AutoMapper.MemberList`); `cfg.CreateMap<A,
  B>(MemberList.Source)` needs `using MahhalaMapper;` for that one enum reference.

If you hit one of these, it's usually just as easy to migrate that specific call site to the equivalent
`MahhalaMapper` API and keep the rest of your code on the compatibility shim.

## Removing the shim

Once you're ready to fully move off AutoMapper-shaped code, replace `using AutoMapper;` with `using MahhalaMapper;`
and drop the `MahhalaMapper.AutoMapper.Compatibility` package reference — the API is otherwise the same.
