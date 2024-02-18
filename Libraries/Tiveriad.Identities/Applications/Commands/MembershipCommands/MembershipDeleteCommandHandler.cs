#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public class MembershipDeleteCommandHandler : IRequestHandler<MembershipDeleteCommandHandlerRequest, bool>
{
    private readonly IRepository<Membership, string> _membershipRepository;
    private IRepository<Organization, string> _organizationRepository;
    private IRepository<Role, string> _roleRepository;
    private IRepository<User, string> _userRepository;

    public MembershipDeleteCommandHandler(IRepository<Membership, string> membershipRepository,
        IRepository<User, string> userRepository, IRepository<Organization, string> organizationRepository,
        IRepository<Role, string> roleRepository)
    {
        _membershipRepository = membershipRepository;
        _userRepository = userRepository;
        _organizationRepository = organizationRepository;
        _roleRepository = roleRepository;
    }


    public Task<bool> Handle(MembershipDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            //<-- START CUSTOM CODE-->
            var query = _membershipRepository.Queryable.Include(x => x.User)
                .Include(x => x.Organization).AsQueryable();
            query = query.Where(x => x.Id == request.Id);


            var membership = query.FirstOrDefault();
            if (membership == null) throw new Exception();
            return _membershipRepository.DeleteMany(x => x.Id == request.Id) == 1;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}