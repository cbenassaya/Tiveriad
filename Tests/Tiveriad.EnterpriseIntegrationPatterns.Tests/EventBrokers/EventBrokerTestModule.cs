using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.Tests.Models;
using Tiveriad.UnitTests;
using Xunit;

namespace Tiveriad.EnterpriseIntegrationPatterns.Tests.EventBrokers;

public class EventBrokerTestModule : TestBase<EventBrokerStartup>
{
    [Fact]
    public void PubSub()
    {
        var result = GetRequiredService<IEventBroker>()
            .PublishAsync<MessageDomainEvent, Guid>(new MessageDomainEvent() { Message = "Hello World" });
    }
    
    
    [Fact]
    public void StoreAddTest()
    {
        var store = GetRequiredService<IDomainEventStore>();
        store.Add<MessageDomainEvent,Guid>(new MessageDomainEvent() { Message = "Hello World" });
        store.Add<MessageDomainEvent,Guid>(new MessageDomainEvent() { Message = "Hello JD" });
        store.Add<MessageDomainEvent,Guid>(new MessageDomainEvent() { Message = "Hello WD" });
        
        store.Commit();
        Assert.Equal(3,store.GetDomainEvents().Count);
    }
    
    
    [Fact]
    public void StoreCommitTest()
    {
        var store = GetRequiredService<IDomainEventStore>();
        store.Add<MessageDomainEvent,Guid>(new MessageDomainEvent() { Message = "Hello World" });
        store.Add<MessageDomainEvent,Guid>(new MessageDomainEvent() { Message = "Hello JD" });
        store.Commit();
        store.Add<MessageDomainEvent,Guid>(new MessageDomainEvent() { Message = "Hello WD" });
        Assert.Equal(2,store.GetDomainEvents().Count);
    }
}