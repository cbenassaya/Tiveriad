#region

using Microsoft.Extensions.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.ServiceResolvers;
using Tiveriad.UnitTests;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.Tests.EventBrokers;

public class EventBrokerStartup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services
            .AddScoped<IServiceResolver,
                DependencyInjectionServiceResolver>();

        services.AddTiveriadEip(GetType().Assembly);
    }
}