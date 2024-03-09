
using Tiveriad.ReferenceData.Core.Entities;
using Tiveriad.ReferenceData.Apis.Contracts.KeyValueContracts;
using AutoMapper;
namespace Tiveriad.ReferenceData.Apis.Mappings;

public class KeyValueProfile : Profile
{

    public KeyValueProfile()
    {
        CreateMap<KeyValueWriterModelContract, KeyValue>();
        CreateMap<KeyValue, KeyInternationalizedValueReaderModelContract>();
        CreateMap<KeyValue, KeyValueReaderModelContract>()
            .ForMember(dest => dest.Value, opt =>
            {
                opt.MapFrom(src =>
                    src.InternationalizedValues.Any() ? src.InternationalizedValues.FirstOrDefault()!.Value : src.Key);
            })
            .ForMember(dest => dest.Language, opt =>
            {
                opt.MapFrom(src =>
                    src.InternationalizedValues.Any()
                        ? src.InternationalizedValues.FirstOrDefault()!.Language
                        : string.Empty);
            });
        CreateMap<PagedResult<KeyValue>, PagedResult<KeyValueReaderModelContract>>();

    }


}

