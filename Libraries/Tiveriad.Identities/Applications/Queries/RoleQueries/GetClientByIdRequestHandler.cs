#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RoleQueries;

public class GetRoleByIdRequestHandler : IRequestHandler<GetRoleByIdRequest, Role?>
{
    private readonly IRepository<Role, string> _roleRepository;

    public GetRoleByIdRequestHandler(IRepository<Role, string> roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public Task<Role?> Handle(GetRoleByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _roleRepository.Queryable
            .Include(x => x.Client).ThenInclude(x => x.Organization)
            .Where(  x => x.Id == request.Id &&  x.Client.Id == request.ClientId && x.Client.Organization.Id == request.OrganizationId);
        //<-- END CUSTOM CODE-->
        return Task.Run(() => query.FirstOrDefault(), cancellationToken);
    }
}