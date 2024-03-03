
using Tiveriad.ReferenceData.Apis.Contracts.InternationalizedValueContracts;
using Tiveriad.ReferenceData.Core.Entities;
using AutoMapper;
namespace Tiveriad.ReferenceData.Apis.Mappings;

public class InternationalizedValueProfile : Profile
{
    public InternationalizedValueProfile()
    {
        CreateMap<InternationalizedValueModelContract, InternationalizedValue>();
        CreateMap<InternationalizedValue, InternationalizedValueModelContract>();
    }
}

