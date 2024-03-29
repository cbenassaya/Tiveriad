
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.ComponentModel.DataAnnotations;
namespace Tiveriad.Notifications.Core.Entities;

public class NotificationMessage : IEntity<string>, IAuditable<string>
{


    [MaxLength(24)] public string Id { get; set; } = default!;
    public InternationalizedString? Title { get; set; }
    public InternationalizedString? Body { get; set; }
    public InternationalizedString? ConfirmLink { get; set; }
    public InternationalizedString? ConfirmText { get; set; }
    public InternationalizedString? ImageSmall { get; set; }
    public InternationalizedString? ImageLarge { get; set; }
    public InternationalizedString? LinkUrl { get; set; }
    public InternationalizedString? LinkText { get; set; }
    public ConfirmMode? ConfirmMode { get; set; }
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }

}

