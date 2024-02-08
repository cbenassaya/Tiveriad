using Tiveriad.EnterpriseIntegrationPatterns.InMemory.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;
using Tiveriad.Registrations.Core.DomainEvents;

namespace Tiveriad.Integration.Infrastructure.Workers;

public class RegistrationWorker : IHostedService
{
    private readonly ISubscriber<RegistrationDomainEvent,string> _inMemorySubscriber;

    public RegistrationWorker(ISubscriber<RegistrationDomainEvent,string> inMemorySubscriber)
    {
        _inMemorySubscriber = inMemorySubscriber;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _inMemorySubscriber.Subscribe();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}