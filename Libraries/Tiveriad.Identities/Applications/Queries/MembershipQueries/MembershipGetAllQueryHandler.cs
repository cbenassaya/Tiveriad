#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.MembershipQueries;

public class MembershipGetAllQueryHandler : IRequestHandler<MembershipGetAllQueryHandlerRequest, List<Membership>>
{
    private readonly IRepository<Membership, string> _membershipRepository;
    private IRepository<Organization, string> _organizationRepository;
    private IRepository<Role, string> _roleRepository;
    private IRepository<User, string> _userRepository;

    public MembershipGetAllQueryHandler(IRepository<Membership, string> membershipRepository,
        IRepository<User, string> userRepository, IRepository<Organization, string> organizationRepository,
        IRepository<Role, string> roleRepository)
    {
        _membershipRepository = membershipRepository;
        _userRepository = userRepository;
        _organizationRepository = organizationRepository;
        _roleRepository = roleRepository;
    }


    public Task<List<Membership>> Handle(MembershipGetAllQueryHandlerRequest request,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _membershipRepository.Queryable.Include(x => x.User)
            .Include(x => x.Organization).AsQueryable();
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);


        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ? query.OrderByDescending(order.Substring(1)) : query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}