using System.ComponentModel.DataAnnotations;

namespace Tiveriad.Multitenancy.Apis.Contracts;
public class OrganizationWriterModel
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; } = string.Empty;

    [Required] public UserWriterModel Owner { get; set; } = new ();

}