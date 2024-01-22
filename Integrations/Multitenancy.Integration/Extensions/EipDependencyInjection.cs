using Multitenancy.Integration.Infrastructure.Publishers;
using Multitenancy.Integration.Infrastructure.Services;
using RabbitMQ.Client;
using Tiveriad.Connections;
using Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.Identities.Core.Services;
using Tiveriad.ServiceResolvers;
namespace Multitenancy.Integration.Extensions;
public static class EipDependencyInjection
{
    

    public static IServiceCollection AddPublisher(this IServiceCollection services)
    {
        services.AddTransient<ICurrentUserService, CurrentUserService>();
        services.AddSingleton<IPublisher<UserDomainEvent, string>>(sp => new UserDomainEventPublisher(
            sp.GetRequiredService<IConnectionFactory<IConnection>>(),
            sp.GetRequiredService<IRabbitMqConnectionConfiguration>(),
            typeof(UserDomainEvent).FullName,
            sp.GetRequiredService<ILogger<UserDomainEventPublisher>>()));
        services.AddSingleton<IPublisher<OrganizationDomainEvent, string>>(sp => new OrganizationDomainEventPublisher(
            sp.GetRequiredService<IConnectionFactory<IConnection>>(),
            sp.GetRequiredService<IRabbitMqConnectionConfiguration>(),
            typeof(OrganizationDomainEvent).FullName,
            sp.GetRequiredService<ILogger<OrganizationDomainEventPublisher>>()));
        services.AddSingleton<IPublisher<MembershipDomainEvent, string>>(sp => new MembershipDomainEventPublisher(
            sp.GetRequiredService<IConnectionFactory<IConnection>>(),
            sp.GetRequiredService<IRabbitMqConnectionConfiguration>(),
            typeof(MembershipDomainEvent).FullName,
            sp.GetRequiredService<ILogger<MembershipDomainEventPublisher>>()));
        
        return services;
    }
}