#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public class MembershipUpdateCommandHandler : IRequestHandler<MembershipUpdateCommandHandlerRequest, Membership>
{
    private readonly IRepository<Membership, string> _membershipRepository;
    private readonly IRepository<Organization, string> _organizationRepository;
    private IRepository<Role, string> _roleRepository;
    private readonly IRepository<User, string> _userRepository;

    public MembershipUpdateCommandHandler(IRepository<Membership, string> membershipRepository,
        IRepository<User, string> userRepository, IRepository<Organization, string> organizationRepository,
        IRepository<Role, string> roleRepository)
    {
        _membershipRepository = membershipRepository;
        _userRepository = userRepository;
        _organizationRepository = organizationRepository;
        _roleRepository = roleRepository;
    }


    public Task<Membership> Handle(MembershipUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _membershipRepository.Queryable.Include(x => x.User)
                .Include(x => x.Organization).AsQueryable();
    
            query = query.Where(x => x.Id == request.Id);

            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();
            result.Properties = request.Membership.Properties;
            request.Membership.Roles = request.Membership.Roles.Select( x => _roleRepository.GetById(x.Id)).ToList();
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}