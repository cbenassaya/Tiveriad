using AutoMapper;
using Tiveriad.Multitenancy.Apis.Contracts;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Apis.Mappings;
public class OrganizationProfile : Profile
{
    public OrganizationProfile()
    {
        CreateMap<Organization, OrganizationReaderModel>();
        CreateMap<OrganizationWriterModel, Organization>();
    }
}