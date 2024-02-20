#region

using AutoMapper;
using Tiveriad.Identities.Apis.Contracts.MembershipContracts;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.Mappings;

public class MembershipProfile : Profile
{
    public MembershipProfile()
    {
        CreateMap<Membership, MembershipReaderModelContract>();
        CreateMap<MembershipWriterModelContract, Membership>()
            .ForMember(dest => dest.Organization, opt => opt.MapFrom(src=>new Organization(){Id = src.OrganizationId}))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src=>new User(){Id = src.UserId}))
            .ForMember(dest => dest.Roles, opt => opt.MapFrom(src=>src.RolesId.Select(x=>new Role{Id=x}).ToList()));
    }
}