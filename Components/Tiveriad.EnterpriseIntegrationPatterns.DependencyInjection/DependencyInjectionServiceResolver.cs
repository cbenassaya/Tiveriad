#region

using Microsoft.Extensions.DependencyInjection;
using Tiveriad.ServiceResolvers;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;

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
}