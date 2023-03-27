#region

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ObjectPool;

#endregion

namespace Tiveriad.Workflows.Services;

public class InjectedObjectPoolPolicy<T> : IPooledObjectPolicy<T>
{
    private readonly IServiceProvider _provider;

    public InjectedObjectPoolPolicy(IServiceProvider provider)
    {
        _provider = provider;
    }

    public T Create()
    {
        return _provider.GetService<T>();
    }

    public bool Return(T obj)
    {
        return true;
    }
}