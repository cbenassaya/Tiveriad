using AutoMapper;
using Tiveriad.Identities.Apis.Contracts;
using Tiveriad.Identities.Core.Entities;

namespace Tiveriad.Identities.Apis.Mappings;

public class TimeAreaProfile : Profile
{
    public TimeAreaProfile()
    {
        CreateMap<TimeArea, TimeAreaReaderModel>();
        CreateMap<TimeArea, TimeAreaReduceModel>();
        CreateMap<TimeAreaWriterModel, TimeArea>();
        CreateMap<TimeAreaUpdaterModel, TimeArea>();
    }
}