
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Queries.LanguageQueries;

public class LanguageGetByIdQueryHandler : IRequestHandler<LanguageGetByIdQueryHandlerRequest, Language?>
{
    private IRepository<Language, string> _languageRepository;
    public LanguageGetByIdQueryHandler(IRepository<Language, string> languageRepository)
    {
        _languageRepository = languageRepository;

    }


    public Task<Language?> Handle(LanguageGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _languageRepository.Queryable;
        query = query.Where(x => x.Id == request.Id); query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

