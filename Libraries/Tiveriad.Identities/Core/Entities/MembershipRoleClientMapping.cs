#region

using System.ComponentModel.DataAnnotations;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Identities.Core.Entities;

public class MembershipRoleClientMapping : IEntity<string>, IAuditable<string>
{
    public Client Client { get; set; }

    public Membership Membership { get; set; }
    public Role Role { get; set; }

    public string CreatedBy { get; set; }

    public DateTime Created { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModified { get; set; }

    [MaxLength(24)] public string? Id { get; set; }
}