#region

using AutoMapper;
using Tiveriad.Identities.Apis.Contracts.PolicyContracts;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.Mappings;

public class PolicyProfile : Profile
{
    public PolicyProfile()
    {
        CreateMap<Policy, PolicyReaderModelContract>();
        CreateMap<PolicyWriterModelContract, Policy>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src=>new Role(){Id = src.RoleId}))
            .ForMember(dest => dest.Realm, opt => opt.MapFrom(src=>new Realm(){Id = src.RealmId}))
            .ForMember(dest => dest.Features, opt => opt.MapFrom(src=>src.FeaturesId.Select(x=>new Feature(){Id=x}).ToList()));
    }
}