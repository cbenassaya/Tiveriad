
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Tiveriad.Identities.Apis.Contracts.MembershipContracts;

public class MembershipWriterModelContract
{


    public MembershipState? State { get; set; }
    public Metadata? Properties { get; set; }
    [Required] public string UserId { get; set; } = default!;
    [Required] public string OrganizationId { get; set; } = default!;
    [Required] public List<string> RolesId { get; set; } = new();

}

