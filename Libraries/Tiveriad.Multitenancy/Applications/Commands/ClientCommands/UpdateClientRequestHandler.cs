using MediatR;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Multitenancy.Core.DomainEvents;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Multitenancy.Core.Exceptions;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.ClientCommands;

public class UpdateClientRequestHandler : IRequestHandler<UpdateClientRequest, Client>
{
    private readonly IRepository<Client, ObjectId> _clientRepository;
    private readonly IDomainEventStore _store;
    public UpdateClientRequestHandler(IRepository<Client, ObjectId> clientRepository, IDomainEventStore store)
    {
        _clientRepository = clientRepository;
        _store = store;
    }

    public Task<Client> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
    {
        var query = _clientRepository.Queryable.Where(x => x.Id == request.Client.Id);
        return Task.Run(async () =>
        {
            //<-- START CUSTOM CODE-->
            var result = query.ToList().FirstOrDefault();
            if (result == null)
            {
                throw new MultiTenancyException(MultiTenancyError.BAD_REQUEST);
            }
            else
            {
                result.Name = request.Client.Name;
                result.Description = request.Client.Description;
                _store.Add<ClientDomainEvent,string>( new ClientDomainEvent() {Client = result, EventType = "UPDATE"});
                return result;
            }
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}