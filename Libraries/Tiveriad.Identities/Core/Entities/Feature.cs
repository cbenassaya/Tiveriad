#region

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata;

#endregion

namespace Tiveriad.Identities.Core.Entities;

public class Feature : IEntity<string>, IAuditable<string>
{
    [MaxLength(50)] [Required] public string Name { get; set; } = default!;
    [MaxLength(100)] public string? Description { get; set; }
    [MaxLength(12)] [Required] public string? Code { get; set; }
    [Required] public Realm Realm { get; set; }= default!;
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }


    [MaxLength(24)] [Required] public string Id { get; set; } = default!;
}