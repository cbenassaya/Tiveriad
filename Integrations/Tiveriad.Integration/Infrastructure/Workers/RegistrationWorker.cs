#region

using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;
using Tiveriad.Registrations.Core.DomainEvents;

#endregion

namespace Tiveriad.Integration.Infrastructure.Workers;

public class RegistrationWorker : IHostedService
{
    private readonly ISubscriber<OnSaveRegistrationDomainEvent, string> _inMemorySubscriber;

    public RegistrationWorker(ISubscriber<OnSaveRegistrationDomainEvent, string> inMemorySubscriber)
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