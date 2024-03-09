
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Apis.Contracts.MembershipContracts;
using AutoMapper;
namespace Tiveriad.Identities.Apis.Mappings;

public class MembershipProfile : Profile
{

    public MembershipProfile()
    {

        CreateMap<Membership, MembershipReaderModelContract>();
        CreateMap<Membership, MembershipInfoReaderModelContract>();
        CreateMap<MembershipWriterModelContract, Membership>()
        .ForMember(dest => dest.User, opt => opt.MapFrom(src => new User() { Id = src.UserId }))
        .ForMember(dest => dest.Organization, opt => opt.MapFrom(src => new Organization() { Id = src.OrganizationId }))
        .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.RolesId.Select(x => new Role { Id = x }).ToList()));
        CreateMap<PagedResult<Membership>, PagedResult<MembershipReaderModelContract>>();
    }


}

