namespace Tiveriad.Workflows.Core.Models.LifeCycleEvents;

public class StepCompleted : LifeCycleEvent
{
    public string ExecutionPointerId { get; set; }

    public int StepId { get; set; }
}