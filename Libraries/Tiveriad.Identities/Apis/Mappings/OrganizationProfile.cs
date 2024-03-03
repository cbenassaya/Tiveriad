
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Core.Entities;
using AutoMapper;
namespace Tiveriad.Identities.Apis.Mappings;

public class OrganizationProfile : Profile
{

    public OrganizationProfile()
    {

        CreateMap<OrganizationIdModelContract, Organization>();
        CreateMap<Organization, OrganizationReduceModelContract>();
        CreateMap<Organization, OrganizationReaderModelContract>();
        CreateMap<OrganizationWriterModelContract, Organization>()
        .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => new User() { Id = src.OwnerId }));
    }


}

