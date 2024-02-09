
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.ComponentModel.DataAnnotations;
namespace Tiveriad.Registrations.Core.Entities;

public class RegistrationModel : IEntity<string>, IAuditable<string>
{


    [MaxLength(24)][Required] public string Id { get; set; } = default!;
    [MaxLength(50)][Required] public string Name { get; set; } = default!;
    [MaxLength(500)][Required] public string Description { get; set; } = default!;
    [MaxLength(1000)][Required] public Metadata Model { get; set; } = default!;
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }

}

