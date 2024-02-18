#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.LanguageCommands;

public class LanguageSaveCommandHandler : IRequestHandler<LanguageSaveCommandHandlerRequest, Language>
{
    private readonly IRepository<Language, string> _languageRepository;

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