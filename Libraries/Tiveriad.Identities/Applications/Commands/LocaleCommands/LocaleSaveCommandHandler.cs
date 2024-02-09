
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.LocaleCommands;

public class LocaleSaveCommandHandler : IRequestHandler<LocaleSaveCommandHandlerRequest, Locale>
{
    private IRepository<Locale, string> _localeRepository;
    public LocaleSaveCommandHandler(IRepository<Locale, string> localeRepository)
    {
        _localeRepository = localeRepository;

    }


    public Task<Locale> Handle(LocaleSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            await _localeRepository.AddOneAsync(request.Locale, cancellationToken);
            return request.Locale;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

