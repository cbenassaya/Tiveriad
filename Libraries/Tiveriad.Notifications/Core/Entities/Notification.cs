#region

using System.ComponentModel.DataAnnotations;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Notifications.Core.Entities;

public class Notification : IEntity<string>, IAuditable<string>
{
    [Required] public string UserId { get; set; } = null!;
    [Required] public NotificationState State { get; set; }
    public Subject? Subject { get; set; }
    public NotificationMessage? Message { get; set; }
    [Required] public string CreatedBy { get; set; } = null!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }


    [MaxLength(24)] public string Id { get; set; } = null!;
}