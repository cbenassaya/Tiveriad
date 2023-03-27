#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Core.Primitives;

public class WorkflowStepInline : WorkflowStep<InlineStepBody>
{
    public Func<IStepExecutionContext, ExecutionResult> Body { get; set; }

    public override IStepBody ConstructBody(IServiceProvider serviceProvider)
    {
        return new InlineStepBody(Body);
    }
}