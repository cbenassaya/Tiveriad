#region

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tiveriad.Connections;
using Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory.Tests.Models;
using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;
using Tiveriad.ServiceResolvers;
using Tiveriad.ServiceResolvers.Microsoft.DependencyInjection;
using Tiveriad.UnitTests;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.InMemory.Tests.EventBrokers;

public class EventBrokerStartup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services.AddLogging(config => { config.SetMinimumLevel(LogLevel.Trace); });
        services.AddScoped<IServiceResolver, DependencyInjectionServiceResolver>();
        services.AddTiveriadEip(GetType().Assembly);
        services.AddSingleton<IInMemoryQueueManager, InMemoryQueueManager>();

        services.AddScoped<ISubscriber<MessageDomainEvent, Guid>, MessageDomainEventSubscriber>();
        services.AddScoped<IPublisher<MessageDomainEvent, Guid>, MessageDomainEventPublisher>();
    }
}