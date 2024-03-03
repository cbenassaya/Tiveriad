
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.ReferenceData.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.ReferenceData.Applications.Commands.KeyValueCommands;

public class KeyValueUpdateCommandHandler : IRequestHandler<KeyValueUpdateCommandHandlerRequest, KeyValue>
{
    private IRepository<KeyValue, string> _keyValueRepository;
    private IRepository<InternationalizedValue, string> _internationalizedValueRepository;
    public KeyValueUpdateCommandHandler(IRepository<KeyValue, string> keyValueRepository, IRepository<InternationalizedValue, string> internationalizedValueRepository)
    {
        _keyValueRepository = keyValueRepository;
        _internationalizedValueRepository = internationalizedValueRepository;

    }


    public Task<KeyValue> Handle(KeyValueUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            var query = _keyValueRepository.Queryable;
            query = query.Where(x => x.Id == request.Id);
            query = query.Where(x => (x.OrganizationId == request.OrganizationId && x.Visibility == Visibility.Private) || x.Visibility == Visibility.Public);

            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();
            if (!request.KeyValue.InternationalizedValues.Any(x=>x.Default))
                request.KeyValue.InternationalizedValues.First().Default = true;
            if (request.KeyValue.InternationalizedValues.Count(x => x.Default) > 1)
            {
                request.KeyValue.InternationalizedValues.ToList().ForEach((x) => x.Default = false);
                request.KeyValue.InternationalizedValues.First().Default = true;
            }
            result.InternationalizedValues.RemoveAll((x)=>true); 
            result.Key = request.KeyValue.Key;
            result.Entity = request.KeyValue.Entity;
            result.ImageUrl = request.KeyValue.ImageUrl;
            result.Properties = request.KeyValue.Properties;
            result.InternationalizedValues.AddRange(request.KeyValue.InternationalizedValues);
            return result;
        }, cancellationToken);
    }
}

