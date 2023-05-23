#region

using Tiveriad.UnitTests;
using Tiveriad.Workflows.Core.Services;
using Xunit;

#endregion

namespace Tiveriad.Workflows.Tests.EventTrigger;

public class EventTriggerWorkflowModule : TestBase<EventTriggerWorkflowStartup>
{
    [Fact]
    public void Test()
    {
        var host = GetRequiredService<IWorkflowHost>();
        host.RegisterWorkflow<EventSampleWorkflow, MyDataClass>();
        host.Start();
        var initialData = new MyDataClass();
        var workflowId = host.StartWorkflow("EventSampleWorkflow", 1, initialData).Result;
        host.PublishEvent("MyEvent", workflowId, Guid.NewGuid());
        host.Stop();
    }
}