
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.LanguageCommands;

public class LanguageSaveCommandHandler : IRequestHandler<LanguageSaveCommandHandlerRequest, Language>
{
    private IRepository<Language, string> _languageRepository;
    public LanguageSaveCommandHandler(IRepository<Language, string> languageRepository)
    {
        _languageRepository = languageRepository;

    }


    public Task<Language> Handle(LanguageSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            await _languageRepository.AddOneAsync(request.Language, cancellationToken);
            return request.Language;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

