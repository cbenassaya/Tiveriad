#region

using Tiveriad.UnitTests;
using Tiveriad.Workflows.Core.Services;
using Tiveriad.Workflows.Tests.SimpleDecision;
using Xunit;

#endregion

namespace Tiveriad.Workflows.Tests.PassingData;

public class PassingDataWorkflowModule : TestBase<PassingDataWorkflowStartup>
{
    [Fact]
    public void Test()
    {
        var host = GetRequiredService<IWorkflowHost>();
        host.RegisterWorkflow<PassingDataWorkflow, MyDataClass>();
        host.RegisterWorkflow<PassingDataWorkflow2, Dictionary<string, int>>();
        host.Start();

        var initialData = new MyDataClass
        {
            Value1 = 2,
            Value2 = 3
        };

        //host.StartWorkflow("PassingDataWorkflow", 1, initialData);


        var initialData2 = new Dictionary<string, int>
        {
            ["Value1"] = 7,
            ["Value2"] = 2
        };

        host.StartWorkflow("PassingDataWorkflow2", 1, initialData2);
        host.Stop();
    }
}