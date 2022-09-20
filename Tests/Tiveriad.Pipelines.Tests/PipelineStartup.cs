using Microsoft.Extensions.DependencyInjection;
using Tiveriad.Pipelines.Tests.Models;
using Tiveriad.UnitTests;

namespace Tiveriad.Pipelines.Tests;

public class PipelineStartup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services
            .AddScoped<IServiceResolver,
                ActivatorServiceResolver>();
        services
            .AddScoped<IPipelineBuilder<Model, Context, Configuration>,
                DefaultPipelineBuilder<Model, Context, Configuration>>();
    }
}


public class SenderStartup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services
            .AddScoped<IServiceResolver,
                ActivatorServiceResolver>();
        services
            .AddSingleton<ISender,Sender>();
    }
}