#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.LocaleQueries;

public class LocaleGetByIdQueryHandler : IRequestHandler<LocaleGetByIdQueryHandlerRequest, Locale?>
{
    private readonly IRepository<Locale, string> _localeRepository;

    public LocaleGetByIdQueryHandler(IRepository<Locale, string> localeRepository)
    {
        _localeRepository = localeRepository;
    }


    public Task<Locale?> Handle(LocaleGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _localeRepository.Queryable;
        query = query.Where(x => x.Id == request.Id);
        query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}