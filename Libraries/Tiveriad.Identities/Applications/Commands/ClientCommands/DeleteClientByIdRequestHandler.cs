#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Core.Exceptions;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.ClientCommands;

public class DeleteClientByIdRequestHandler : IRequestHandler<DeleteClientByIdRequest, bool>
{
    private readonly IRepository<Client, string> _clientRepository;

    private readonly IDomainEventStore _store;

    public DeleteClientByIdRequestHandler(IRepository<Client, string> clientRepository, IDomainEventStore store)
    {
        _clientRepository = clientRepository;
        _store = store;
    }

    public Task<bool> Handle(DeleteClientByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(() =>
        {
            var query =
                _clientRepository.Queryable
                    .Include(x => x.Organization)
                    .Where(x => x.Id == request.Id && x.Organization.Id == request.OrganizationId);
            var client = query.FirstOrDefault();
            if (client == null) throw new IdentitiesException(IdentitiesError.BAD_REQUEST);
            var result = _clientRepository.DeleteOne(client) == 1;
            if (result)
                _store.Add<ClientDomainEvent, string>(new ClientDomainEvent { Client = client, EventType = "DELETE" });
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}