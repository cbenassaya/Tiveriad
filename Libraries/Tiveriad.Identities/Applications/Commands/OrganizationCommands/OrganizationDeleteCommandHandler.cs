
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Identities.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class OrganizationDeleteCommandHandler : IRequestHandler<OrganizationDeleteCommandHandlerRequest, bool>
{
    private IRepository<Organization, string> _organizationRepository;
    private IRepository<User, string> _userRepository;
    public OrganizationDeleteCommandHandler(IRepository<Organization, string> organizationRepository, IRepository<User, string> userRepository)
    {
        _organizationRepository = organizationRepository;
        _userRepository = userRepository;

    }


    public Task<bool> Handle(OrganizationDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
{
    var query = _organizationRepository.Queryable.Include(x => x.Owner).AsQueryable();
    query = query.Where(x => x.Id == request.Id);


    var organization = query.FirstOrDefault();
    if (organization == null) throw new Exception();
    return _organizationRepository.DeleteMany(x => x.Id == request.Id) == 1;
}, cancellationToken);

    }
}

