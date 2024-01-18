using MediatR;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Queries.UserQueries;
public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, User>
{
    private readonly IRepository<User, ObjectId> _userRepository;
    public GetUserByIdRequestHandler(IRepository<User, ObjectId> userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _userRepository.Queryable.Where(x => x.Id.Equals(request.Id));
        //<-- END CUSTOM CODE-->
        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
    }
}