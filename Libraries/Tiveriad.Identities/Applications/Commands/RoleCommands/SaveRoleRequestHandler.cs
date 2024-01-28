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

public class SaveRoleRequestHandler : IRequestHandler<SaveRoleRequest, Role>
{
    private readonly IRepository<Client, string> _clientRepository;
    private readonly IRepository<Role, string> _roleRepository;
    private readonly IDomainEventStore _store;

    public SaveRoleRequestHandler(IRepository<Role, string> roleRepository, IDomainEventStore store,
        IRepository<Client, string> clientRepository)
    {
        _roleRepository = roleRepository;
        _store = store;
        _clientRepository = clientRepository;
    }

    public Task<Role> Handle(SaveRoleRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            //<-- START CUSTOM CODE-->
            var client =
                _clientRepository.Queryable
                    .Include(x => x.Organization).FirstOrDefault(x =>
                        x.Id == request.ClientId && x.Organization.Id == request.OrganizationId);

            if (client == null) throw new IdentitiesException(IdentitiesError.BAD_REQUEST);
            request.Role.Client = client;
            await _roleRepository.AddOneAsync(request.Role, cancellationToken);
            _store.Add<RoleDomainEvent, string>(new RoleDomainEvent
                { Role = request.Role, EventType = "INSERT" });
            return request.Role;
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}