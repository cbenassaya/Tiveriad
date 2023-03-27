namespace Tiveriad.Workflows.Core.Models;

public class ActivityResult
{
    public enum StatusType
    {
        Success,
        Fail
    }

    public StatusType Status { get; set; }
    public string SubscriptionId { get; set; }
    public object Data { get; set; }
}