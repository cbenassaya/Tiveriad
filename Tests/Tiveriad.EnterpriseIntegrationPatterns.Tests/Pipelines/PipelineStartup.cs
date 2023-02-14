using Microsoft.Extensions.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.Pipelines;
using Tiveriad.EnterpriseIntegrationPatterns.ServiceResolvers;
using Tiveriad.EnterpriseIntegrationPatterns.Tests.Models;
using Tiveriad.UnitTests;

namespace Tiveriad.EnterpriseIntegrationPatterns.Tests.Pipelines;

public class PipelineStartup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services
            .AddScoped<IServiceResolver,
                DefaultServiceResolver>();
        services
            .AddScoped<IPipelineBuilder<Model, Context, Configuration>,
                DefaultPipelineBuilder<Model, Context, Configuration>>();
    }
}