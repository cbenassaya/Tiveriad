using Microsoft.AspNetCore.Mvc.Filters;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;
using Tiveriad.Registrations.Core.DomainEvents;

namespace Tiveriad.Registrations.Apis.Filters;

public class RegistrationDomainEventActionFilter : IAsyncActionFilter
{
    private readonly IDomainEventStore _store;
    private readonly IPublisher<RegistrationDomainEvent, string> _registrationDomainEventPublisher;


    public RegistrationDomainEventActionFilter(IDomainEventStore store, IPublisher<RegistrationDomainEvent, string> registrationDomainEventPublisher)
    {
        _store = store;
        _registrationDomainEventPublisher = registrationDomainEventPublisher;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var result = await next();
        if (result.Exception == null || result.ExceptionHandled)
        {
            foreach (var entry in _store.Entries<RegistrationDomainEvent, string>())
                await _registrationDomainEventPublisher.Publish(entry);
        }
    }
}