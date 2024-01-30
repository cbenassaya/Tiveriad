
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StartupBase = Tiveriad.UnitTests.StartupBase;

namespace Tiveriad.Integration.Tests;

public class Startup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services.AddSingleton<WebApplicationFactory<Program>>();
        services.AddSingleton<HttpClient>(sp => sp.GetRequiredService<WebApplicationFactory<Program>>().CreateClient());
    }
}



