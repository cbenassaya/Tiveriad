#region

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
    public Subject Subject { get; set; } = null!;
    public string CreatedBy { get; set; } = null!;
    public DateTime Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string Id { get; set; } = null!;
}