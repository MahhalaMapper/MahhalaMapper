using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace MahhalaMapper.Extensions.Microsoft.DependencyInjection.Tests
{
	public class ServiceLifetimeTests
	{
		//Implicitly Transient
		[Fact]
		public void AddMahhalaMapperExtensionDefaultWithAssemblySingleDelegateArgCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper(cfg => { }, new List<Assembly>());
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Transient);
		}

		[Fact]
		public void AddMahhalaMapperExtensionDefaultWithAssemblyDoubleDelegateArgCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper((sp, cfg) => { }, new List<Assembly>());
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Transient);
		}

		[Fact]
		public void AddMahhalaMapperExtensionDefaultWithAssemblyCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper(new List<Assembly>());
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Transient);
		}

		[Fact]
		public void AddMahhalaMapperExtensionDefaultSingleDelegateWithProfileTypeCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper(cfg => { },new[] {typeof(ServiceLifetimeTests)});
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Transient);
		}

		[Fact]
		public void AddMahhalaMapperExtensionDefaultDoubleDelegateWithProfileTypeCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper((sp, cfg) => { },new[] {typeof(ServiceLifetimeTests)});
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Transient);
		}

		//Explicitly Singleton
		[Fact]
		public void AddMahhalaMapperExtensionSingletonWithAssemblySingleDelegateArgCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper(cfg => { }, new List<Assembly>(), ServiceLifetime.Singleton);
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Singleton);
		}

		[Fact]
		public void AddMahhalaMapperExtensionSingletonWithAssemblyDoubleDelegateArgCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper((sp, cfg) => { }, new List<Assembly>(), ServiceLifetime.Singleton);
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Singleton);
		}

		[Fact]
		public void AddMahhalaMapperExtensionSingletonWithAssemblyCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper(new List<Assembly>(), ServiceLifetime.Singleton);
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Singleton);
		}

		[Fact]
		public void AddMahhalaMapperExtensionSingletonSingleDelegateWithProfileTypeCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper(cfg => { },new[] {typeof(ServiceLifetimeTests)}, ServiceLifetime.Singleton);
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Singleton);
		}

		[Fact]
		public void AddMahhalaMapperExtensionSingletonDoubleDelegateWithProfileTypeCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper((sp, cfg) => { },new[] {typeof(ServiceLifetimeTests)}, ServiceLifetime.Singleton);
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Singleton);
		}

		//Explicitly Transient
		[Fact]
		public void AddMahhalaMapperExtensionTransientWithAssemblySingleDelegateArgCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper(cfg => { }, new List<Assembly>(), ServiceLifetime.Transient);
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Transient);
		}

		[Fact]
		public void AddMahhalaMapperExtensionTransientWithAssemblyDoubleDelegateArgCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper((sp, cfg) => { }, new List<Assembly>(), ServiceLifetime.Transient);
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Transient);
		}

		[Fact]
		public void AddMahhalaMapperExtensionTransientWithAssemblyCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper(new List<Assembly>(), ServiceLifetime.Transient);
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Transient);
		}

		[Fact]
		public void AddMahhalaMapperExtensionTransientSingleDelegateWithProfileTypeCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper(cfg => { },new[] {typeof(ServiceLifetimeTests)}, ServiceLifetime.Transient);
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Transient);
		}

		[Fact]
		public void AddMahhalaMapperExtensionTransientDoubleDelegateWithProfileTypeCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper((sp, cfg) => { },new[] {typeof(ServiceLifetimeTests)}, ServiceLifetime.Transient);
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Transient);
		}

		//Explicitly Scoped
		[Fact]
		public void AddMahhalaMapperExtensionScopedWithAssemblySingleDelegateArgCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper(cfg => { }, new List<Assembly>(), ServiceLifetime.Scoped);
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Scoped);
		}

		[Fact]
		public void AddMahhalaMapperExtensionScopedWithAssemblyDoubleDelegateArgCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper((sp, cfg) => { }, new List<Assembly>(), ServiceLifetime.Scoped);
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Scoped);
		}

		[Fact]
		public void AddMahhalaMapperExtensionScopedWithAssemblyCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper(new List<Assembly>(), ServiceLifetime.Scoped);
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Scoped);
		}

		[Fact]
		public void AddMahhalaMapperExtensionScopedSingleDelegateWithProfileTypeCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper(cfg => { },new[] {typeof(ServiceLifetimeTests)}, ServiceLifetime.Scoped);
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Scoped);
		}

		[Fact]
		public void AddMahhalaMapperExtensionScopedDoubleDelegateWithProfileTypeCollection()
		{
			//arrange
			var serviceCollection = new ServiceCollection();

			//act
			serviceCollection.AddMahhalaMapper((sp, cfg) => { },new[] {typeof(ServiceLifetimeTests)}, ServiceLifetime.Scoped);
			var serviceDescriptor = serviceCollection.FirstOrDefault(sd => sd.ServiceType == typeof(IMapper));

			//assert
			serviceDescriptor.ShouldNotBeNull();
			serviceDescriptor.Lifetime.ShouldBe(ServiceLifetime.Scoped);
		}

	}
}