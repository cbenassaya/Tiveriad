
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Registrations.Apis.Contracts.RegistrationModelContracts;

public class RegistrationModelReaderModelContract
{


    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Metadata? Model { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }

}

