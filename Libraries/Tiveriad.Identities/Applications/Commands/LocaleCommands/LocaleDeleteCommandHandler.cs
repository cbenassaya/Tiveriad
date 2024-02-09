
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Identities.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.LocaleCommands;

public class LocaleDeleteCommandHandler : IRequestHandler<LocaleDeleteCommandHandlerRequest, bool>
{
    private IRepository<Locale, string> _localeRepository;
    public LocaleDeleteCommandHandler(IRepository<Locale, string> localeRepository)
    {
        _localeRepository = localeRepository;

    }


    public Task<bool> Handle(LocaleDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
{
    //<-- START CUSTOM CODE-->
    var query = _localeRepository.Queryable;
    query = query.Where(x => x.Id == request.Id);


    var locale = query.FirstOrDefault();
    if (locale == null) throw new Exception();
    return _localeRepository.DeleteMany(x => x.Id == request.Id) == 1;
}, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

