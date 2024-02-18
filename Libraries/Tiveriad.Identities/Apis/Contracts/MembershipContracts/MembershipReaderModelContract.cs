#region

using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Apis.Contracts.RoleContracts;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.MembershipContracts;

public class MembershipReaderModelContract
{
    public string? Id { get; set; }
    public MembershipState? State { get; set; }
    public Metadata? Properties { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public UserReduceModelContract? User { get; set; }
    public OrganizationReduceModelContract? Organization { get; set; }
    public List<RoleReduceModelContract>? Roles { get; set; } = new();
}