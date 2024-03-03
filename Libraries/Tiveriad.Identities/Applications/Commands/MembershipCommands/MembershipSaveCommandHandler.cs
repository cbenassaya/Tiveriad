
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public class MembershipSaveCommandHandler : IRequestHandler<MembershipSaveCommandHandlerRequest, Membership>
{
    private IRepository<Membership, string> _membershipRepository;
    private IRepository<User, string> _userRepository;
    private IRepository<Organization, string> _organizationRepository;
    private IRepository<Role, string> _roleRepository;
    public MembershipSaveCommandHandler(IRepository<Membership, string> membershipRepository, IRepository<User, string> userRepository, IRepository<Organization, string> organizationRepository, IRepository<Role, string> roleRepository)
    {
        _membershipRepository = membershipRepository;
        _userRepository = userRepository;
        _organizationRepository = organizationRepository;
        _roleRepository = roleRepository;

    }


    public Task<Membership> Handle(MembershipSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            if (request.Membership.User != null) request.Membership.User = await _userRepository.GetByIdAsync(request.Membership.User.Id, cancellationToken);
            if (request.Membership.Organization != null) request.Membership.Organization = await _organizationRepository.GetByIdAsync(request.Membership.Organization.Id, cancellationToken); if (request.Membership.Roles != null) request.Membership.Roles = request.Membership.Roles.Select(x => _roleRepository.GetById(x.Id)).ToList();
            request.Membership.State = MembershipState.Pending;
            request.Membership.Default = true;
            // The last one is the default
            _membershipRepository.Find(x=> x.User.Id == request.Membership.User.Id).ToList()
                .ForEach(x => x.Default = false
                );
            
            await _membershipRepository.AddOneAsync(request.Membership, cancellationToken);
            return request.Membership;
        }, cancellationToken);
    }
}

