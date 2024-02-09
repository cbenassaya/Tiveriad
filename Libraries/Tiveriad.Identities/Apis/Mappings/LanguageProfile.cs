
using Tiveriad.Identities.Apis.Contracts.LanguageContracts;
using Tiveriad.Identities.Core.Entities;
using AutoMapper;
namespace Tiveriad.Identities.Apis.Mappings;

public class LanguageProfile : Profile
{

    public LanguageProfile()
    {

        CreateMap<LanguageIdModelContract, Language>();
        CreateMap<Language, LanguageReduceModelContract>();
        CreateMap<Language, LanguageReaderModelContract>();
        CreateMap<LanguageWriterModelContract, Language>();
    }


}

