
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class UserSaveCommandHandler : IRequestHandler<UserSaveCommandHandlerRequest, User>
{
    private IRepository<User, string> _userRepository;
    public UserSaveCommandHandler(IRepository<User, string> userRepository)
    {
        _userRepository = userRepository;

    }


    public Task<User> Handle(UserSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {

            await _userRepository.AddOneAsync(request.User, cancellationToken);
            return request.User;
        }, cancellationToken);
    }
}

