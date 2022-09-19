using Microsoft.Extensions.DependencyInjection;
using Tiveriad.Pipelines.Tests.Models;
using Tiveriad.UnitTests;

namespace Tiveriad.Pipelines.Tests;

public class Startup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services
            .AddScoped<IMiddlewareResolver,
                ActivatorMiddlewareResolver>();
        services
            .AddScoped<IPipelineBuilder<Model, Context, Configuration>,
                DefaultPipelineBuilder<Model, Context, Configuration>>();
    }
}