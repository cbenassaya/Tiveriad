using MediatR;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Multitenancy.Core.DomainEvents;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.ClientCommands;
public class DeleteClientByIdRequestHandler : IRequestHandler<DeleteClientByIdRequest, bool>
{
    private readonly IRepository<Client, ObjectId> _clientRepository;
    private readonly IDomainEventStore _store;
    public DeleteClientByIdRequestHandler(IRepository<Client, ObjectId> clientRepository, IDomainEventStore store)
    {
        _clientRepository = clientRepository;
        _store = store;
    }

    public Task<bool> Handle(DeleteClientByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(() =>
        {
            var client = _clientRepository.GetById(request.Id);
            var result =  _clientRepository.DeleteOne(client) == 1;
            if (result)
                _store.Add<ClientDomainEvent,string>( new ClientDomainEvent() {Client = client, EventType = "DELETE"});
            return result;
        }, cancellationToken);
    //<-- END CUSTOM CODE-->
    }
}