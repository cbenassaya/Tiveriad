#region

using AutoMapper;
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.Mappings;

public class OrganizationProfile : Profile
{
    public OrganizationProfile()
    {
        CreateMap<OrganizationIdModelContract, Organization>();
        CreateMap<Organization, OrganizationReduceModelContract>();
        CreateMap<Organization, OrganizationReaderModelContract>();
        CreateMap<OrganizationWriterModelContract, Organization>()
            .ForMember(x => x.Owner, opt => opt.MapFrom(src => new User() { Id = src.OwnerId }))
            .ForMember(x => x.TimeArea, opt => opt.MapFrom(src => new TimeArea() { Id = src.TimeAreaId }));
        
        CreateMap<OrganizationUpdaterModelContract, Organization>()
            .ForMember(x => x.TimeArea, opt => opt.MapFrom(src => new TimeArea() { Id = src.TimeAreaId }));
    }
}