#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Notifications.Apis.Contracts.NotificationContracts;

public class NotificationWriterModel
{
    public string? UserId { get; set; }
    [Required] public string SubjectId { get; set; } = default!;
    [Required] public string MessageId { get; set; } = default!;
}