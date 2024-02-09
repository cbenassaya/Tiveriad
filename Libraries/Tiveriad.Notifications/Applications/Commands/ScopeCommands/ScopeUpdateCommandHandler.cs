
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public class ScopeUpdateCommandHandler : IRequestHandler<ScopeUpdateCommandHandlerRequest, Scope>
{
    private IRepository<Scope, string> _scopeRepository;
    public ScopeUpdateCommandHandler(IRepository<Scope, string> scopeRepository)
    {
        _scopeRepository = scopeRepository;

    }


    public Task<Scope> Handle(ScopeUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _scopeRepository.Queryable;



            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

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

