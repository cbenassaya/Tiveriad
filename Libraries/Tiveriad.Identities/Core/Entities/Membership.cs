
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.ComponentModel.DataAnnotations;
namespace Tiveriad.Identities.Core.Entities;

public class Membership : IEntity<string>, IAuditable<string>
{


    [MaxLength(24)][Required] public string Id { get; set; } = default!;
    public MembershipState? State { get; set; }
    public Metadata? Properties { get; set; }
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public User? User { get; set; }
    public Organization? Organization { get; set; }

}

