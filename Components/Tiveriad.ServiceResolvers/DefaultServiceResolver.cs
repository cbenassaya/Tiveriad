namespace Tiveriad.ServiceResolvers;

public class DefaultServiceResolver : IServiceResolver
{
    public object GetService(Type type)
    {
        return Activator.CreateInstance(type);
    }

    public IEnumerable<object?> GetServices(Type type)
    {
        return new[] { GetService(type) };
    }

    public T GetService<T>()
    {
        return (T)GetService(typeof(T));
    }
}