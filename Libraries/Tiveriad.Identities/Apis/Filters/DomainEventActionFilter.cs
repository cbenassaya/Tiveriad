#region

using Microsoft.AspNetCore.Mvc.Filters;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.Multitenancy.Apis.Filters;

#endregion

namespace Tiveriad.Identities.Apis.Filters;

public class DomainEventActionFilter : IAsyncActionFilter
{
    private readonly IPublisher<MembershipDomainEvent, string> _membershipDomainEventPublisher;
    private readonly IPublisher<OrganizationDomainEvent, string> _organizationDomainEventPublisher;
    private readonly IDomainEventStore _store;
    private readonly IPublisher<UserDomainEvent, string> _userDomainEventPublisher;

    public DomainEventActionFilter(IDomainEventStore store,
        IPublisher<UserDomainEvent, string> userDomainEventPublisher,
        IPublisher<MembershipDomainEvent, string> membershipDomainEventPublisher,
        IPublisher<OrganizationDomainEvent, string> organizationDomainEventPublisher)
    {
        _store = store;
        _userDomainEventPublisher = userDomainEventPublisher;
        _membershipDomainEventPublisher = membershipDomainEventPublisher;
        _organizationDomainEventPublisher = organizationDomainEventPublisher;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var result = await next();
        if (result.Exception == null || result.ExceptionHandled)
        {
            _store.Commit();

            foreach (var entry in _store.Entries<UserDomainEvent, string>())
                await _userDomainEventPublisher.Publish(entry);

            foreach (var entry in _store.Entries<MembershipDomainEvent, string>())
                await _membershipDomainEventPublisher.Publish(entry);

            foreach (var entry in _store.Entries<OrganizationDomainEvent, string>())
                await _organizationDomainEventPublisher.Publish(entry);
        }
    }
}