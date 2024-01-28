#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Identities.Apis.Contracts.ClientContracts;

public class ClientUpdaterModel
{
    [Required] public string Name { get; set; } = string.Empty;

    [Required] public string Code { get; set; } = string.Empty;

    [Required] public string KeyId { get; set; } = string.Empty;

    [MaxLength(500)] public string? Description { get; set; } = string.Empty;
}