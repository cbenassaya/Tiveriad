#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.PolicyQueries;

public class PolicyGetAllQueryHandler : IRequestHandler<PolicyGetAllQueryHandlerRequest, List<Policy>>
{
    private IRepository<Feature, string> _featureRepository;
    private readonly IRepository<Policy, string> _policyRepository;
    private IRepository<Realm, string> _realmRepository;
    private IRepository<Role, string> _roleRepository;

    public PolicyGetAllQueryHandler(IRepository<Policy, string> policyRepository,
        IRepository<Realm, string> realmRepository, IRepository<Role, string> roleRepository,
        IRepository<Feature, string> featureRepository)
    {
        _policyRepository = policyRepository;
        _realmRepository = realmRepository;
        _roleRepository = roleRepository;
        _featureRepository = featureRepository;
    }


    public Task<List<Policy>> Handle(PolicyGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _policyRepository.Queryable
            .Include(x => x.Realm)
            .Include(x => x.Role)
            .Include(x => x.Features).AsQueryable();
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);
        if (request.RealmId != null) query = query.Where(x => x.Realm.Id == request.RealmId);
        if (request.RoleId != null) query = query.Where(x => x.Role.Id == request.RoleId);
        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ? query.OrderByDescending(order.Substring(1)) : query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}