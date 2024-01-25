using System.ComponentModel.DataAnnotations;

namespace Tiveriad.Identities.Apis.Contracts;

public class ClientUpdaterModel
{
    [Required] public string Name { get; set; } = string.Empty;
    
    [Required] public string Code { get; set; } = string.Empty;
    
    [Required] public string KeyId { get; set; } = string.Empty;

    [MaxLength(500)] public string? Description { get; set; } = string.Empty;

}