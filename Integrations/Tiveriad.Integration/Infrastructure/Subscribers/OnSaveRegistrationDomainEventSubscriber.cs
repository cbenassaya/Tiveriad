#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using Tiveriad.Connections;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.EventBrokers;
using Tiveriad.Identities.Applications.Commands.OrganizationCommands;
using Tiveriad.Identities.Applications.Commands.UserCommands;
using Tiveriad.Identities.Applications.Queries.UserQueries;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Integration.Core.Services;
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
        
        var currentUserService = scope.ServiceProvider.GetRequiredService<ICurrentUserService>();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var context = scope.ServiceProvider.GetRequiredService<DefaultContext>();
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
                Username = @event.Entity.Username,
                Password = @event.Entity.Password
                
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
        
        
        foreach (var entry in context.ChangeTracker.Entries<IAuditable<string>>())
            switch (entry.State)
            {
                case EntityState.Deleted:
                    break;
                case EntityState.Added:
                    entry.Entity.CreatedBy = currentUserService.GetUserId();
                    entry.Entity.Created = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = currentUserService.GetUserId();
                    entry.Entity.LastModified = DateTime.Now;
                    break;
            }
        
        await context.SaveChangesAsync();
    }
}