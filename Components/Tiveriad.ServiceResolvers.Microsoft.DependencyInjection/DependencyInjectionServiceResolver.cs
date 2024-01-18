

using Microsoft.Extensions.DependencyInjection;

namespace Tiveriad.ServiceResolvers.Microsoft.DependencyInjection;

public class DependencyInjectionServiceResolver : IServiceResolver
{
    private readonly IServiceProvider _serviceProvider;

    public DependencyInjectionServiceResolver(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public object GetService(Type type)
    {
        return _serviceProvider.GetRequiredService(type);
    }

    public IEnumerable<object?> GetServices(Type type)
    {
        return _serviceProvider.GetServices(type);
    }
    
    public T GetService<T>()
    {
        return _serviceProvider.GetService<T>();
    }
}