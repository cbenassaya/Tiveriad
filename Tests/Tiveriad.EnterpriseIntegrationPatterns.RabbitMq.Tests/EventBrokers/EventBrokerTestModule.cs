using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.Tests.Models;
using Tiveriad.UnitTests;
using Xunit;

namespace Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.Tests.EventBrokers;

public class EventBrokerTestModule : TestBase<EventBrokerStartup>
{
    //[Fact]
    public async void PubSub()
    {
        var publisher = GetRequiredService<IPublisher<MessageDomainEvent, Guid>>();
        
        var subscriber = GetRequiredService<ISubscriber<MessageDomainEvent, Guid>>();
        var messageDomainEventSubscriber = (MessageDomainEventSubscriber) subscriber ;

        var publishTask = Task.Factory.StartNew(() =>
        {
            for (var i = 0; i < 10; i++)
            {
                publisher.Publish(new MessageDomainEvent() { Message = Guid.NewGuid().ToString() });
                Task.Delay(TimeSpan.FromMilliseconds(500));
            }
        });

        var subscribeTask = Task.Factory.StartNew(() =>
        {
            while (messageDomainEventSubscriber.Count < 10)
            {
                Task.Delay(TimeSpan.FromMilliseconds(500));
            }
        });
        Task.WaitAll(publishTask, subscribeTask);
        Assert.True(messageDomainEventSubscriber.Count==10);
    }
}