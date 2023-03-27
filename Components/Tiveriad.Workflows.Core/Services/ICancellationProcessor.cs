#region

using Tiveriad.Workflows.Core.Models;

#endregion

namespace Tiveriad.Workflows.Core.Services;

public interface ICancellationProcessor
{
    void ProcessCancellations(WorkflowInstance workflow, WorkflowDefinition workflowDef,
        WorkflowExecutorResult executionResult);
}