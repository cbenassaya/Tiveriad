#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Identities.Core.Entities;

public class Locale : IEntity<string>, IAuditable<string>
{
    [MaxLength(50)] [Required] public string Name { get; set; } = default!;
    [MaxLength(24)] [Required] public string Code { get; set; } = default!;
    [MaxLength(100)] public string? Descriptions { get; set; }
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }


    [MaxLength(24)] [Required] public string Id { get; set; } = default!;
}