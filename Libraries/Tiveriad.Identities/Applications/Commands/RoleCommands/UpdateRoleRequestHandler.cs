#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Core.Exceptions;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public class UpdateRoleRequestHandler : IRequestHandler<UpdateRoleRequest, Role>
{
    private readonly IRepository<Role, string> _roleRepository;
    private readonly IDomainEventStore _store;

    public UpdateRoleRequestHandler(IRepository<Role, string> roleRepository, IDomainEventStore store)
    {
        _roleRepository = roleRepository;
        _store = store;
    }

    public Task<Role> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
    {
        var query = 
            _roleRepository.Queryable
                .Include(x=>x.Client).ThenInclude(x=>x.Organization)
                .Where(x => x.Id == request.Role.Id && x.Client.Id == request.ClientId&& x.Client.Organization.Id == request.OrganizationId);
        var result = query.First();
        if (result == null) throw new IdentitiesException(IdentitiesError.BAD_REQUEST);
        return Task.Run( () =>
        {
            //<-- START CUSTOM CODE-->
            //<-- START CUSTOM CODE-->
            result.Name = request.Role.Name;
            result.Description = request.Role.Description;
            result.Code = request.Role.Code;
            _store.Add<RoleDomainEvent, string>(new RoleDomainEvent { Role = result, EventType = "UPDATE" });
            return result;
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}