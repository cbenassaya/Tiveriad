#region

using AutoMapper;
using Tiveriad.Identities.Apis.Contracts;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.Mappings;

public class MembershipProfile : Profile
{
    public MembershipProfile()
    {
        CreateMap<Membership, MembershipReaderModel>();
        CreateMap<MembershipWriterModel, Membership>();
    }
}