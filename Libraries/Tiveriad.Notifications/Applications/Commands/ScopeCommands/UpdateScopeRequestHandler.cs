#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public class UpdateScopeRequestHandler : IRequestHandler<UpdateScopeRequest, Scope>
{
    private readonly IRepository<Scope, string> _scopeRepository;

    public UpdateScopeRequestHandler(IRepository<Scope, string> scopeRepository)
    {
        _scopeRepository = scopeRepository;
    }


    public Task<Scope> Handle(UpdateScopeRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _scopeRepository.Queryable;
            query = query.Where(x => x.Id == request.Id);
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.OrganizationId = request.Scope.OrganizationId;
            result.ClientId = request.Scope.ClientId;
            result.RoleId = request.Scope.RoleId;
            result.GroupId = request.Scope.GroupId;
            result.UserId = request.Scope.UserId;
            result.ReferenceType = request.Scope.ReferenceType;
            result.ReferenceId = request.Scope.ReferenceId;

            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}