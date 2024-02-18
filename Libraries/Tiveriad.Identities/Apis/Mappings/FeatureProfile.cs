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
        CreateMap<FeatureIdModelContract, Feature>();
        CreateMap<Feature, FeatureReduceModelContract>();
    }
}