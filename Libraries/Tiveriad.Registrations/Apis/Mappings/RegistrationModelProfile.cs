
using Tiveriad.Registrations.Apis.Contracts.RegistrationModelContracts;
using Tiveriad.Registrations.Core.Entities;
using AutoMapper;
namespace Tiveriad.Registrations.Apis.Mappings;

public class RegistrationModelProfile : Profile
{

    public RegistrationModelProfile()
    {

        CreateMap<RegistrationModelIdModelContract, RegistrationModel>();
        CreateMap<RegistrationModel, RegistrationModelReduceModelContract>();
        CreateMap<RegistrationModel, RegistrationModelReaderModelContract>();
        CreateMap<RegistrationModelWriterModelContract, RegistrationModel>();
    }


}

