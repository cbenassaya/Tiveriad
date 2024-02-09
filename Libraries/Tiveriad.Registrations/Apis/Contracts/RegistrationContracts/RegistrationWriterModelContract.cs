
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.ComponentModel.DataAnnotations;
namespace Tiveriad.Registrations.Apis.Contracts.RegistrationContracts;

public class RegistrationWriterModelContract
{


    public string? Description { get; set; }
    public string? OrganizationName { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? DefaultLocale { get; set; }
    public Metadata? Data { get; set; }
    [Required] public string RegistrationModelId { get; set; } = default!;

}

