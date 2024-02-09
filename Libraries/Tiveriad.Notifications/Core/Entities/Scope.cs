
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.ComponentModel.DataAnnotations;
namespace Tiveriad.Notifications.Core.Entities;

public class Scope : IEntity<string>, IAuditable<string>
{


    [MaxLength(24)] public string Id { get; set; } = default!;
    public string? OrganizationId { get; set; }
    public string? ClientId { get; set; }
    public string? RoleId { get; set; }
    public string? GroupId { get; set; }
    public string? UserId { get; set; }
    public string? ReferenceType { get; set; }
    public string? ReferenceId { get; set; }
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }

}

