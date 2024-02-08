#region

#endregion

using Microsoft.Extensions.Logging;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory.EventBrokers;

namespace Tiveriad.EnterpriseIntegrationPatterns.InMemory.Tests.Models;

public class MessageDomainEventPublisher : InMemoryPublisher<MessageDomainEvent, Guid>
{
    public MessageDomainEventPublisher(IInMemoryQueueManager queueManager, ILogger<InMemoryPublisher<MessageDomainEvent, Guid>> logger) : base(queueManager, logger)
    {
    }
}