
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.LanguageCommands;

public class LanguageUpdateCommandHandler : IRequestHandler<LanguageUpdateCommandHandlerRequest, Language>
{
    private IRepository<Language, string> _languageRepository;
    public LanguageUpdateCommandHandler(IRepository<Language, string> languageRepository)
    {
        _languageRepository = languageRepository;

    }


    public Task<Language> Handle(LanguageUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _languageRepository.Queryable;



            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Name = request.Language.Name;
            result.Code = request.Language.Code;
            result.Descriptions = request.Language.Descriptions;

            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

