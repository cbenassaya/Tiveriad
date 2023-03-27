#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Models.LifeCycleEvents;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services.ErrorHandlers;

public class TerminateHandler : IWorkflowErrorHandler
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly ILifeCycleEventPublisher _eventPublisher;

    public TerminateHandler(ILifeCycleEventPublisher eventPublisher, IDateTimeProvider dateTimeProvider)
    {
        _eventPublisher = eventPublisher;
        _dateTimeProvider = dateTimeProvider;
    }

    public WorkflowErrorHandling Type => WorkflowErrorHandling.Terminate;

    public void Handle(WorkflowInstance workflow, WorkflowDefinition def, ExecutionPointer pointer, WorkflowStep step,
        Exception exception, Queue<ExecutionPointer> bubbleUpQueue)
    {
        workflow.Status = WorkflowStatus.Terminated;
        workflow.CompleteTime = _dateTimeProvider.UtcNow;

        _eventPublisher.PublishNotification(new WorkflowTerminated
        {
            EventTimeUtc = _dateTimeProvider.UtcNow,
            Reference = workflow.Reference,
            WorkflowInstanceId = workflow.Id,
            WorkflowDefinitionId = workflow.WorkflowDefinitionId,
            Version = workflow.Version
        });
    }
}