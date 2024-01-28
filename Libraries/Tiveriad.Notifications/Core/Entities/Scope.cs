#region

using System.ComponentModel.DataAnnotations;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Notifications.Core.Entities;

public class Scope : IEntity<string>, IAuditable<string>
{
    public string? OrganizationId { get; set; }
    public string? ClientId { get; set; }
    public string? RoleId { get; set; }
    public string? GroupId { get; set; }
    public string? UserId { get; set; }
    public string? ReferenceType { get; set; }
    public string? ReferenceId { get; set; }
    [Required] public string CreatedBy { get; set; } = null!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }


    [MaxLength(24)] public string Id { get; set; } = null!;
}