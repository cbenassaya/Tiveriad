#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Identities.Core.Entities;

public class Policy : IEntity<string>, IAuditable<string>
{
    [MaxLength(50)] [Required] public string Name { get; set; } = default!;
    public Realm? Realm { get; set; }
    public Role? Role { get; set; }
    public Feature? Feature { get; set; }
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }


    [MaxLength(24)] [Required] public string Id { get; set; } = default!;
}