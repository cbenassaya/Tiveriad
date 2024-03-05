
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.ReferenceData.Core.Entities;
using System;
using System.Linq.Expressions;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
using LinqKit;

namespace Tiveriad.ReferenceData.Applications.Queries.KeyValueQueries;

public class KeyValueGetByIdQueryHandler : IRequestHandler<KeyValueGetByIdQueryHandlerRequest, KeyValue?>
{
    private IRepository<KeyValue, string> _keyValueRepository;
    private IRepository<InternationalizedValue, string> _internationalizedValueRepository;
    public KeyValueGetByIdQueryHandler(IRepository<KeyValue, string> keyValueRepository, IRepository<InternationalizedValue, string> internationalizedValueRepository)
    {
        _keyValueRepository = keyValueRepository;
        _internationalizedValueRepository = internationalizedValueRepository;

    }


    public Task<KeyValue?> Handle(KeyValueGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        var query = _keyValueRepository.Queryable.Include(x => x.InternationalizedValues).AsQueryable();
        query = query.Where(x => x.Id == request.Id);
        query = query.Where(x => (x.OrganizationId == request.OrganizationId && x.Visibility == Visibility.Private) || x.Visibility == Visibility.Public);
        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
    }
}

