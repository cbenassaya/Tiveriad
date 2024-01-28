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

public class DeleteRoleByIdRequestHandler : IRequestHandler<DeleteRoleByIdRequest, bool>
{
    private readonly IRepository<Role, string> _roleRepository;
    private readonly IDomainEventStore _store;

    public DeleteRoleByIdRequestHandler(IRepository<Role, string> roleRepository, IDomainEventStore store)
    {
        _roleRepository = roleRepository;
        _store = store;
    }

    public Task<bool> Handle(DeleteRoleByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(() =>
        {
            var query =
                _roleRepository.Queryable
                    .Include(x => x.Client).ThenInclude(x => x.Organization)
                    .Where(x => x.Id == request.Id && x.Client.Id == request.ClientId &&
                                x.Client.Organization.Id == request.OrganizationId);
            var role = query.FirstOrDefault();
            var result = _roleRepository.DeleteOne(role) == 1;
            if (role == null) throw new IdentitiesException(IdentitiesError.BAD_REQUEST);
            if (result)
                _store.Add<RoleDomainEvent, string>(new RoleDomainEvent { Role = role, EventType = "DELETE" });
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}