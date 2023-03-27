using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

namespace Tiveriad.Workflows.Tests.SimpleDecision;

public class GoodbyeWorld : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Console.WriteLine("Goodbye world");
        return ExecutionResult.Next();
    }
}