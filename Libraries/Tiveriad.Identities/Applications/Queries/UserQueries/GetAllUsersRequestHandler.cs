#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public class GetAllUsersRequestHandler : IRequestHandler<GetAllUsersRequest, IEnumerable<User>>
{
    private readonly IRepository<Membership, string> _membershipRepository;

    public GetAllUsersRequestHandler(IRepository<Membership, string> membershipRepository)
    {
        _membershipRepository = membershipRepository;
    }

    public Task<IEnumerable<User>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _membershipRepository.Queryable.Include(x => x.User).Include(x => x.Organization).AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Id))
            query = query.Where(x => x.User.Id == request.Id);
        if (!string.IsNullOrWhiteSpace(request.Email))
            query = query.Where(x => x.User.Email == request.Email);
        if (!string.IsNullOrWhiteSpace(request.Username))
            query = query.Where(x => x.User.Username == request.Username);
        if (!string.IsNullOrWhiteSpace(request.Firstname))
            query = query.Where(x => x.User.Firstname == request.Firstname);
        if (!string.IsNullOrWhiteSpace(request.Lastname))
            query = query.Where(x => x.User.Lastname == request.Lastname);
        if (request.States != null && request.States.Any())
        {
            var states = Enum.GetValues<MembershipState>().Where(x => request.States.Contains(x.ToString())).ToList();
            query = query.Where(x => states.Contains(x.State));
        }

        if (!string.IsNullOrWhiteSpace(request.Q))
            query = query.Where(x =>
                x.User.Email.Contains(request.Q) || x.User.Username.Contains(request.Q) ||
                x.User.Firstname.Contains(request.Q) || x.User.Lastname.Contains(request.Q));
        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ? query.OrderByDescending(order.Substring(1)) : query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList().Select(x => x.User).AsEnumerable(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}