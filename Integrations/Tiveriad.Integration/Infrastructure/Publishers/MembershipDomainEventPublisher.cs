using Tiveriad.Connections;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory.EventBrokers;
using Tiveriad.Identities.Core.DomainEvents;

namespace Tiveriad.Integration.Infrastructure.Publishers;

public class MembershipDomainEventPublisher: InMemoryPublisher<MembershipDomainEvent, string>
{
    public MembershipDomainEventPublisher(IInMemoryQueueManager queueManager, ILogger<InMemoryPublisher<MembershipDomainEvent, string>> logger) : base(queueManager, logger)
    {
    }
}