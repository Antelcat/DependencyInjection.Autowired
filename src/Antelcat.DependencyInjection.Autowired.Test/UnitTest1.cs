using Antelcat.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Antelcat.DependencyInjection.Autowired.Test;

public class Tests
{
    private IServiceCollection Collection = new ServiceCollection();
    [SetUp]
    public void Setup()
    {
        var provider = Collection.BuildAutowiredServiceProvider(static x=>x.BuildServiceProvider());
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}