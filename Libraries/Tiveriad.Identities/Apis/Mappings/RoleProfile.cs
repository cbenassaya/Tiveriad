#region

using AutoMapper;
using Tiveriad.Identities.Apis.Contracts.RoleContracts;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.Mappings;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<RoleIdModelContract, Role>();
        CreateMap<Role, RoleReduceModelContract>();
        CreateMap<Role, RoleReaderModelContract>();
        CreateMap<Role, RoleInfoReaderModelContract>();
        CreateMap<RoleWriterModelContract, Role>();
        CreateMap<PagedResult<Role>, PagedResult<RoleReaderModelContract>>();
    }
}