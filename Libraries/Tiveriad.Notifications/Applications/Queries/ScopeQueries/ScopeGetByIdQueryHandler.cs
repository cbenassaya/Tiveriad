
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Applications.Queries.ScopeQueries;

public class ScopeGetByIdQueryHandler : IRequestHandler<ScopeGetByIdQueryHandlerRequest, Scope?>
{
    private IRepository<Scope, string> _scopeRepository;
    public ScopeGetByIdQueryHandler(IRepository<Scope, string> scopeRepository)
    {
        _scopeRepository = scopeRepository;

    }


    public Task<Scope?> Handle(ScopeGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        
        var query = _scopeRepository.Queryable;
        query = query.Where(x => x.Id == request.Id); query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        
    }
}

