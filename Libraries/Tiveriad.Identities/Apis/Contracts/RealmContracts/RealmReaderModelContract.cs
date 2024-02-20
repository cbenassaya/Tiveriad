#region

using Tiveriad.Identities.Apis.Contracts.FeatureContracts;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.RealmContracts;

public class RealmReaderModelContract
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Metadata? Properties { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
}