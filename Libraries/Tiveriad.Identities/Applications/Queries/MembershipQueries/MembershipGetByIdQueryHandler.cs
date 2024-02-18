#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.MembershipQueries;

public class MembershipGetByIdQueryHandler : IRequestHandler<MembershipGetByIdQueryHandlerRequest, Membership?>
{
    private readonly IRepository<Membership, string> _membershipRepository;
    private IRepository<Organization, string> _organizationRepository;
    private IRepository<Role, string> _roleRepository;
    private IRepository<User, string> _userRepository;

    public MembershipGetByIdQueryHandler(IRepository<Membership, string> membershipRepository,
        IRepository<User, string> userRepository, IRepository<Organization, string> organizationRepository,
        IRepository<Role, string> roleRepository)
    {
        _membershipRepository = membershipRepository;
        _userRepository = userRepository;
        _organizationRepository = organizationRepository;
        _roleRepository = roleRepository;
    }


    public Task<Membership?> Handle(MembershipGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _membershipRepository.Queryable.Include(x => x.User)
            .Include(x => x.Organization).AsQueryable();
        query = query.Where(x => x.Id == request.Id);
        query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}