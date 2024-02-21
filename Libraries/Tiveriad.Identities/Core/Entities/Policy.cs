#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Identities.Core.Entities;

public class Policy : IEntity<string>, IAuditable<string>
{
    
    public Realm? Realm { get; set; }
    public Role? Role { get; set; }
    public List<Feature> Features { get; set; } = default!;
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }


    [MaxLength(24)] [Required] public string Id { get; set; } = default!;
}

public class PolicyFeature
{
    [MaxLength(24)] [Required] public string PolicyId { get; set; } = default!;
    [MaxLength(24)] [Required] public string FeatureId { get; set; } = default!;
}