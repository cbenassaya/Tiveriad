#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class UserSaveCommandHandler : IRequestHandler<UserSaveCommandHandlerRequest, User>
{

    private readonly IRepository<User, string> _userRepository;

    public UserSaveCommandHandler(IRepository<User, string> userRepository)
    {
        _userRepository = userRepository;
    }


    public Task<User> Handle(UserSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            await _userRepository.AddOneAsync(request.User, cancellationToken);
            return request.User;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}