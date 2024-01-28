#region

using System.ComponentModel.DataAnnotations;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Apis.Contracts.NotificationContracts;

public class NotificationUpdaterModel
{
    public string? Id { get; set; }
    public string? UserId { get; set; }
    public NotificationState? State { get; set; }
    [Required] public string SubjectId { get; set; } = null;
    [Required] public string MessageId { get; set; } = null;
}