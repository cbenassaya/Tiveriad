
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.ComponentModel.DataAnnotations;
namespace Tiveriad.Notifications.Core.Entities;

public class Notification : IEntity<string>, IAuditable<string>
{


    [MaxLength(24)] public string Id { get; set; } = default!;
    [Required] public string UserId { get; set; } = default!;
    [Required] public NotificationState State { get; set; } = default!;
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public Subject? Subject { get; set; }
    public NotificationMessage? Message { get; set; }

}

