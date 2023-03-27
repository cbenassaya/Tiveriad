using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

namespace Tiveriad.Workflows.Tests.EventTrigger;

public class CustomMessage : StepBody
{
    public string Message { get; set; }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Console.WriteLine(Message);
        return ExecutionResult.Next();
    }
}