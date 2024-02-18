#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.LocaleQueries;

public class LocaleGetAllQueryHandler : IRequestHandler<LocaleGetAllQueryHandlerRequest, List<Locale>>
{
    private readonly IRepository<Locale, string> _localeRepository;

    public LocaleGetAllQueryHandler(IRepository<Locale, string> localeRepository)
    {
        _localeRepository = localeRepository;
    }


    public Task<List<Locale>> Handle(LocaleGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _localeRepository.Queryable;
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);


        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ? query.OrderByDescending(order.Substring(1)) : query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}