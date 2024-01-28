using FluentValidation;
using MediatR;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Documents.Apis.Contracts.DocumentDescriptionContracts;
using Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;
using Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;
using Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Tiveriad.Identities.Apis.Filters;
using Tiveriad.Identities.Applications.Commands.UserCommands;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.Integration.Applications.Pipelines;
using Tiveriad.Integration.Filters;
using Tiveriad.Notifications.Apis.Contracts.NotificationContracts;
using Tiveriad.Notifications.Applications.Commands.NotificationCommands;
using Tiveriad.ServiceResolvers;
using Tiveriad.ServiceResolvers.Microsoft.DependencyInjection;

namespace Tiveriad.Integration.Extensions;

public static class MvcDependencyInjection
{
    public static IServiceCollection AddIdentities(this IServiceCollection services)
    {
        
        services.AddAutoMapper(typeof(UserReaderModel).Assembly, typeof(NotificationReaderModel).Assembly, typeof(DocumentDescriptionReaderModel).Assembly);
        
        services.AddMvc(opt =>
        {
            opt.Filters.Add<TransactionActionFilter>();
            opt.Filters.Add<DomainEventActionFilter>();
            
        });
        
        services.AddValidatorsFromAssembly(typeof(UpdateMembershipStatePreValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(UpdateNotificationPreValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(UpdateDocumentCategoryPreValidator).Assembly);
        
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(SaveUserRequest).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(SaveNotificationRequest).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(SaveDocumentDescriptionRequest).Assembly);
        });
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    
        
        services.AddScoped<IServiceResolver, DependencyInjectionServiceResolver>();
        services.AddTiveriadEip(typeof(UserDomainEvent).Assembly);
        services.AddScoped<IDomainEventStore, DomainEventStore>();
        return services;
    }
}