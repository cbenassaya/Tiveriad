#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.FeatureQueries;

public class FeatureGetAllQueryHandler : IRequestHandler<FeatureGetAllQueryHandlerRequest, List<Feature>>
{
    private readonly IRepository<Feature, string> _languageRepository;

    public FeatureGetAllQueryHandler(IRepository<Feature, string> languageRepository)
    {
        _languageRepository = languageRepository;
    }


    public Task<List<Feature>> Handle(FeatureGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _languageRepository.Queryable;
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);
        if (request.RealmId != null) query = query.Where(x => x.Realm.Id == request.RealmId);


        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ? query.OrderByDescending(order.Substring(1)) : query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}