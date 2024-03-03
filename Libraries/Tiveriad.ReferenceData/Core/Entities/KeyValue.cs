
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Tiveriad.ReferenceData.Core.Entities;

public class KeyValue : IEntity<string>, IAuditable<string>, IWithTenant<string>
{


    [MaxLength(24)][Required] public string Id { get; set; } = default!;
    [MaxLength(12)][Required] public string Key { get; set; } = default!;
    [MaxLength(50)][Required] public string Entity { get; set; } = default!;
    public string? ImageUrl { get; set; }
    public Metadata? Properties { get; set; }
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    [Required] public string OrganizationId { get; set; } = default!;
    [Required] public Visibility Visibility { get; set; } = default!;
    public List<InternationalizedValue> InternationalizedValues { get; set; } = new();

}

