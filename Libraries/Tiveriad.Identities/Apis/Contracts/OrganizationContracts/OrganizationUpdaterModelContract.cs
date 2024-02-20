using System.ComponentModel.DataAnnotations;

namespace Tiveriad.Identities.Apis.Contracts.OrganizationContracts;

public class OrganizationUpdaterModelContract
{
    public string? Name { get; set; }
    public string? Domain { get; set; }
    public string? Description { get; set; }
    public Metadata? Properties { get; set; }
    [Required] public string TimeAreaId { get; set; } = default!;
}