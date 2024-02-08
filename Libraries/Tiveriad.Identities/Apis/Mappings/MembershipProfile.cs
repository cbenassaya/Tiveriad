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
        
        CreateMap<MembershipState,string>().ConvertUsing(s => s.ToString());
        CreateMap<string,MembershipState>().ConvertUsing(s => Enum.Parse<MembershipState>(s));
    }
}