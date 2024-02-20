#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.OrganizationContracts;

public class OrganizationWriterModelContract
{
    public string? Name { get; set; }
    public string? Domain { get; set; }
    public string? Description { get; set; }
    public Metadata? Properties { get; set; }
    [Required] public string OwnerId { get; set; } = default!;
    [Required] public string TimeAreaId { get; set; } = default!;
}