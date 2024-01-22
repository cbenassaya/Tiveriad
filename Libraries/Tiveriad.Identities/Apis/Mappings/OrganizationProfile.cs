#region

using AutoMapper;
using Tiveriad.Identities.Apis.Contracts;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.Mappings;

public class OrganizationProfile : Profile
{
    public OrganizationProfile()
    {
        CreateMap<Organization, OrganizationReaderModel>();
        CreateMap<Organization, OrganizationReduceModel>();
        CreateMap<OrganizationWriterModel, Organization>();
    }
}