#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public class MembershipSaveCommandHandler : IRequestHandler<MembershipSaveCommandHandlerRequest, Membership>
{
    private readonly IRepository<Membership, string> _membershipRepository;
    private IRepository<Organization, string> _organizationRepository;
    private IRepository<Role, string> _roleRepository;
    private IRepository<User, string> _userRepository;

    public MembershipSaveCommandHandler(IRepository<Membership, string> membershipRepository,
        IRepository<User, string> userRepository, IRepository<Organization, string> organizationRepository,
        IRepository<Role, string> roleRepository)
    {
        _membershipRepository = membershipRepository;
        _userRepository = userRepository;
        _organizationRepository = organizationRepository;
        _roleRepository = roleRepository;
    }


    public Task<Membership> Handle(MembershipSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            request.Membership.State = MembershipState.Pending;
            if (request.Membership.User != null)
                request.Membership.User = await _userRepository.GetByIdAsync(request.Membership.User.Id, cancellationToken);
            if (request.Membership.Organization != null)
                request.Membership.Organization =
                    await _organizationRepository.GetByIdAsync(request.Membership.Organization.Id, cancellationToken);
            request.Membership.Roles = request.Membership.Roles.Select( x => _roleRepository.GetById(x.Id)).ToList();
            
            await _membershipRepository.AddOneAsync(request.Membership, cancellationToken);
            return request.Membership;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}