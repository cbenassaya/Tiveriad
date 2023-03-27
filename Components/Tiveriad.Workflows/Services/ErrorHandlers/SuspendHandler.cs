#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Models.LifeCycleEvents;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services.ErrorHandlers;

public class SuspendHandler : IWorkflowErrorHandler
{
    private readonly IDateTimeProvider _datetimeProvider;
    private readonly ILifeCycleEventPublisher _eventPublisher;

    public SuspendHandler(ILifeCycleEventPublisher eventPublisher, IDateTimeProvider datetimeProvider)
    {
        _eventPublisher = eventPublisher;
        _datetimeProvider = datetimeProvider;
    }

    public WorkflowErrorHandling Type => WorkflowErrorHandling.Suspend;

    public void Handle(WorkflowInstance workflow, WorkflowDefinition def, ExecutionPointer pointer, WorkflowStep step,
        Exception exception, Queue<ExecutionPointer> bubbleUpQueue)
    {
        workflow.Status = WorkflowStatus.Suspended;
        _eventPublisher.PublishNotification(new WorkflowSuspended
        {
            EventTimeUtc = _datetimeProvider.UtcNow,
            Reference = workflow.Reference,
            WorkflowInstanceId = workflow.Id,
            WorkflowDefinitionId = workflow.WorkflowDefinitionId,
            Version = workflow.Version
        });

        step.PrimeForRetry(pointer);
    }
}