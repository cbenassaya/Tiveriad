using Microsoft.Extensions.DependencyInjection;
using Tiveriad.UnitTests;
using Tiveriad.Workflows.Core.Services;
using Tiveriad.Workflows.DependencyInjection;

namespace Tiveriad.Workflows.Tests.HelloWorld;

public class HelloWorldWorkflowStartup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services.AddLogging(config  =>
        {
        });
        services.AddSingleton<IServiceResolver, DependencyInjectionServiceResolver>();
        services.AddWorkflow();
    }
}