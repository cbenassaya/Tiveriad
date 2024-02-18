#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.LanguageQueries;

public class LanguageGetByIdQueryHandler : IRequestHandler<LanguageGetByIdQueryHandlerRequest, Language?>
{
    private readonly IRepository<Language, string> _languageRepository;

    public LanguageGetByIdQueryHandler(IRepository<Language, string> languageRepository)
    {
        _languageRepository = languageRepository;
    }


    public Task<Language?> Handle(LanguageGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _languageRepository.Queryable;
        query = query.Where(x => x.Id == request.Id);
        query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}