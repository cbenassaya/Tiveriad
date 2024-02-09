
using Tiveriad.Notifications.Apis.Contracts.ScopeContracts;
using Tiveriad.Notifications.Core.Entities;
using AutoMapper;
namespace Tiveriad.Notifications.Apis.Mappings;

public class ScopeProfile : Profile
{

    public ScopeProfile()
    {

        CreateMap<ScopeIdModelContract, Scope>();
        CreateMap<Scope, ScopeReduceModelContract>();
        CreateMap<Scope, ScopeReaderModelContract>();
        CreateMap<ScopeWriterModelContract, Scope>();
    }


}

