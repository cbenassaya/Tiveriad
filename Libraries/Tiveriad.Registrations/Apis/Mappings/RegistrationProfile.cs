
using Tiveriad.Registrations.Core.Entities;
using Tiveriad.Registrations.Apis.Contracts.RegistrationContracts;
using AutoMapper;
namespace Tiveriad.Registrations.Apis.Mappings;

public class RegistrationProfile : Profile
{

    public RegistrationProfile()
    {

        CreateMap<Registration, RegistrationReaderModelContract>();
        CreateMap<RegistrationWriterModelContract, Registration>();
    }


}

