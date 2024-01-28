#region

using MediatR;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.ClientCommands;

public class SaveClientRequestHandler : IRequestHandler<SaveClientRequest, Client>
{
    private readonly IRepository<Client, string> _clientRepository;
    private readonly IRepository<Organization, string> _organizationRepository;
    private readonly IDomainEventStore _store;

    public SaveClientRequestHandler(IRepository<Client, string> clientRepository, IDomainEventStore store,
        IRepository<Organization, string> organizationRepository)
    {
        _clientRepository = clientRepository;
        _store = store;
        _organizationRepository = organizationRepository;
    }

    public Task<Client> Handle(SaveClientRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            //<-- START CUSTOM CODE-->
            await _clientRepository.AddOneAsync(request.Client, cancellationToken);
            _store.Add<ClientDomainEvent, string>(new ClientDomainEvent
                { Client = request.Client, EventType = "INSERT" });
            return request.Client;
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}