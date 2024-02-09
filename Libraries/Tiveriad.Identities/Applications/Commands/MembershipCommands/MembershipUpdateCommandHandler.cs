
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public class MembershipUpdateCommandHandler : IRequestHandler<MembershipUpdateCommandHandlerRequest, Membership>
{
    private IRepository<Membership, string> _membershipRepository;
    private IRepository<User, string> _userRepository;
    private IRepository<Organization, string> _organizationRepository;
    public MembershipUpdateCommandHandler(IRepository<Membership, string> membershipRepository, IRepository<User, string> userRepository, IRepository<Organization, string> organizationRepository)
    {
        _membershipRepository = membershipRepository;
        _userRepository = userRepository;
        _organizationRepository = organizationRepository;

    }


    public Task<Membership> Handle(MembershipUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _membershipRepository.Queryable.Include(x => x.User)
    .Include(x => x.Organization).AsQueryable();



            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.State = request.Membership.State;
            result.Properties = request.Membership.Properties;
            if (request.Membership.User != null) result.User = await _userRepository.GetByIdAsync(request.Membership.User.Id, cancellationToken);
            if (request.Membership.Organization != null) result.Organization = await _organizationRepository.GetByIdAsync(request.Membership.Organization.Id, cancellationToken);
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

