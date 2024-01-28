#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public class SaveScopeRequestHandler : IRequestHandler<SaveScopeRequest, Scope>
{
    private readonly IRepository<Scope, string> _scopeRepository;

    public SaveScopeRequestHandler(IRepository<Scope, string> scopeRepository)
    {
        _scopeRepository = scopeRepository;
    }


    public Task<Scope> Handle(SaveScopeRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            await _scopeRepository.AddOneAsync(request.Scope, cancellationToken);
            return request.Scope;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}