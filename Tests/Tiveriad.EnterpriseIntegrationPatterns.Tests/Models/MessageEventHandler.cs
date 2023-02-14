using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

namespace Tiveriad.EnterpriseIntegrationPatterns.Tests.Models;

public class MessageEventHandler : IEventHandler<MessageDomainEvent,Guid>
{
    public async Task HandleAsync(MessageDomainEvent @event)
    {
        Console.WriteLine(@event.Message);
    }

    public async Task<bool> ShouldHandleAsync(MessageDomainEvent @event)
    {
        return true;
    }

    public async Task OnErrorAsync(Exception exception, MessageDomainEvent @event)
    {
        
    }
}