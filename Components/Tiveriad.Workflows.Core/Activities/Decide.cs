#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Core.Primitives;

public class Decide : StepBody
{
    public object Expression { get; set; }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        return ExecutionResult.Outcome(Expression);
    }
}