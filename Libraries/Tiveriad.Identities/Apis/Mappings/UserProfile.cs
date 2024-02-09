
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Tiveriad.Identities.Core.Entities;
using AutoMapper;
namespace Tiveriad.Identities.Apis.Mappings;

public class UserProfile : Profile
{

    public UserProfile()
    {

        CreateMap<UserIdModelContract, User>();
        CreateMap<User, UserReduceModelContract>();
        CreateMap<User, UserReaderModelContract>();
        CreateMap<UserWriterModelContract, User>();
    }


}

