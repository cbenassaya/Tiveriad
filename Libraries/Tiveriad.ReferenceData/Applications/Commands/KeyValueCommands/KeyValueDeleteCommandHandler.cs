
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.ReferenceData.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.ReferenceData.Applications.Commands.KeyValueCommands;

public class KeyValueDeleteCommandHandler : IRequestHandler<KeyValueDeleteCommandHandlerRequest, bool>
{
    private IRepository<KeyValue, string> _keyValueRepository;
    private IRepository<InternationalizedValue, string> _internationalizedValueRepository;
    public KeyValueDeleteCommandHandler(IRepository<KeyValue, string> keyValueRepository, IRepository<InternationalizedValue, string> internationalizedValueRepository)
    {
        _keyValueRepository = keyValueRepository;
        _internationalizedValueRepository = internationalizedValueRepository;

    }


    public Task<bool> Handle(KeyValueDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
{
    var query = _keyValueRepository.Queryable;
    query = query.Where(x => x.Id == request.Id);
    query = query.Where(x => (x.OrganizationId == request.OrganizationId && x.Visibility == Visibility.Private) || x.Visibility == Visibility.Public);

    var keyValue = query.FirstOrDefault();
    if (keyValue == null) throw new Exception();
    return _keyValueRepository.DeleteMany(x => x.OrganizationId == request.OrganizationId && x.Id == request.Id) == 1;
}, cancellationToken);

    }
}

