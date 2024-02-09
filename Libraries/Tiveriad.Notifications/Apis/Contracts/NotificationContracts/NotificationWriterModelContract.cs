
using System;
using Tiveriad.Notifications.Core.Entities;
using System.ComponentModel.DataAnnotations;
namespace Tiveriad.Notifications.Apis.Contracts.NotificationContracts;

public class NotificationWriterModelContract
{


    public string? UserId { get; set; }
    public NotificationState? State { get; set; }
    [Required] public string SubjectId { get; set; } = default!;
    [Required] public string MessageId { get; set; } = default!;

}

