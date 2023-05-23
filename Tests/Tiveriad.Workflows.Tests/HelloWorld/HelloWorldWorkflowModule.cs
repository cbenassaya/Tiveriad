#region

using Tiveriad.UnitTests;
using Tiveriad.Workflows.Core.Services;
using Xunit;

#endregion

namespace Tiveriad.Workflows.Tests.HelloWorld;

public class HelloWorldWorkflowModule : TestBase<HelloWorldWorkflowStartup>
{
    [Fact]
    public void Test()
    {
        var host = GetRequiredService<IWorkflowHost>();
        host.RegisterWorkflow<HelloWorldWorkflow>();
        host.Start();
        host.StartWorkflow("HelloWorld");
        host.Stop();
    }
}