using MediatR;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory.EventBrokers;
using Tiveriad.Identities.Applications.Commands.OrganizationCommands;
using Tiveriad.Identities.Applications.Commands.UserCommands;
using Tiveriad.Identities.Applications.Queries.UserQueries;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Registrations.Core.DomainEvents;

namespace Tiveriad.Integration.Infrastructure.Subscribers;

public class RegistrationDomainEventSubscriber: InMemorySubscriber<RegistrationDomainEvent, string>
{
    private ILogger<RegistrationDomainEventSubscriber> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    public RegistrationDomainEventSubscriber(IInMemoryQueueManager queueManager, ILogger<RegistrationDomainEventSubscriber> logger, IServiceScopeFactory serviceScopeFactory) : base(queueManager, logger)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public override Task OnError(Exception exception)
    {
        return Task.CompletedTask;
    }

    public override async Task  DoHandle(RegistrationDomainEvent @event)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        
        var mediator = scope.ServiceProvider.GetService<IMediator>();
        User? user = null;
        var users = await  mediator.Send(new GetAllUsersRequest(
            Email:@event.Registration.Email
        ));
        
        if (!users.Any())
        {
            users = await  mediator.Send(new GetAllUsersRequest(
                Username:@event.Registration.Username
            ));
        }
        if (!users.Any())
        {
            user = await mediator.Send(new SaveUserRequest(new User
            {
                Email = @event.Registration.Email,
                Firstname = @event.Registration.Firstname,
                Lastname = @event.Registration.Lastname,
                Username = @event.Registration.Username
            }));
        }
        else
        {
            user = users.First();
        }

        await mediator.Send(new SaveOrganizationRequest(
            new Organization
            {
                Name = @event.Registration.OrganizationName,
                Description =  @event.Registration.Description,
                State = OrganizationState.Pending,
                Owner = user
            }
        ));
    }
}