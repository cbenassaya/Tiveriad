#region

using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Apis.Contracts.PolicyContracts;
using Tiveriad.Identities.Apis.Contracts.RealmContracts;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.RoleContracts;

public class RoleReaderModelContract
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Code { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public OrganizationReduceModelContract? Organization { get; set; }
}


public class RoleInfoReaderModelContract
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public List<PolicyReaderModelContract> Policies { get; set; }
    
}