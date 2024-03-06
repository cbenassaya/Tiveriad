using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using ReferenceData.Integration;
using StartupBase = Tiveriad.UnitTests.StartupBase;

namespace Tiveriad.ReferenceData.Tests;

public class Startup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services.AddSingleton<WebApplicationFactory<Program>>();
        services.AddSingleton<HttpClient>(sp => sp.GetRequiredService<WebApplicationFactory<Program>>().CreateClient());
    }
}



