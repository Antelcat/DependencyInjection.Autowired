using Antelcat.Attributes;

namespace Antelcat.DependencyInjection.Autowired.ServerTest;

public interface ITest
{
    public bool FullFilled();
}

public class TestClass : ITest
{
    [Autowired] private IDependency? Dep;
    public bool FullFilled()
    {
        return Dep is not null ? true : throw new NullReferenceException("Dep not been autowired");
    }
}

public interface IDependency{}

public class Dependency : IDependency{}