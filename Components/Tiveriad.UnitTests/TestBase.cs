using Microsoft.Extensions.DependencyInjection;

namespace Tiveriad.UnitTests;

public abstract class TestBase<TStartup> where TStartup : IStartup
{
    private readonly IServiceProvider _serviceProvider;

    protected TestBase()
    {
        var services = new ServiceCollection();
        var startup = Activator.CreateInstance<TStartup>();
        startup.Configure(services);
        _serviceProvider = services.BuildServiceProvider();
        startup.Init(_serviceProvider);
    }

    protected virtual T? GetService<T>()
    {
        return _serviceProvider.GetService<T>();
    }

    protected virtual T GetRequiredService<T>() where T : notnull
    {
        return _serviceProvider.GetRequiredService<T>();
    }
}