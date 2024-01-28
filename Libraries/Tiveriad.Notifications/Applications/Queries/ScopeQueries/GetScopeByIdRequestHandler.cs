#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Application.Queries.ScopeQueries;

public class GetScopeByIdRequestHandler : IRequestHandler<GetScopeByIdRequest, Scope?>
{
    private readonly IRepository<Scope, string> _scopeRepository;

    public GetScopeByIdRequestHandler(IRepository<Scope, string> scopeRepository)
    {
        _scopeRepository = scopeRepository;
    }


    public Task<Scope?> Handle(GetScopeByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _scopeRepository.Queryable;
        query = query.Where(x => x.Id == request.Id);
        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}