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
}