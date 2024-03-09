using Identities.Integration;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using StartupBase = Tiveriad.UnitTests.StartupBase;

namespace Tiveriad.Identities.Tests;

public class Startup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services.AddSingleton<WebApplicationFactory<Program>>();
        services.AddSingleton<HttpClient>(sp => sp.GetRequiredService<WebApplicationFactory<Program>>().CreateClient());
    }
}



