using System.ComponentModel.DataAnnotations;

namespace Tiveriad.Multitenancy.Apis.Contracts;
public class UserWriterModel
{

    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(12)]
    public string Password { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(50)]
    public string Locale { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(50)]
    public string Firstname { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Lastname { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; } 
}