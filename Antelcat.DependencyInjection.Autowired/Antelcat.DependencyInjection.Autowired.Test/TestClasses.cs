using Antelcat.Attributes;

namespace Antelcat.DependencyInjection.Autowired.Test;

public abstract class Factory<T> where T : Factory<T>
{
    private static int count = 0;
    protected readonly int Number = ++count;
}

public interface IA { }

public class A : Factory<A>, IA
{
    [Autowired] public IB B { get; set; }
}

public interface IB { }

public class B : Factory<B>, IB
{
    [Autowired] private IA A { get; set; }
}

public interface IC { }

public class C : Factory<C>, IC
{
    [Autowired] private readonly IA A;
    [Autowired] private readonly IB B;
}

public interface ID { }

public class D : Factory<D>, ID
{
    public D(IA a)
    {
        A = a;
    }
    private readonly IA A;
    [Autowired] private readonly IB B;
}

public interface IGeneric<T> { }

public interface IMultiGeneric<T1, T2, T3> { }

public class GenericType<T> : IGeneric<T> { }
public class MultiGenericType<T1,T2,T3> : IMultiGeneric<T1,T2,T3> { }
