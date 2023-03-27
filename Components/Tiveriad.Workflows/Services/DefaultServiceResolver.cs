#region

using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services;

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