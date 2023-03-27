namespace Tiveriad.Workflows.Core.Models;

public class WorkflowExecutorResult
{
    public List<EventSubscription> Subscriptions { get; set; } = new();
    public List<ExecutionError> Errors { get; set; } = new();
}