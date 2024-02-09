
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Apis.Contracts.MembershipContracts;
using AutoMapper;
namespace Tiveriad.Identities.Apis.Mappings;

public class MembershipProfile : Profile
{

    public MembershipProfile()
    {

        CreateMap<Membership, MembershipReaderModelContract>();
        CreateMap<MembershipWriterModelContract, Membership>();
    }


}

