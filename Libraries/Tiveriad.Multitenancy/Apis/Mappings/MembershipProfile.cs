using AutoMapper;
using Tiveriad.Multitenancy.Apis.Contracts;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Apis.Mappings;
public class MembershipProfile : Profile
{
    public MembershipProfile()
    {
        CreateMap<Membership, MembershipReaderModel>();
        CreateMap<MembershipWriterModel, Membership>();
    }
}