
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Queries.MembershipQueries;

public class MembershipGetByIdQueryHandler : IRequestHandler<MembershipGetByIdQueryHandlerRequest, Membership?>
{
    private IRepository<Membership, string> _membershipRepository;
    private IRepository<User, string> _userRepository;
    private IRepository<Organization, string> _organizationRepository;
    private IRepository<Role, string> _roleRepository;
    public MembershipGetByIdQueryHandler(IRepository<Membership, string> membershipRepository, IRepository<User, string> userRepository, IRepository<Organization, string> organizationRepository, IRepository<Role, string> roleRepository)
    {
        _membershipRepository = membershipRepository;
        _userRepository = userRepository;
        _organizationRepository = organizationRepository;
        _roleRepository = roleRepository;

    }


    public Task<Membership?> Handle(MembershipGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        var query = _membershipRepository.Queryable.Include(x => x.User)
        .Include(x => x.Organization).AsQueryable();
        query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
    }
}

