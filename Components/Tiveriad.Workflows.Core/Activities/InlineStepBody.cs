#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Core.Primitives;

public class InlineStepBody : StepBody
{
    private readonly Func<IStepExecutionContext, ExecutionResult> _body;

    public InlineStepBody(Func<IStepExecutionContext, ExecutionResult> body)
    {
        _body = body;
    }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        return _body.Invoke(context);
    }
}