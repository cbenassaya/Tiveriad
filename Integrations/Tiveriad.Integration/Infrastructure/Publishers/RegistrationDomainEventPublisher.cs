using Tiveriad.EnterpriseIntegrationPatterns.InMemory;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory.EventBrokers;

using Tiveriad.Registrations.Core.DomainEvents;

namespace Tiveriad.Integration.Infrastructure.Publishers;


public class RegistrationDomainEventPublisher : InMemoryPublisher<RegistrationDomainEvent, string>
{
    public RegistrationDomainEventPublisher(IInMemoryQueueManager queueManager, ILogger<InMemoryPublisher<RegistrationDomainEvent, string>> logger) : base(queueManager, logger)
    {
    }
}