
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.ComponentModel.DataAnnotations;
namespace Tiveriad.Identities.Core.Entities;

public class TimeArea : IEntity<string>, IAuditable<string>
{


    [MaxLength(24)][Required] public string Id { get; set; } = default!;
    [MaxLength(50)][Required] public string Name { get; set; } = default!;
    [MaxLength(24)][Required] public string Code { get; set; } = default!;
    public string? Descriptions { get; set; }
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }

}

