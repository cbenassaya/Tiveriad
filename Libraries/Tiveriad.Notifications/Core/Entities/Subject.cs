
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Tiveriad.Notifications.Core.Entities;

public class Subject : IEntity<string>, IAuditable<string>
{


    [MaxLength(24)] public string Id { get; set; } = default!;
    [MaxLength(100)][Required] public string Name { get; set; } = default!;
    [MaxLength(100)][Required] public InternationalizedString? Description { get; set; }
    [Required] public SubjectState State { get; set; } = default!;
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public NotificationMessage? Template { get; set; }
    public List<Scope> Scopes { get; set; } = new();

}

