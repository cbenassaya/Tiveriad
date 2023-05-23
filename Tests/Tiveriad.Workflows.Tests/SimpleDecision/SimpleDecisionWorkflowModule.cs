#region

using Tiveriad.UnitTests;
using Tiveriad.Workflows.Core.Services;
using Xunit;

#endregion

namespace Tiveriad.Workflows.Tests.SimpleDecision;

public class SimpleDecisionWorkflowModule : TestBase<SimpleDecisionWorkflowStartup>
{
    [Fact]
    public void Test()
    {
        var host = GetRequiredService<IWorkflowHost>();
        host.RegisterWorkflow<SimpleDecisionWorkflow>();
        host.Start();
        host.StartWorkflow("Simple Decision Workflow");
        host.Stop();
    }
}