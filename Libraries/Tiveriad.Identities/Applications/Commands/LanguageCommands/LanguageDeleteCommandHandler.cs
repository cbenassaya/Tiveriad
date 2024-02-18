#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.LanguageCommands;

public class LanguageDeleteCommandHandler : IRequestHandler<LanguageDeleteCommandHandlerRequest, bool>
{
    private readonly IRepository<Language, string> _languageRepository;

    public LanguageDeleteCommandHandler(IRepository<Language, string> languageRepository)
    {
        _languageRepository = languageRepository;
    }


    public Task<bool> Handle(LanguageDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            //<-- START CUSTOM CODE-->
            var query = _languageRepository.Queryable;
            query = query.Where(x => x.Id == request.Id);


            var language = query.FirstOrDefault();
            if (language == null) throw new Exception();
            return _languageRepository.DeleteMany(x => x.Id == request.Id) == 1;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}