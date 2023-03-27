#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Core.Primitives;

public class ActionStepBody : StepBody
{
    public Action<IStepExecutionContext> Body { get; set; }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Body(context);
        return ExecutionResult.Next();
    }
}