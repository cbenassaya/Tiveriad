using System.ComponentModel.DataAnnotations;

namespace Tiveriad.Identities.Apis.Contracts;

public class OrganizationUpdaterModel
{
    [Required] public string Id { get; set; } = string.Empty;
    [Required] public string Name { get; set; } = string.Empty;

    [MaxLength(500)] public string? Description { get; set; } = string.Empty;

}