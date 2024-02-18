#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.PolicyContracts;

public class PolicyWriterModelContract
{
    public string? Name { get; set; }
    [Required] public string RealmId { get; set; } = default!;
    [Required] public string RoleId { get; set; } = default!;
    [Required] public string FeatureId { get; set; } = default!;
}