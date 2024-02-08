#region

#endregion

using Microsoft.Extensions.Logging;
using Tiveriad.Connections;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory.EventBrokers;

namespace Tiveriad.EnterpriseIntegrationPatterns.InMemory.Tests.Models;

public class MessageDomainEventSubscriber : InMemorySubscriber<MessageDomainEvent, Guid>
{

    public int Count { get; private set; }

    public override Task OnError(Exception exception)
    {
        //Do Nothing
        return Task.CompletedTask;
    }

    public override Task DoHandle(MessageDomainEvent @event)
    {
        Count++;
        return Task.CompletedTask;
    }


    public MessageDomainEventSubscriber(IInMemoryQueueManager queueManager, ILogger<InMemorySubscriber<MessageDomainEvent, Guid>> logger) : base(queueManager, logger)
    {
    }
}