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
        CreateMap<PolicyWriterModelContract, Policy>();
    }
}