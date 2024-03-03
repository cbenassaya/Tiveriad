#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommandHandlerRequest, User>
{

    private readonly IRepository<User, string> _userRepository;

    public UserUpdateCommandHandler(IRepository<User, string> userRepository)
    {
        _userRepository = userRepository;
    }


    public Task<User> Handle(UserUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _userRepository.Queryable;
            query = query.Where(x => x.Id == request.Id);
    
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Firstname = request.User.Firstname;
            result.Lastname = request.User.Lastname;
            result.Username = request.User.Username;
            result.Password = request.User.Password;
            result.Email = request.User.Email;
            result.Avatar = request.User.Avatar;
            result.DateOfBirth = request.User.DateOfBirth;
            result.Properties = request.User.Properties;
            result.LanguageId = request.User.LanguageId;
            result.LocaleId = request.User.LocaleId;
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}