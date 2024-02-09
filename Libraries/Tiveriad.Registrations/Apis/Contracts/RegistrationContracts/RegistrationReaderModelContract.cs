
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Registrations.Apis.Contracts.RegistrationModelContracts;
namespace Tiveriad.Registrations.Apis.Contracts.RegistrationContracts;

public class RegistrationReaderModelContract
{


    public string? Id { get; set; }
    public string? Description { get; set; }
    public string? OrganizationName { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? DefaultLocale { get; set; }
    public Metadata? Data { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public RegistrationModelReduceModelContract? RegistrationModel { get; set; }

}

