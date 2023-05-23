#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Tests.SimpleDecision;

public class RandomOutput : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        var rnd = new Random();
        var value = rnd.Next(2);
        Console.WriteLine("Generated random value {0}", value);
        return ExecutionResult.Outcome(value);
    }
}