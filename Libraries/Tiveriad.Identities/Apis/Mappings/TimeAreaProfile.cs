
using Tiveriad.Identities.Apis.Contracts.TimeAreaContracts;
using Tiveriad.Identities.Core.Entities;
using AutoMapper;
namespace Tiveriad.Identities.Apis.Mappings;

public class TimeAreaProfile : Profile
{

    public TimeAreaProfile()
    {

        CreateMap<TimeAreaIdModelContract, TimeArea>();
        CreateMap<TimeArea, TimeAreaReduceModelContract>();
        CreateMap<TimeArea, TimeAreaReaderModelContract>();
        CreateMap<TimeAreaWriterModelContract, TimeArea>();
    }


}

