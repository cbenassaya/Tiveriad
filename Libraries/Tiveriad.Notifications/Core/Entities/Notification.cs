using Tiveriad.Core.Abstractions.Entities;

namespace Tiveriad.Notifications.Core;

public class Notification:IEntity<string>,IAuditable<string>
{
    public string Id { get; set; }  
    public string UserId { get; set; }
    public string TopicId { get; set; }
    public NotificationMessage Message { get; set; }
    public string CreatedBy { get; set; }
    public DateTime Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public NotificationStatus Status { get; set; }
}