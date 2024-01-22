#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Identities.Apis.Contracts;

public class OrganizationWriterModel
{
    [Required] public string Name { get; set; } = string.Empty;

    [MaxLength(500)] public string? Description { get; set; } = string.Empty;

    [Required] public UserWriterModel Owner { get; set; } = new();
}


public class OrganizationUpdaterModel
{
    [Required] public string Id { get; set; } = string.Empty;
    [Required] public string Name { get; set; } = string.Empty;

    [MaxLength(500)] public string? Description { get; set; } = string.Empty;

}