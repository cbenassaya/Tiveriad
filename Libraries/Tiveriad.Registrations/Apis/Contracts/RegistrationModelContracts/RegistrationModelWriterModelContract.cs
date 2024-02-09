
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Registrations.Apis.Contracts.RegistrationModelContracts;

public class RegistrationModelWriterModelContract
{


    public string? Name { get; set; }
    public string? Description { get; set; }
    public Metadata? Model { get; set; }

}

