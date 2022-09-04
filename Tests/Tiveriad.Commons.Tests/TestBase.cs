using Microsoft.Extensions.DependencyInjection;

namespace Tiveriad.Commons.Tests;

public abstract class TestBase<TStartup> where TStartup:IStartup
{
    private IServiceProvider _serviceProvider;

    protected virtual T? GetService<T>()
    {
        return _serviceProvider.GetService<T>();
    }

    protected virtual T GetRequiredService<T>() where T : notnull
    {
        return _serviceProvider.GetRequiredService<T>();
    }

    protected TestBase()
    {
        var services = new ServiceCollection();
        var startup = Activator.CreateInstance<TStartup>();
        startup.Configure(services);
        _serviceProvider = services.BuildServiceProvider();
        startup.Init(_serviceProvider);
    }
    

}