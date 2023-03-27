#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Core.Primitives;

public class Delay : StepBody
{
    public TimeSpan Period { get; set; }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        if (context.PersistenceData != null) return ExecutionResult.Next();

        return ExecutionResult.Sleep(Period, true);
    }
}