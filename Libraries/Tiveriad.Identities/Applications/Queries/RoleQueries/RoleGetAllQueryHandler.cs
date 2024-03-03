#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RoleQueries;

public class RoleGetAllQueryHandler : IRequestHandler<RoleGetAllQueryHandlerRequest, List<Role>>
{
    private IRepository<Realm, string> _realmRepository;
    private readonly IRepository<Role, string> _roleRepository;

    public RoleGetAllQueryHandler(IRepository<Role, string> roleRepository, IRepository<Realm, string> realmRepository)
    {
        _roleRepository = roleRepository;
        _realmRepository = realmRepository;
    }


    public Task<List<Role>> Handle(RoleGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        
        var query = _roleRepository.Queryable.Include(x => x.Organization).AsQueryable();
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);
        if (request.OrganizationId != null) query = query.Where(x => x.Organization.Id == request.OrganizationId);
        if (request.Name != null) query = query.Where(x => x.Name.Contains(request.Name));
        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ? query.OrderByDescending(order.Substring(1)) : query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList(), cancellationToken);
        
    }
}