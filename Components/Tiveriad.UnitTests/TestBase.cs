#region

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Tiveriad.UnitTests;

public abstract class TestBase<TCYCLEOFLIFEMANAGER> : IDisposable where TCYCLEOFLIFEMANAGER : IStartup
{
    private readonly TCYCLEOFLIFEMANAGER _cycleOfLifeManager;
    private readonly IServiceProvider _serviceProvider;

    protected TestBase()
    {
        var services = GetServiceCollection();
        _cycleOfLifeManager = Activator.CreateInstance<TCYCLEOFLIFEMANAGER>();
        _cycleOfLifeManager.Configure(services);
        _serviceProvider = services.BuildServiceProvider();
        _cycleOfLifeManager.Init(_serviceProvider);
    }

    public void Dispose()
    {
        _cycleOfLifeManager.Clean(_serviceProvider);
    }


    protected virtual ServiceCollection GetServiceCollection()
    {
        return new ServiceCollection();
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