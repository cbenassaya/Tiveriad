using FluentValidation;
using MediatR;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Documents.Apis.Contracts.DocumentDescriptionContracts;
using Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;
using Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;
using Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Identities.Apis.Contracts;
using Tiveriad.Identities.Apis.Filters;
using Tiveriad.Identities.Applications.Commands.MembershipCommands;
using Tiveriad.Identities.Applications.Commands.UserCommands;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.Integration.Applications.Pipelines;
using Tiveriad.Integration.Filters;
using Tiveriad.Notifications.Apis.Contracts.NotificationContracts;
using Tiveriad.Notifications.Applications.Commands.NotificationCommands;
using Tiveriad.Registrations.Apis.Contracts;
using Tiveriad.Registrations.Apis.Filters;
using Tiveriad.Registrations.Applications.Commands.RegistrationCommands;
using Tiveriad.ServiceResolvers;
using Tiveriad.ServiceResolvers.Microsoft.DependencyInjection;

namespace Tiveriad.Integration.Extensions;

public static class MvcDependencyInjection
{

    public static IServiceCollection AddIdentities(this IServiceCollection services)
    {
        
        services.AddAutoMapper(
            typeof(UserReaderModel).Assembly,
            typeof(NotificationReaderModel).Assembly,
            typeof(DocumentDescriptionReaderModel).Assembly,
            typeof(RegistrationReaderModel).Assembly);
        
        services.AddMvc(opt =>
        {
            opt.Filters.Add<RegistrationDomainEventActionFilter>();
            opt.Filters.Add<IdentityDomainEventActionFilter>();
            opt.Filters.Add<MultitenancyActionFilter>();
            opt.Filters.Add<TransactionActionFilter>();
            opt.Filters.Add<ApiExceptionFilter>();
        });
        
        services.AddValidatorsFromAssembly(typeof(UpdateMembershipPreValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(SaveRegistrationPreValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(UpdateNotificationPreValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(UpdateDocumentCategoryPreValidator).Assembly);

       
        services.AddMediatR(cfg =>
        {
            cfg.Lifetime = ServiceLifetime.Scoped;
            cfg.RegisterServicesFromAssemblyContaining<SaveNotificationRequest>( );
            cfg.RegisterServicesFromAssemblyContaining<SaveUserRequest>();
            cfg.RegisterServicesFromAssemblyContaining<SaveRegistrationRequest>();
            cfg.RegisterServicesFromAssemblyContaining<SaveDocumentDescriptionRequest>();
        });
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        
        return services;
    }
    
    public static void UseLoggerFile(this IApplicationBuilder application)
    {
        var loggerFactory = application.ApplicationServices.GetRequiredService<ILoggerFactory>();
        loggerFactory.AddFile("Logs/Log-{Date}.txt");
    }

}

