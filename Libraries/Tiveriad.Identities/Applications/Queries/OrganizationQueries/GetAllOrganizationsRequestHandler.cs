#region

using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Queries.OrganizationQueries;

public class GetAllOrganizationsRequestHandler : IRequestHandler<GetAllOrganizationsRequest, IEnumerable<Organization>>
{
    private readonly IRepository<Organization, string> _organizationRepository;

    public GetAllOrganizationsRequestHandler(IRepository<Organization, string> organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public Task<IEnumerable<Organization>> Handle(GetAllOrganizationsRequest request,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _organizationRepository.Queryable;
        if (!string.IsNullOrEmpty(request.Id))
            query = query.Where(x => x.Id == request.Id);
        if (!string.IsNullOrEmpty(request.Name))
            query = query.Where(x => x.Name.Contains(request.Name));
        if (!string.IsNullOrEmpty(request.Q))
            query = query.Where(x =>
                x.Name.Contains(request.Q) || x.Id.Contains(request.Q) || x.Description.Contains(request.Q));
        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ? query.OrderByDescending(order.Substring(1)) : query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList().AsEnumerable(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}