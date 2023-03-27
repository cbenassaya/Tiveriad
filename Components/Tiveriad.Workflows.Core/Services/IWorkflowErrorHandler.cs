#region

using Tiveriad.Workflows.Core.Models;

#endregion

namespace Tiveriad.Workflows.Core.Services;

public interface IWorkflowErrorHandler
{
    WorkflowErrorHandling Type { get; }

    void Handle(WorkflowInstance workflow, WorkflowDefinition def, ExecutionPointer pointer, WorkflowStep step,
        Exception exception, Queue<ExecutionPointer> bubbleUpQueue);
}