
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Queries.OrganizationQueries;

public class OrganizationGetAllQueryHandler : IRequestHandler<OrganizationGetAllQueryHandlerRequest, List<Organization>>
{
    private IRepository<Organization, string> _organizationRepository;
    private IRepository<User, string> _userRepository;
    private IRepository<TimeArea, string> _timeAreaRepository;
    public OrganizationGetAllQueryHandler(IRepository<Organization, string> organizationRepository, IRepository<User, string> userRepository, IRepository<TimeArea, string> timeAreaRepository)
    {
        _organizationRepository = organizationRepository;
        _userRepository = userRepository;
        _timeAreaRepository = timeAreaRepository;

    }


    public Task<List<Organization>> Handle(OrganizationGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _organizationRepository.Queryable.Include(x => x.Owner)
        .Include(x => x.TimeArea).AsQueryable();
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);
        if (request.Name != null) query = query.Where(x => x.Name.Contains(request.Name));
        if (request.Domain != null) query = query.Where(x => x.Domain.Contains(request.Domain));
        if (request.State != null) query = query.Where(x => x.State == request.State);


        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ?
                query.OrderByDescending(order.Substring(1)) :
                query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

