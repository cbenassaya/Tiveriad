using AutoMapper;
using Tiveriad.Multitenancy.Apis.Contracts;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Apis.Mappings;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserReaderModel>();
        CreateMap<UserWriterModel, User>();
    }
}