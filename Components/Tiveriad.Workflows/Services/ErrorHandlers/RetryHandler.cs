#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services.ErrorHandlers;

public class RetryHandler : IWorkflowErrorHandler
{
    private readonly IDateTimeProvider _datetimeProvider;
    private readonly IWorkflowOptions _options;

    public RetryHandler(IDateTimeProvider datetimeProvider, IWorkflowOptions options)
    {
        _datetimeProvider = datetimeProvider;
        _options = options;
    }

    public WorkflowErrorHandling Type => WorkflowErrorHandling.Retry;

    public void Handle(WorkflowInstance workflow, WorkflowDefinition def, ExecutionPointer pointer, WorkflowStep step,
        Exception exception, Queue<ExecutionPointer> bubbleUpQueue)
    {
        pointer.RetryCount++;
        pointer.SleepUntil =
            _datetimeProvider.UtcNow.Add(step.RetryInterval ??
                                         def.DefaultErrorRetryInterval ?? _options.ErrorRetryInterval);
        step.PrimeForRetry(pointer);
    }
}