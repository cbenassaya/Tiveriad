using MediatR;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Multitenancy.Core.DomainEvents;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.ClientCommands;
public class SaveClientRequestHandler : IRequestHandler<SaveClientRequest, Client>
{
    private readonly IRepository<Client, ObjectId> _clientRepository;
    private readonly IDomainEventStore _store;
    public SaveClientRequestHandler(IRepository<Client, ObjectId> clientRepository, IDomainEventStore store)
    {
        _clientRepository = clientRepository;
        _store = store;
    }

    public Task<Client> Handle(SaveClientRequest request, CancellationToken cancellationToken)
    {
        var query = _clientRepository.Queryable.Where(x => x.Id == request.Client.Id);
        return Task.Run(async () =>
        {
            //<-- START CUSTOM CODE-->
            await _clientRepository.AddOneAsync(request.Client, cancellationToken);
            _store.Add<ClientDomainEvent,string>( new ClientDomainEvent() {Client = request.Client, EventType = "INSERT"});
            return request.Client;
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}