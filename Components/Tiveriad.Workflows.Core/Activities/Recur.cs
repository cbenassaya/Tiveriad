#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Core.Primitives;

public class Recur : ContainerStepBody
{
    public TimeSpan Interval { get; set; }

    public bool StopCondition { get; set; }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        if (StopCondition) return ExecutionResult.Next();

        return new ExecutionResult
        {
            Proceed = false,
            BranchValues = new List<object> { null },
            SleepFor = Interval
        };
    }
}