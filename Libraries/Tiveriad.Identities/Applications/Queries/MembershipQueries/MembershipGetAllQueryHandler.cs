
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Queries.MembershipQueries;

public class MembershipGetAllQueryHandler : IRequestHandler<MembershipGetAllQueryHandlerRequest, PagedResult<Membership>>
{
    private IRepository<Membership, string> _membershipRepository;
    private IRepository<User, string> _userRepository;
    private IRepository<Organization, string> _organizationRepository;
    private IRepository<Role, string> _roleRepository;
    public MembershipGetAllQueryHandler(IRepository<Membership, string> membershipRepository, IRepository<User, string> userRepository, IRepository<Organization, string> organizationRepository, IRepository<Role, string> roleRepository)
    {
        _membershipRepository = membershipRepository;
        _userRepository = userRepository;
        _organizationRepository = organizationRepository;
        _roleRepository = roleRepository;

    }


    public Task<PagedResult<Membership>> Handle(MembershipGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        var query = _membershipRepository.Queryable
            .Include(x => x.User)
            .Include(x => x.Organization)
            .Include(x => x.Roles)
            .AsQueryable();
        
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);
        if (request.UserId != null) query = query.Where(x => x.User.Id == request.UserId);
        if (request.OrganizationId != null) query = query.Where(x => x.Organization.Id == request.OrganizationId);
        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ?
                query.OrderByDescending(order.Substring(1)) :
                query.OrderBy(order);
        return Task.Run(() => query.GetPaged(), cancellationToken);
    }
}

