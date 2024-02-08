using AutoMapper;
using Tiveriad.Identities.Apis.Contracts;
using Tiveriad.Identities.Core.Entities;

namespace Tiveriad.Identities.Apis.Mappings;

public class LocaleProfile : Profile
{
    public LocaleProfile()
    {
        CreateMap<Locale, LocaleReaderModel>();
        CreateMap<Locale, LocaleReduceModel>();
        CreateMap<LocaleWriterModel, Locale>();
        CreateMap<LocaleUpdaterModel, Locale>();
    }
}