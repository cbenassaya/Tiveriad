#region

using System.ComponentModel.DataAnnotations;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Notifications.Core.Entities;

public class Subject : IEntity<string>, IAuditable<string>
{
    [MaxLength(100)] [Required] public string Name { get; set; } = null!;
    [MaxLength(100)] [Required] public InternationalizedString? Description { get; set; }
    [Required] public SubjectState State { get; set; }
    public NotificationMessage? Template { get; set; }
    public List<Scope> Scopes { get; set; } = new();
    [Required] public string CreatedBy { get; set; } = null!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    [MaxLength(24)] public string Id { get; set; } = null!;
}