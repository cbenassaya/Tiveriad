#region

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Tiveriad.UnitTests;

public interface IStartup
{
    public void Configure(IServiceCollection services);

    public void Init(IServiceProvider serviceProvider);

    public void Clean(IServiceProvider serviceProvider);
}