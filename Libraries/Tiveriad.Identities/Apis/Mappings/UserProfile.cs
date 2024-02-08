#region

using AutoMapper;
using Tiveriad.Identities.Apis.Contracts;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserReaderModel>();
        CreateMap<UserWriterModel, User>();
    }
}