#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Identities.Core.Entities;

public class Membership : IEntity<string>, IAuditable<string>
{
    public MembershipState State { get; set; }
    public Metadata? Properties { get; set; }
    public User? User { get; set; }
    public Organization? Organization { get; set; }
    public List<Role> Roles { get; set; } = new();
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    [MaxLength(24)] [Required] public string Id { get; set; } = default!;
}