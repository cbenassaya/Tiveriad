using Microsoft.Extensions.DependencyInjection;

namespace Tiveriad.Pipelines.DependencyInjection;

public class DependencyInjectionServiceResolver : IServiceResolver
{
    private readonly IServiceProvider _serviceProvider;

    public DependencyInjectionServiceResolver(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public object Resolve(Type type)
    {
        return _serviceProvider.GetRequiredService(type);
    }
}