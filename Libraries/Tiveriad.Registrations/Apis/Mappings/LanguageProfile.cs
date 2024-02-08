using AutoMapper;
using Tiveriad.Registrations.Apis.Contracts;
using Tiveriad.Registrations.Core.Entities;

namespace Tiveriad.Registrations.Apis.Mappings;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
        CreateMap<RegistrationModel, RegistrationModelReaderModel>();
        CreateMap<RegistrationModelWriterModel, RegistrationModel>();
        CreateMap<RegistrationModelUpdaterModel, RegistrationModel>();
        
        CreateMap<Registration, RegistrationReaderModel>();
        CreateMap<RegistrationWriterModel, Registration>();
        CreateMap<RegistrationUpdaterModel, Registration>();

    }
}