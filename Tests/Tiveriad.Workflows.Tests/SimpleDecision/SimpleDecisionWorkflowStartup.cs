#region

using Microsoft.Extensions.DependencyInjection;
using Tiveriad.UnitTests;
using Tiveriad.Workflows.Core.Services;
using Tiveriad.Workflows.DependencyInjection;

#endregion

namespace Tiveriad.Workflows.Tests.SimpleDecision;

public class SimpleDecisionWorkflowStartup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services.AddLogging(config => { });
        services.AddSingleton<IServiceResolver, DependencyInjectionServiceResolver>();
        services.AddWorkflow();
    }
}