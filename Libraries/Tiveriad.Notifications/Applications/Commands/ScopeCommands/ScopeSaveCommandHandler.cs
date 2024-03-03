
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public class ScopeSaveCommandHandler : IRequestHandler<ScopeSaveCommandHandlerRequest, Scope>
{
    private IRepository<Scope, string> _scopeRepository;
    public ScopeSaveCommandHandler(IRepository<Scope, string> scopeRepository)
    {
        _scopeRepository = scopeRepository;

    }


    public Task<Scope> Handle(ScopeSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        
        return Task.Run(async () =>
        {
            await _scopeRepository.AddOneAsync(request.Scope, cancellationToken);
            return request.Scope;
        }, cancellationToken);
        
    }
}

