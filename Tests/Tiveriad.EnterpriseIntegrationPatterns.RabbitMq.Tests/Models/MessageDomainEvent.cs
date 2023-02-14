using Microsoft.Extensions.Logging;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

namespace Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.Tests.Models;

public class MessageDomainEvent : IDomainEvent<Guid>{
    
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.Now;
    public Guid Id { get; } = Guid.NewGuid();
    public string Message { get; set; }
}

