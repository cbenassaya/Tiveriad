using Microsoft.Extensions.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.ServiceResolvers;
using Tiveriad.UnitTests;

namespace Tiveriad.EnterpriseIntegrationPatterns.Tests.Mediators;

public class SenderStartup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services
            .AddScoped<IServiceResolver,
                DependencyInjectionServiceResolver>();
        services.AddTiveriadEip(GetType().Assembly);
    }
}