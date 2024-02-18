#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.LanguageQueries;

public class LanguageGetAllQueryHandler : IRequestHandler<LanguageGetAllQueryHandlerRequest, List<Language>>
{
    private readonly IRepository<Language, string> _languageRepository;

    public LanguageGetAllQueryHandler(IRepository<Language, string> languageRepository)
    {
        _languageRepository = languageRepository;
    }


    public Task<List<Language>> Handle(LanguageGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _languageRepository.Queryable;
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