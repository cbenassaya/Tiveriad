using Tiveriad.EnterpriseIntegrationPatterns.InMemory;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory.EventBrokers;
using Tiveriad.Identities.Core.DomainEvents;

namespace Tiveriad.Integration.Infrastructure.Publishers;

public class OrganizationDomainEventPublisher : InMemoryPublisher<OrganizationDomainEvent, string>
{
    public OrganizationDomainEventPublisher(IInMemoryQueueManager queueManager, ILogger<InMemoryPublisher<OrganizationDomainEvent, string>> logger) : base(queueManager, logger)
    {
    }
}