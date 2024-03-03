
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Collections.Generic;
using Tiveriad.ReferenceData.Core.Entities;
using System;
using System.Linq.Expressions;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
using LinqKit;

namespace Tiveriad.ReferenceData.Applications.Queries.KeyValueQueries;

public class KeyValueGetAllQueryHandler : IRequestHandler<KeyValueGetAllQueryHandlerRequest, List<KeyValue>>
{
    private IRepository<KeyValue, string> _keyValueRepository;
    private IRepository<InternationalizedValue, string> _internationalizedValueRepository;
    public KeyValueGetAllQueryHandler(IRepository<KeyValue, string> keyValueRepository, IRepository<InternationalizedValue, string> internationalizedValueRepository)
    {
        _keyValueRepository = keyValueRepository;
        _internationalizedValueRepository = internationalizedValueRepository;

    }

    public Task<List<KeyValue>> Handle(KeyValueGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        var query = _keyValueRepository.Queryable.Include(x => x.InternationalizedValues).AsQueryable();
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);
        if (request.Key != null) query = query.Where(x => x.Key.Contains(request.Key));
        if (request.Entity != null) query = query.Where(x => x.Entity.Contains(request.Entity));
        query = query.Where(x => (x.OrganizationId == request.OrganizationId && x.Visibility == Visibility.Private) || x.Visibility == Visibility.Public);
        
        if (request.Language != null)
        {
            Expression<Func<KeyValue, bool>>? predicateBuilder = PredicateBuilder.New<KeyValue>(true);
            predicateBuilder = predicateBuilder.And(x => x.InternationalizedValues.Any(x => x.Language.Equals(request.Language)));
            if (request.Value != null)
                predicateBuilder = predicateBuilder.And(x => x.InternationalizedValues.Any(x => x.Value.Contains(request.Value)));
            query = query.Where(predicateBuilder);
        }
        else
        {
            Expression<Func<KeyValue, bool>>? predicateBuilder = PredicateBuilder.New<KeyValue>(true);
            predicateBuilder = predicateBuilder.And(x => x.InternationalizedValues.Any(x => x.Default));
            if (request.Value != null)
                predicateBuilder = predicateBuilder.And(x => x.InternationalizedValues.Any(x => x.Value.Contains(request.Value)));
            query = query.Where(predicateBuilder);
        }

        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ?
                query.OrderByDescending(order.Substring(1)) :
                query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList(), cancellationToken);
    }
}

