# MahhalaMapper

[![CI](https://github.com/MahhalaMapper/MahhalaMapper/workflows/CI/badge.svg)](https://github.com/MahhalaMapper/MahhalaMapper/actions?query=workflow%3ACI)
[![NuGet](http://img.shields.io/nuget/vpre/MahhalaMapper.svg?label=NuGet)](https://www.nuget.org/packages/MahhalaMapper/)

> MahhalaMapper is a fork of [AutoMapper](https://github.com/AutoMapper/AutoMapper), the original convention-based object-object mapper for .NET, created and maintained by [Jimmy Bogard](https://jimmybogard.com) and its contributors. This fork continues development under a new name starting at v1.0.0.

### What is MahhalaMapper?

MahhalaMapper is a Fork of AutoMapper, a simple little library built to solve a deceptively complex problem - getting rid of code that mapped one object to another. This type of code is rather dreary and boring to write, so why not invent a tool to do it for us?
The statement above used to be true, but mappers add overhead and complexity to your codebase, and with modern AI tooling mappers are not as necessary. MahhalaMapper was Forked from AutoMapper to be a drop-in replacement for AutoMapper, only to ensure that existing projects that used Automapper can easily be upgraded with new .NET Framework versions, without having to change their codebase. MahhalaMapper is not intended to be used in new projects, and we recommend that you do not use it in new projects.

### How do I get started?

First, configure MahhalaMapper to know what types you want to map, in the startup of your application:

```csharp
var configuration = new MapperConfiguration(cfg => 
{
    cfg.CreateMap<Foo, FooDto>();
    cfg.CreateMap<Bar, BarDto>();
});
// only during development, validate your mappings; remove it before release
#if DEBUG
configuration.AssertConfigurationIsValid();
#endif
// use DI or create the mapper yourself
var mapper = configuration.CreateMapper();
```
Then in your application code, execute the mappings:

```csharp
var fooDto = mapper.Map<FooDto>(foo);
var barDto = mapper.Map<BarDto>(bar);
```

Since MahhalaMapper is a fork of AutoMapper with the same API, the [AutoMapper documentation](https://docs.automapper.io/en/stable/) and [Stack Overflow](https://stackoverflow.com/questions/tagged/automapper) remain useful references for most day-to-day usage questions.

### Migrating from AutoMapper?

MahhalaMapper is a full replacement for [AutoMapper v14.0.0](https://www.nuget.org/packages/AutoMapper/14.0.0).  If you are on an older version of AutoMapper, you may need to upgrade to v14.0.0 first before migrating to MahhalaMapper. And follow any of the AutoMapper migration guides. Then install [MahhalaMapper](https://www.nuget.org/packages/MahhalaMapper/) and do a find-and-replace on AutoMapper to MahhalaMapper in your existing code.

### Where can I get it?

First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [MahhalaMapper](https://www.nuget.org/packages/MahhalaMapper/) from the package manager console:

```
PM> Install-Package MahhalaMapper
```
Or from the .NET CLI as:
```
dotnet add package MahhalaMapper
```

### Do you have an issue?

If you're running into problems, file an issue above.

### License, etc.

This project has adopted the code of conduct defined by the Contributor Covenant to clarify expected behavior in our community.
For more information see the [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct).

MahhalaMapper is a fork of AutoMapper. AutoMapper is Copyright &copy; 2009 [Jimmy Bogard](https://jimmybogard.com) and other contributors under the [MIT license](https://github.com/AutoMapper/AutoMapper?tab=MIT-1-ov-file#MIT-1-ov-file). MahhalaMapper is likewise made available under the [MIT license](LICENSE.txt).
