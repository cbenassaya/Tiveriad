
using Tiveriad.Identities.Apis.Contracts.LocaleContracts;
using Tiveriad.Identities.Core.Entities;
using AutoMapper;
namespace Tiveriad.Identities.Apis.Mappings;

public class LocaleProfile : Profile
{

    public LocaleProfile()
    {

        CreateMap<LocaleIdModelContract, Locale>();
        CreateMap<Locale, LocaleReduceModelContract>();
        CreateMap<Locale, LocaleReaderModelContract>();
        CreateMap<LocaleWriterModelContract, Locale>();
    }


}

