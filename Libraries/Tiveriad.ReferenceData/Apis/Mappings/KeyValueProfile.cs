
using Tiveriad.ReferenceData.Core.Entities;
using Tiveriad.ReferenceData.Apis.Contracts.KeyValueContracts;
using AutoMapper;
namespace Tiveriad.ReferenceData.Apis.Mappings;

public class KeyValueProfile : Profile
{

    public KeyValueProfile()
    {

        CreateMap<KeyValue, KeyValueReaderModel>()
            .ForMember(dest => dest.Value,
                opt => opt.Ignore());
        CreateMap<KeyValueWriterModelContract, KeyValue>();
        
        CreateMap<KeyValueReaderModel, KeyInternationalizedValueReaderModelContract>();
        CreateMap<KeyValueReaderModel, KeyValueReaderModelContract>();
    }


}
