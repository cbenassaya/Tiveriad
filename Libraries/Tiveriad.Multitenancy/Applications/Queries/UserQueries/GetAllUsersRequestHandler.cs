using MediatR;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Queries.UserQueries;
public class GetAllUsersRequestHandler : IRequestHandler<GetAllUsersRequest, IEnumerable<User>>
{
    private readonly IRepository<Membership, ObjectId> _membershipRepository;
    private readonly IRepository<User, ObjectId>  _userRepository;
    private readonly IRepository<Organization,ObjectId> _organizationRepository;
    
    public GetAllUsersRequestHandler(IRepository<Membership, ObjectId> membershipRepository, IRepository<User, ObjectId> userRepository, IRepository<Organization, ObjectId> organizationRepository)
    {
        _membershipRepository = membershipRepository;
        _userRepository = userRepository;
        _organizationRepository = organizationRepository;
    }

    public Task<IEnumerable<User>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        var membershipQueryable = _membershipRepository.Queryable;
        membershipQueryable = membershipQueryable.Where(x => x.OrganizationId.Equals(request.OrganizationId));
        if (request.States != null && request.States.Any())
        {
            var states = Enum.GetValues<MembershipState>().Where(x => request.States.Contains(x.ToString())).ToList();
            membershipQueryable = membershipQueryable.Where(x => states.Contains(x.State));
        }
        
        
        var userQueryable = _userRepository.Queryable;
        if (request.Id.HasValue)
            userQueryable = userQueryable.Where(x => x.Id.Equals(request.Id));
        if (!string.IsNullOrWhiteSpace(request.Email))
            userQueryable = userQueryable.Where(x => x.Email == request.Email);
        if (!string.IsNullOrWhiteSpace(request.Username))
            userQueryable = userQueryable.Where(x => x.Username == request.Username);
        if (!string.IsNullOrWhiteSpace(request.Firstname))
            userQueryable = userQueryable.Where(x => x.Firstname == request.Firstname);
        if (!string.IsNullOrWhiteSpace(request.Lastname))
            userQueryable = userQueryable.Where(x => x.Lastname == request.Lastname);
        if (!string.IsNullOrWhiteSpace(request.Q))
        {
            userQueryable = userQueryable.Where(x => x.Email.Contains(request.Q) || x.Username.Contains(request.Q) || x.Firstname.Contains(request.Q) || x.Lastname.Contains(request.Q));
        }   
        
        var query = from membership in membershipQueryable
            join user in userQueryable on membership.UserId equals user.Id into joined  select joined.FirstOrDefault();

        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-")
                    ? query.OrderByDescending(order.Substring(1))
                    : query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
        {
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        }
        return Task.Run(() => query.ToList().AsEnumerable(), cancellationToken);
    //<-- END CUSTOM CODE-->
    }
}