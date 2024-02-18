#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.RealmContracts;

public class RealmWriterModelContract
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Metadata? Properties { get; set; }
    [Required] public List<string> FeaturesId { get; set; } = new();
}