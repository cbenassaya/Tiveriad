
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Identities.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommandHandlerRequest, bool>
{
    private IRepository<User, string> _userRepository;
    public UserDeleteCommandHandler(IRepository<User, string> userRepository)
    {
        _userRepository = userRepository;

    }


    public Task<bool> Handle(UserDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
{
    var query = _userRepository.Queryable;
    query = query.Where(x => x.Id == request.Id);


    var user = query.FirstOrDefault();
    if (user == null) throw new Exception();
    return _userRepository.DeleteMany(x => x.Id == request.Id) == 1;
}, cancellationToken);

    }
}

