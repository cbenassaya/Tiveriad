using Tiveriad.Identities.Apis.Contracts.FeatureContracts;

namespace Tiveriad.Identities.Apis.Contracts.RealmContracts;

public class RealmReduceModelContract
{
    public string? Id { get; set; }
    public string? Name { get; set; }
}

public class RealmInfoModelContract:RealmReduceModelContract
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public List<FeatureReduceModelContract> Features { get; set; }
}