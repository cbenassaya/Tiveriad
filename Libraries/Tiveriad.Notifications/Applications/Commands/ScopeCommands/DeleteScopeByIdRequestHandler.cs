#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public class DeleteScopeByIdRequestHandler : IRequestHandler<DeleteScopeByIdRequest, bool>
{
    private readonly IRepository<Scope, string> _scopeRepository;

    public DeleteScopeByIdRequestHandler(IRepository<Scope, string> scopeRepository)
    {
        _scopeRepository = scopeRepository;
    }


    public Task<bool> Handle(DeleteScopeByIdRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            //<-- START CUSTOM CODE-->
            var query = _scopeRepository.Queryable;
            query = query.Where(x => x.Id == request.Id);
            var scope = query.FirstOrDefault();
            if (scope == null) throw new Exception();
            return _scopeRepository.DeleteMany(x => x.Id == request.Id) == 1;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}