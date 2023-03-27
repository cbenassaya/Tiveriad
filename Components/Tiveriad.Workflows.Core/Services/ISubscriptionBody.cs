namespace Tiveriad.Workflows.Core.Services;

public interface ISubscriptionBody : IStepBody
{
    object EventData { get; set; }
}