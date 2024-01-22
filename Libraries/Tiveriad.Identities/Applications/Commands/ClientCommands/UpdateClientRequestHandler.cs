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

public class UpdateClientRequestHandler : IRequestHandler<UpdateClientRequest, Client>
{
    private readonly IRepository<Client, string> _clientRepository;
    private readonly IRepository<Organization, string> _organizationRepository;
    private readonly IDomainEventStore _store;

    public UpdateClientRequestHandler(IRepository<Client, string> clientRepository, IDomainEventStore store, IRepository<Organization, string> organizationRepository)
    {
        _clientRepository = clientRepository;
        _store = store;
        _organizationRepository = organizationRepository;
    }

    public Task<Client> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
    {
        var query = 
            _clientRepository.Queryable
                .Include(x=>x.Organization)
                .Where(x => x.Id == request.Client.Id && x.Organization.Id == request.OrganizationId);
        return Task.Run(async () =>
        {
            //<-- START CUSTOM CODE-->
            var result = query.FirstOrDefault();
            if (result == null) throw new IdentitiesException(IdentitiesError.BAD_REQUEST);
            result.Name = request.Client.Name;
            result.Description = request.Client.Description;
            _store.Add<ClientDomainEvent, string>(new ClientDomainEvent { Client = result, EventType = "UPDATE" });
            return result;
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}