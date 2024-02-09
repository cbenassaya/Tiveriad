
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.LocaleCommands;

public class LocaleUpdateCommandHandler : IRequestHandler<LocaleUpdateCommandHandlerRequest, Locale>
{
    private IRepository<Locale, string> _localeRepository;
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

