#region

using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Notifications.Core.Entities;

public class Notification : IEntity<string>, IAuditable<string>
{
    public string UserId { get; set; } = null!;
    public Subject Subject { get; set; } = null!;
    public NotificationMessage Message { get; set; } = null!;
    public NotificationState State { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string Id { get; set; } = null!;
}