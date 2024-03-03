
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Queries.OrganizationQueries;

public class OrganizationGetByIdQueryHandler : IRequestHandler<OrganizationGetByIdQueryHandlerRequest, Organization?>
{
    private IRepository<Organization, string> _organizationRepository;
    private IRepository<User, string> _userRepository;
    public OrganizationGetByIdQueryHandler(IRepository<Organization, string> organizationRepository, IRepository<User, string> userRepository)
    {
        _organizationRepository = organizationRepository;
        _userRepository = userRepository;

    }


    public Task<Organization?> Handle(OrganizationGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        var query = _organizationRepository.Queryable.Include(x => x.Owner).AsQueryable();
        query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
    }
}

