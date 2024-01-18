#region

using Microsoft.Extensions.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;
using Tiveriad.ServiceResolvers;
using Tiveriad.ServiceResolvers.Microsoft.DependencyInjection;
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