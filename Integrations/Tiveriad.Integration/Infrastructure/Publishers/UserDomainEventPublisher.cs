
using Tiveriad.EnterpriseIntegrationPatterns.InMemory;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory.EventBrokers;
using Tiveriad.Identities.Core.DomainEvents;

namespace Tiveriad.Integration.Infrastructure.Publishers;


public class UserDomainEventPublisher : InMemoryPublisher<UserDomainEvent, string>
{
    public UserDomainEventPublisher(IInMemoryQueueManager queueManager, ILogger<InMemoryPublisher<UserDomainEvent, string>> logger) : base(queueManager, logger)
    {
    }
}