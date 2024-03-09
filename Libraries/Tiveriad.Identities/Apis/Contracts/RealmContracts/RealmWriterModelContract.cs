#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.RealmContracts;

public class RealmWriterModelContract
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Code { get; set; }
    public Metadata? Properties { get; set; }
}