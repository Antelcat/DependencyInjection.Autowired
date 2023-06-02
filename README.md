# Antelcat.DependencyInjection.Autowired

Extensions of native [.NET dependency injection](https://github.com/dotnet/docs/blob/main/docs/core/extensions/dependency-injection.md) with [Autowired](https://github.com/Antelcat/Antelcat.Shared/blob/main/Antelcat.Shared/Antelcat.Shared.DependencyInjection.Autowired/Attributes/AutowiredAttribute.cs), provides a way to support properties and fields injection.

All lifetimes and generics are now supported. And using [ILGeneratorEx](https://github.com/Antelcat/ILGeneratorEx) to speed up the setter.

## Usage

``` c#
public class Service{
    [Autowired]
    private readonly IService dependency;
    [Autowired]
    private IService Dependency { get; set; }
}
```

## In common :

``` c#
IServiceProvider provider = new ServiceCollection()
                            .Add(...)
                            .BuildAutowiredServiceProvider(static x=>x.BuildServiceProvider());
IService service = provider.GetService<IService>();
```

## In [ASP.NET CORE MVC](https://github.com/dotnet/aspnetcore) :

```c#
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers() //register controllers
                .AddControllersAsServices() // add controllers as services
                .UseAutowiredControllers(); // use auto wired controllers
builder.Host.UseAutowiredServiceProviderFactory(); // autowired services
```

Tests could be found in [ServiceTest.cs](./src/Antelcat.DependencyInjection.Autowired.Test/ServiceTest.cs) , which shows higher performance than Autofac and is close to native.

## Migration

Meanwhile, you can still use your attribute, only need to provide it at build time :

```c#
IServiceProvider provider = collection.BuildAutowiredServiceProvider<YourAutowiredAttribute>(...);
builder.Services.AddControllers() 
                .AddControllersAsServices()
                .UseAutowiredControllers<YourAutowiredAttribute>(); 
builder.Host.UseAutowiredServiceProviderFactory<YourAutowiredAttribute>();
```
