using Tiveriad.Core.Abstractions.Services;

namespace Tiveriad.Repositories.Microsoft.DependencyInjection;

public class OptionalService<TService> : IOptionalService<TService> where TService : class
{
    private readonly Func<TService?> _serviceGetDelegate;

    public OptionalService(IServiceProvider serviceProvider)
    {
        _serviceGetDelegate = () => serviceProvider.GetService(typeof(TService)) as TService;
    }

    public bool HasService => _serviceGetDelegate() != null;


    public TService? GetService() =>  _serviceGetDelegate();
}
    