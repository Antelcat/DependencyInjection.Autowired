# Antelcat.DependencyInjection.Autowired

Extensions of native [.NET dependency injection](https://github.com/dotnet/docs/blob/main/docs/core/extensions/dependency-injection.md) with [Autowired](./extern/Antelcat.Shared/Antelcat.Shared/Antelcat.Shared.DependencyInjection.Autowired/Attributes/AutowiredAttribute.cs), provides a way to support properties and fields injection.

All lifetimes and generics are now supported. And using [IL delegates](./extern/Antelcat.Shared/Antelcat.Shared/Antelcat.Shared.IL/) to speed up the setter.

``` c#
public class Service{
    [Autowired]
    private readonly IService dependency;
    [Autowired]
    private IService Dependency { get; set; }
} 
```

In common use :

``` c#
IServiceProvider provider = new ServiceCollection()
                            .Add(...)
                            .BuildAutowiredServiceProvider(static x=>x.BuildServiceProvider());
IService service = provider.GetService<IService>();
```

In [ASP.NET Core](https://github.com/dotnet/aspnetcore) :

```c#
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers() //register controllers
                .AddControllersAsServices() // add controllers as services
                .UseAutowiredControllers(); // use auto wired controllers
builder.Host.UseAutowiredServiceProviderFactory(); // autowired services
```

Tests could be found in [ServiceTest.cs](./Antelcat.DependencyInjection.Autowired/Antelcat.DependencyInjection.Autowired.Test/ServiceTest.cs) , which shows higher performance than Autofac and is close to native.

