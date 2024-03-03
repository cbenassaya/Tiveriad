
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.ComponentModel.DataAnnotations;
namespace Tiveriad.ReferenceData.Core.Entities;

public class InternationalizedValue : IEntity<string>, IAuditable<string>
{
    [MaxLength(24)][Required] public string Id { get; set; } = default!;
    [MaxLength(12)][Required] public string Language { get; set; } = default!;
    [MaxLength(50)][Required] public string Value { get; set; } = default!;
    public bool Default { get; set; } = default!;
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }

}

