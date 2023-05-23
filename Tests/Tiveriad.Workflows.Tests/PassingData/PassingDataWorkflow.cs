#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Tests.PassingData;

public class PassingDataWorkflow : IWorkflow<MyDataClass>
{
    public string Id => "PassingDataWorkflow";

    public int Version => 1;

    public void Build(IWorkflowBuilder<MyDataClass> builder)
    {
        builder
            .StartWith(context =>
            {
                Console.WriteLine("Starting workflow...");
                return ExecutionResult.Next();
            })
            .Then<AddNumbers>()
            .Input(step => step.Input1, data => data.Value1)
            .Input(step => step.Input2, data => data.Value2)
            .Output(data => data.Value3, step => step.Output)
            .Then<CustomMessage>()
            .Name("Print custom message")
            .Input(step => step.Message, data => "The answer is " + data.Value3)
            .Then(context =>
            {
                Console.WriteLine("Workflow complete");
                return ExecutionResult.Next();
            });
    }
}

public class PassingDataWorkflow2 : IWorkflow<Dictionary<string, int>>
{
    public void Build(IWorkflowBuilder<Dictionary<string, int>> builder)
    {
        builder
            .StartWith(context =>
            {
                Console.WriteLine("Starting workflow...");
                return ExecutionResult.Next();
            })
            .Then<AddNumbers>()
            .Input(step => step.Input1, data => data["Value1"])
            .Input(step => step.Input2, data => data["Value2"])
            .Output((step, data) => data["Value3"] = step.Output)
            .Then<CustomMessage>()
            .Name("Print custom message")
            .Input(step => step.Message, data => "The answer is " + data["Value3"])
            .Then(context =>
            {
                Console.WriteLine("Workflow complete");
                return ExecutionResult.Next();
            });
    }

    public string Id => "PassingDataWorkflow2";

    public int Version => 1;
}