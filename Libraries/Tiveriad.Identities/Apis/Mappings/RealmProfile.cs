#region

using AutoMapper;
using Tiveriad.Identities.Apis.Contracts.RealmContracts;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.Mappings;

public class RealmProfile : Profile
{
    public RealmProfile()
    {
        CreateMap<RealmIdModelContract, Realm>();
        CreateMap<Realm, RealmReduceModelContract>();
        CreateMap<Realm, RealmReaderModelContract>();
        CreateMap<RealmWriterModelContract, Realm>();
    }
}