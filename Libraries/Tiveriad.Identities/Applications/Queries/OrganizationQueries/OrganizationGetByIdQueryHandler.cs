
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
    private IRepository<TimeArea, string> _timeAreaRepository;
    public OrganizationGetByIdQueryHandler(IRepository<Organization, string> organizationRepository, IRepository<User, string> userRepository, IRepository<TimeArea, string> timeAreaRepository)
    {
        _organizationRepository = organizationRepository;
        _userRepository = userRepository;
        _timeAreaRepository = timeAreaRepository;

    }


    public Task<Organization?> Handle(OrganizationGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _organizationRepository.Queryable.Include(x => x.Owner)
        .Include(x => x.TimeArea).AsQueryable();
        query = query.Where(x => x.Id == request.Id); query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

