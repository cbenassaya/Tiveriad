using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

namespace Tiveriad.Workflows.Tests.PassingData;

public class GoodbyeWorld : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Console.WriteLine("Goodbye world");
        return ExecutionResult.Next();
    }
}