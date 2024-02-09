
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Tiveriad.Registrations.Core.Entities;

public class Registration : IEntity<string>, IAuditable<string>
{


    [MaxLength(24)][Required] public string Id { get; set; } = default!;
    [MaxLength(500)][Required] public string Description { get; set; } = default!;
    [MaxLength(50)][Required] public string OrganizationName { get; set; } = default!;
    [MaxLength(100)][Required] public string Firstname { get; set; } = default!;
    [MaxLength(100)][Required] public string Lastname { get; set; } = default!;
    [MaxLength(100)][Required] public string Username { get; set; } = default!;
    [NotMapped][MaxLength(12)][MinLength(12)][Required] public string Password { get; set; } = default!;
    [MaxLength(100)][Required] public string Email { get; set; } = default!;
    [MaxLength(12)][Required] public string DefaultLocale { get; set; } = default!;
    public Metadata? Data { get; set; }
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public RegistrationModel? RegistrationModel { get; set; }

}

