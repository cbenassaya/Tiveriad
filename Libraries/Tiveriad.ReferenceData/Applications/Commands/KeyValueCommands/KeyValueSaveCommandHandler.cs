
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.ReferenceData.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.ReferenceData.Applications.Commands.KeyValueCommands;

public class KeyValueSaveCommandHandler : IRequestHandler<KeyValueSaveCommandHandlerRequest, KeyValue>
{
    private IRepository<KeyValue, string> _keyValueRepository;
    private IRepository<InternationalizedValue, string> _internationalizedValueRepository;
    public KeyValueSaveCommandHandler(IRepository<KeyValue, string> keyValueRepository, IRepository<InternationalizedValue, string> internationalizedValueRepository)
    {
        _keyValueRepository = keyValueRepository;
        _internationalizedValueRepository = internationalizedValueRepository;

    }


    public Task<KeyValue> Handle(KeyValueSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            request.KeyValue.OrganizationId = request.OrganizationId;
            request.KeyValue.Visibility = Visibility.Private;
            if (!request.KeyValue.InternationalizedValues.Any(x=>x.Default))
                request.KeyValue.InternationalizedValues.First().Default = true; 
            if (request.KeyValue.InternationalizedValues.Count(x => x.Default) > 1)
            {
                request.KeyValue.InternationalizedValues.ToList().ForEach((x) => x.Default = false);
                request.KeyValue.InternationalizedValues.First().Default = true;
            }
            await _keyValueRepository.AddOneAsync(request.KeyValue, cancellationToken);
            return request.KeyValue;
        }, cancellationToken);
    }
}

