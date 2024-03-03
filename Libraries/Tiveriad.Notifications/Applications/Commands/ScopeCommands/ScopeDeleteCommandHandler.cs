
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Notifications.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public class ScopeDeleteCommandHandler : IRequestHandler<ScopeDeleteCommandHandlerRequest, bool>
{
    private IRepository<Scope, string> _scopeRepository;
    public ScopeDeleteCommandHandler(IRepository<Scope, string> scopeRepository)
    {
        _scopeRepository = scopeRepository;

    }


    public Task<bool> Handle(ScopeDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
{
    
    var query = _scopeRepository.Queryable;
    query = query.Where(x => x.Id == request.Id);


    var scope = query.FirstOrDefault();
    if (scope == null) throw new Exception();
    return _scopeRepository.DeleteMany(x => x.Id == request.Id) == 1;
}, cancellationToken);
        
    }
}

