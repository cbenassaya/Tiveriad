#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Identities.Core.Entities;

public class Organization : IEntity<string>, IAuditable<string>
{
    [MaxLength(50)] [Required] public string Name { get; set; } = default!;
    [MaxLength(50)] public string? Logo { get; set; }
    [MaxLength(100)] [Required] public string Domain { get; set; } = default!;
    [MaxLength(100)] [Required] public string Description { get; set; } = default!;
    public OrganizationState State { get; set; }
    public Metadata? Properties { get; set; }
    public User? Owner { get; set; }
    public TimeArea? TimeArea { get; set; }
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }


    [MaxLength(24)] [Required] public string Id { get; set; } = default!;
}