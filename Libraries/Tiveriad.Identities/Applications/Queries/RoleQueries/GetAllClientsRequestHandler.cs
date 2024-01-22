#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RoleQueries;

public class GetAllRolesRequestHandler : IRequestHandler<GetAllRolesRequest, IEnumerable<Role>>
{
    private readonly IRepository<Role, string> _roleRepository;

    public GetAllRolesRequestHandler(IRepository<Role, string> roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public Task<IEnumerable<Role>> Handle(GetAllRolesRequest request,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _roleRepository.Queryable
            .Include(x => x.Client).ThenInclude(x => x.Organization)
            .Where(x => x.Client.Id == request.ClientId && x.Client.Organization.Id == request.OrganizationId);
       
        if (!string.IsNullOrEmpty(request.Id))
            query = query.Where(x => x.Id == request.Id);
        if (!string.IsNullOrEmpty(request.Name))
            query = query.Where(x => x.Name.Contains(request.Name));
        if (!string.IsNullOrEmpty(request.ClientId))
            query = query.Where(x => x.Client.Id == request.ClientId);
        if (!string.IsNullOrEmpty(request.Q))
            query = query.Where(x =>
                x.Name.Contains(request.Q) || x.Description.Contains(request.Q));
        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                if (order.StartsWith("-"))
                    query = query.OrderByDescending(x => EF.Property<object>(x, order.Substring(1)));
                else
                    query = query.OrderBy(x => EF.Property<object>(x, order));
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList().AsEnumerable(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}