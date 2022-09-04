using Microsoft.Extensions.DependencyInjection;

namespace Tiveriad.Commons.Tests;

public class Startup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services.AddScoped<ZeroService>();
    }
}