#region

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Tiveriad.UnitTests;

public abstract class StartupBase : IStartup
{
    public abstract void Configure(IServiceCollection services);

    public virtual void Init(IServiceProvider serviceProvider)
    {
    }

    public virtual void Clean(IServiceProvider serviceProvider)
    {
    }
}