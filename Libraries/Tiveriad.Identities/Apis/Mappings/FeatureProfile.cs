#region

using AutoMapper;
using Tiveriad.Identities.Apis.Contracts.FeatureContracts;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.Mappings;

public class FeatureProfile : Profile
{
    public FeatureProfile()
    {
        CreateMap<FeatureWriterModelContract, Feature>()
            .ForMember(dest => dest.Realm, opt => opt.MapFrom(src => new Realm() { Id = src.RealmId }));
        CreateMap<FeatureIdModelContract, Feature>();
        CreateMap<Feature, FeatureReduceModelContract>();
        CreateMap<Feature, FeatureReaderModelContract>();
        CreateMap<PagedResult<Feature>, PagedResult<FeatureReaderModelContract>>();
    }
}