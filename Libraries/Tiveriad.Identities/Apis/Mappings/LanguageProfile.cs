using AutoMapper;
using Tiveriad.Identities.Apis.Contracts;
using Tiveriad.Identities.Core.Entities;

namespace Tiveriad.Identities.Apis.Mappings;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
        CreateMap<Language, LanguageReaderModel>();
        CreateMap<Language, LanguageReduceModel>();
        CreateMap<LanguageWriterModel, Language>();
        CreateMap<LanguageUpdaterModel, Language>();
    }
}