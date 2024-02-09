
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
    public MembershipSaveCommandHandler(IRepository<Membership, string> membershipRepository, IRepository<User, string> userRepository, IRepository<Organization, string> organizationRepository)
    {
        _membershipRepository = membershipRepository;
        _userRepository = userRepository;
        _organizationRepository = organizationRepository;

    }


    public Task<Membership> Handle(MembershipSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            await _membershipRepository.AddOneAsync(request.Membership, cancellationToken);
            return request.Membership;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

