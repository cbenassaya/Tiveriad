#region

using Tiveriad.Identities.Apis.Contracts.FeatureContracts;
using Tiveriad.Identities.Apis.Contracts.RealmContracts;
using Tiveriad.Identities.Apis.Contracts.RoleContracts;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.PolicyContracts;

public class PolicyReaderModelContract
{
    public string? Id { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public RealmReduceModelContract? Realm { get; set; }
    public RoleReduceModelContract? Role { get; set; }
    public List<FeatureReduceModelContract> Features { get; set; } = new();
}