
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Tiveriad.Identities.Core.Entities;

public class Membership : IEntity<string>, IAuditable<string>
{


    [MaxLength(24)][Required] public string Id { get; set; } = default!;
    public MembershipState? State { get; set; }
    public bool Default { get; set; } = false;
    public Metadata? Properties { get; set; }
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    [Required] public User User { get; set; } = default!;
    [Required] public Organization Organization { get; set; } = default!;
    public List<Role> Roles { get; set; } = new();

}

