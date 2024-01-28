#region

using Tiveriad.Notifications.Apis.Contracts.NotificationMessageContracts;
using Tiveriad.Notifications.Apis.Contracts.SubjectContracts;

#endregion

namespace Tiveriad.Notifications.Apis.Contracts.NotificationContracts;

public class NotificationReaderModel
{
    public string? Id { get; set; }
    public string? UserId { get; set; }
    public string? State { get; set; }
    public SubjectReduceModel? Subject { get; set; }
    public NotificationMessageReduceModel? Message { get; set; }
}