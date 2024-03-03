#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.OrganizationQueries;

public class OrganizationGetByIdQueryHandler : IRequestHandler<OrganizationGetByIdQueryHandlerRequest, Organization?>
{
    private readonly IRepository<Organization, string> _organizationRepository;
    private IRepository<User, string> _userRepository;

    public OrganizationGetByIdQueryHandler(IRepository<Organization, string> organizationRepository,
        IRepository<User, string> userRepository)
    {
        _organizationRepository = organizationRepository;
        _userRepository = userRepository;
    }


    public Task<Organization?> Handle(OrganizationGetByIdQueryHandlerRequest request,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _organizationRepository.Queryable.Include(x => x.Owner).AsQueryable();
        query = query.Where(x => x.Id == request.Id);
        query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}