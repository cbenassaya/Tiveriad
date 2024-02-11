using Microsoft.AspNetCore.Mvc.Filters;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;
using Tiveriad.Registrations.Core.DomainEvents;

namespace Tiveriad.Integration.Filters;

public class DomainEventActionFilter : IAsyncActionFilter
{
    private readonly IDomainEventStore _store;
    private readonly IPublisher<OnSaveRegistrationDomainEvent, string> _onSaveRegistrationDomainEventPublisher;

    public DomainEventActionFilter( IPublisher<OnSaveRegistrationDomainEvent, string> onSaveRegistrationDomainEventPublisher, IDomainEventStore store)
    {
        _onSaveRegistrationDomainEventPublisher = onSaveRegistrationDomainEventPublisher;
        _store = store;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var result = await next();
        if (result.Exception == null || result.ExceptionHandled)
        {
            foreach (var entry in _store.Entries<OnSaveRegistrationDomainEvent, string>())
                await _onSaveRegistrationDomainEventPublisher.Publish(entry);
            
        }
    }
}