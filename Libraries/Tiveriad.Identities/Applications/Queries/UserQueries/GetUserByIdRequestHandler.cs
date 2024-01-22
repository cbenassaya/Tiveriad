#region

using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, User>
{
    private readonly IRepository<User, string> _userRepository;

    public GetUserByIdRequestHandler(IRepository<User, string> userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _userRepository.Queryable.Where(x => x.Id == request.Id);
        //<-- END CUSTOM CODE-->
        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
    }
}