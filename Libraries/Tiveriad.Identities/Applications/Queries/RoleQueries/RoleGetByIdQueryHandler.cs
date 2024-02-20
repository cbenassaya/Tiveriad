#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RoleQueries;

public class RoleGetByIdQueryHandler : IRequestHandler<RoleGetByIdQueryHandlerRequest, Role?>
{
    private IRepository<Realm, string> _realmRepository;
    private readonly IRepository<Role, string> _roleRepository;

    public RoleGetByIdQueryHandler(IRepository<Role, string> roleRepository, IRepository<Realm, string> realmRepository)
    {
        _roleRepository = roleRepository;
        _realmRepository = realmRepository;
    }


    public Task<Role?> Handle(RoleGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _roleRepository.Queryable.Include(x => x.Organization).AsQueryable();
        query = query.Where(x => x.Id == request.Id);
        query = query.Where(x => x.Organization.Id == request.OrganizationId);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}