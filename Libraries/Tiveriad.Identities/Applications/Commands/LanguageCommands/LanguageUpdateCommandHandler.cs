#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.LanguageCommands;

public class LanguageUpdateCommandHandler : IRequestHandler<LanguageUpdateCommandHandlerRequest, Language>
{
    private readonly IRepository<Language, string> _languageRepository;

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
            query = query.Where(x => x.Id == request.Language.Id);


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