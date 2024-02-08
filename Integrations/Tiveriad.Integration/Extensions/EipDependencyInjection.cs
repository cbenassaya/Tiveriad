using Tiveriad.Core.Abstractions.Services;
using Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory;
using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.Identities.Core.Services;
using Tiveriad.Integration.Infrastructure.Publishers;
using Tiveriad.Integration.Infrastructure.Services;
using Tiveriad.Integration.Infrastructure.Subscribers;
using Tiveriad.Integration.Infrastructure.Workers;
using Tiveriad.Registrations.Core.DomainEvents;
using Tiveriad.ServiceResolvers;
using Tiveriad.ServiceResolvers.Microsoft.DependencyInjection;

namespace Tiveriad.Integration.Extensions;

public static class EipDependencyInjection
{
    

    public static IServiceCollection AddPublisher(this IServiceCollection services)
    {
        services.AddTransient<ICurrentUserService, CurrentUserService>();
        services.AddSingleton<IPublisher<UserDomainEvent, string>,UserDomainEventPublisher>();
        services.AddSingleton<IPublisher<OrganizationDomainEvent, string>,OrganizationDomainEventPublisher>();
        services.AddSingleton<IPublisher<MembershipDomainEvent, string>,MembershipDomainEventPublisher>();
        services.AddSingleton<IPublisher<RegistrationDomainEvent, string>,RegistrationDomainEventPublisher>();
        services.AddSingleton<ISubscriber<RegistrationDomainEvent, string>,RegistrationDomainEventSubscriber>();
        return services;
    }
    
    public static IServiceCollection AddBroker(this IServiceCollection services)
    {
        services.AddSingleton<IInMemoryQueueManager, InMemoryQueueManager>();
        services.AddSingleton<IServiceResolver, DependencyInjectionServiceResolver>();
        services.AddTiveriadEip(typeof(UserDomainEvent).Assembly);
        services.AddScoped<IDomainEventStore, DomainEventStore>();
        return services;
    }

    public static IServiceCollection AddWorkers(this IServiceCollection services)
    {
        services.AddHostedService<RegistrationWorker>();
        return services;
    }
}