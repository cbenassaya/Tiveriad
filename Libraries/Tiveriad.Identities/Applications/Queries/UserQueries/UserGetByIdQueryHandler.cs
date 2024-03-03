#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQueryHandlerRequest, User?>
{
    private readonly IRepository<User, string> _userRepository;

    public UserGetByIdQueryHandler(IRepository<User, string> userRepository)
    {
        _userRepository = userRepository;
    }


    public Task<User?> Handle(UserGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _userRepository.Queryable;
        query = query.Where(x => x.Id == request.Id);
        query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}