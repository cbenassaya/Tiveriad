using Microsoft.Extensions.DependencyInjection;

namespace Tiveriad.Commons.Tests;

public interface IStartup
{
    public void Configure(IServiceCollection services);

    public void Init(IServiceProvider serviceProvider);

    public void Clean(IServiceProvider serviceProvider);
}