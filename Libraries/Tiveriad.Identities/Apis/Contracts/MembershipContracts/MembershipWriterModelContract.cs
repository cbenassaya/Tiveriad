#region

using System.ComponentModel.DataAnnotations;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.MembershipContracts;

public class MembershipWriterModelContract
{
    public Metadata? Properties { get; set; }
    [Required] public string UserId { get; set; } = default!;
    [Required] public string OrganizationId { get; set; } = default!;
    [Required] public List<string> RolesId { get; set; } = new();
}