
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQueryHandlerRequest, User?>
{
    private IRepository<User, string> _userRepository;
    public UserGetByIdQueryHandler(IRepository<User, string> userRepository)
    {
        _userRepository = userRepository;

    }


    public Task<User?> Handle(UserGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        var query = _userRepository.Queryable;
        query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
    }
}

