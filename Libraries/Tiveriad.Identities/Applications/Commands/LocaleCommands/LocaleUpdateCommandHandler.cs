#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.LocaleCommands;

public class LocaleUpdateCommandHandler : IRequestHandler<LocaleUpdateCommandHandlerRequest, Locale>
{
    private readonly IRepository<Locale, string> _localeRepository;

    public LocaleUpdateCommandHandler(IRepository<Locale, string> localeRepository)
    {
        _localeRepository = localeRepository;
    }


    public Task<Locale> Handle(LocaleUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _localeRepository.Queryable;
            query = query.Where(x => x.Id == request.Id);

            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Name = request.Locale.Name;
            result.Code = request.Locale.Code;
            result.Descriptions = request.Locale.Descriptions;

            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}