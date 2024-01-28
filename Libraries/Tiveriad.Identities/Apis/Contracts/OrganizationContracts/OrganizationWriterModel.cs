#region

using System.ComponentModel.DataAnnotations;
using Tiveriad.Identities.Apis.Contracts.UserContracts;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.OrganizationContracts;

public class OrganizationWriterModel
{
    [Required] public string Name { get; set; } = string.Empty;

    [MaxLength(500)] public string? Description { get; set; } = string.Empty;

    [Required] public UserWriterModel Owner { get; set; } = new();
}