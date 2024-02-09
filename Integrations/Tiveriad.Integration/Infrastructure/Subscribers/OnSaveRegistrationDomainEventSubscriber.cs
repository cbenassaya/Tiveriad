#region

using MediatR;
using RabbitMQ.Client;
using Tiveriad.Connections;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.EventBrokers;
using Tiveriad.Identities.Applications.Commands.OrganizationCommands;
using Tiveriad.Identities.Applications.Commands.UserCommands;
using Tiveriad.Identities.Applications.Queries.UserQueries;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Integration.Persistence;
using Tiveriad.Registrations.Core.DomainEvents;

#endregion

namespace Tiveriad.Integration.Infrastructure.Subscribers;

public class OnSaveRegistrationDomainEventSubscriber : RabbitMqSubscriber<OnSaveRegistrationDomainEvent, string>
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private ILogger<OnSaveRegistrationDomainEventSubscriber> _logger;

    public OnSaveRegistrationDomainEventSubscriber(
        IConnectionFactory<IConnection> connectionFactory,
        IRabbitMqConnectionConfiguration configuration,
        IServiceScopeFactory serviceScopeFactory,
        ILogger<OnSaveRegistrationDomainEventSubscriber> logger)  :
            base(
                connectionFactory,
                configuration,
                $"{typeof(OnSaveRegistrationDomainEvent)}Queue", 
                typeof(OnSaveRegistrationDomainEvent).Name, logger)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public override Task OnError(Exception exception)
    {
        return Task.CompletedTask;
    }



    public override async Task Handle(OnSaveRegistrationDomainEvent @event)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();

        var mediator = scope.ServiceProvider.GetService<IMediator>();
        var context = scope.ServiceProvider.GetService<DefaultContext>();
        User? user = null;
        var users = await mediator.Send(new UserGetAllQueryHandlerRequest(
            Email: @event.Entity.Email
        ));

        if (!users.Any())
            users = await mediator.Send(new UserGetAllQueryHandlerRequest(
                Username: @event.Entity.Username
            ));
        if (!users.Any())
            user = await mediator.Send(new UserSaveCommandHandlerRequest(new User
            {
                Email = @event.Entity.Email,
                Firstname = @event.Entity.Firstname,
                Lastname = @event.Entity.Lastname,
                Username = @event.Entity.Username
            }));
        else
            user = users.First();

        await mediator.Send(new OrganizationSaveCommandHandlerRequest(
            new Organization
            {
                Name = @event.Entity.OrganizationName,
                Description = @event.Entity.Description,
                State = OrganizationState.Pending,
                Owner = user
            }
        ));
        await context.SaveChangesAsync();
    }
}