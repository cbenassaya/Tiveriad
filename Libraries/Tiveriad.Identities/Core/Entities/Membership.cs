#region

using System.ComponentModel.DataAnnotations;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Identities.Core.Entities;

public class Membership : IEntity<string>, IAuditable<string>
{
    public MembershipState State { get; set; }

    public bool IsOwner { get; set; } = false;

    public User User { get; set; }

    public Organization Organization { get; set; }

    public Client Client { get; set; }

    public string CreatedBy { get; set; }

    public DateTime Created { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModified { get; set; }

    [MaxLength(24)] public string? Id { get; set; }
}