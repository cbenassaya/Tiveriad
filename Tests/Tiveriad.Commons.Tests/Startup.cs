#region

using Microsoft.Extensions.DependencyInjection;
using Tiveriad.UnitTests;

#endregion

namespace Tiveriad.Commons.Tests;

public class Startup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services.AddScoped<ZeroService>();
    }
}