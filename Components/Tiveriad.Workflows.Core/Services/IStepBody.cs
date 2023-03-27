#region

using Tiveriad.Workflows.Core.Models;

#endregion

namespace Tiveriad.Workflows.Core.Services;

public interface IStepBody
{
    Task<ExecutionResult> RunAsync(IStepExecutionContext context);
}