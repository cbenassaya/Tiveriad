#region

using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Core.Models;

public abstract class StepBodyAsync : IStepBody
{
    public abstract Task<ExecutionResult> RunAsync(IStepExecutionContext context);
}