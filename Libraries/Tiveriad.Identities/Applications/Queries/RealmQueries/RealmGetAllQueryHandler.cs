#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RealmQueries;

public class RealmGetAllQueryHandler : IRequestHandler<RealmGetAllQueryHandlerRequest, PagedResult<Realm>>
{
    private IRepository<Feature, string> _featureRepository;
    private readonly IRepository<Realm, string> _realmRepository;

    public RealmGetAllQueryHandler(IRepository<Realm, string> realmRepository,
        IRepository<Feature, string> featureRepository)
    {
        _realmRepository = realmRepository;
        _featureRepository = featureRepository;
    }


    public Task<PagedResult<Realm>> Handle(RealmGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        
        var query = _realmRepository.Queryable;
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);
        if (request.Name != null) query = query.Where(x => x.Name.Contains(request.Name));


        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ? query.OrderByDescending(order.Substring(1)) : query.OrderBy(order);

        return Task.Run(() => query.GetPaged(), cancellationToken);
        
    }
}