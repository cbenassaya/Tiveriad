
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Identities.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public class MembershipDeleteCommandHandler : IRequestHandler<MembershipDeleteCommandHandlerRequest, bool>
{
    private IRepository<Membership, string> _membershipRepository;
    private IRepository<User, string> _userRepository;
    private IRepository<Organization, string> _organizationRepository;
    private IRepository<Role, string> _roleRepository;
    public MembershipDeleteCommandHandler(IRepository<Membership, string> membershipRepository, IRepository<User, string> userRepository, IRepository<Organization, string> organizationRepository, IRepository<Role, string> roleRepository)
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
    var query = _membershipRepository.Queryable.Include(x => x.User)
    .Include(x => x.Organization).AsQueryable();
    query = query.Where(x => x.Id == request.Id);


    var membership = query.FirstOrDefault();
    if (membership == null) throw new Exception();
    return _membershipRepository.DeleteMany(x => x.Id == request.Id) == 1;
}, cancellationToken);

    }
}

