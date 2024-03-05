#region

using FluentValidation;
using MediatR;
using Tiveriad.Documents.Apis.Contracts.DocumentDescriptionContracts;
using Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;
using Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Tiveriad.Identities.Applications.Commands.UserCommands;
using Tiveriad.Integration.Applications.Pipelines;
using Tiveriad.Integration.Filters;
using Tiveriad.Notifications.Apis.Contracts.NotificationContracts;
using Tiveriad.Notifications.Applications.Commands.NotificationCommands;
using Tiveriad.Registrations.Apis.Contracts.RegistrationContracts;
using Tiveriad.Registrations.Applications.Commands.RegistrationCommands;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

#endregion

namespace Tiveriad.Integration.Extensions;

public static class MvcDependencyInjection
{
    public static IServiceCollection AddIdentities(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(UserReaderModelContract).Assembly,
            typeof(NotificationReaderModelContract).Assembly,
            typeof(DocumentDescriptionReaderModel).Assembly,
            typeof(RegistrationReaderModelContract).Assembly);

        services.AddMvc(opt =>
        {
            //opt.Filters.Add<RegistrationDomainEventActionFilter>();
            //opt.Filters.Add<IdentityDomainEventActionFilter>();
            //opt.Filters.Add<DomainEventActionFilter>();
            opt.Filters.Add<TransactionActionFilter>();
            opt.Filters.Add<ApiExceptionFilter>();
        });

        services.AddValidatorsFromAssembly(typeof(UserSaveCommandHandlerValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(RegistrationSaveCommandHandlerValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(NotificationSaveCommandHandlerValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(UpdateDocumentCategoryPreValidator).Assembly);


        services.AddMediatR(cfg =>
        {
            cfg.Lifetime = ServiceLifetime.Scoped;
            cfg.RegisterServicesFromAssemblyContaining<UserSaveCommandHandlerRequest>();
            cfg.RegisterServicesFromAssemblyContaining<RegistrationSaveCommandHandlerRequest>();
            cfg.RegisterServicesFromAssemblyContaining<NotificationSaveCommandHandlerRequest>();
            cfg.RegisterServicesFromAssemblyContaining<SaveDocumentDescriptionRequest>();
        });

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }

    public static void UseLoggerFile(this IApplicationBuilder application)
    {
        var hostingEnvironment = application.ApplicationServices.GetRequiredService<IHostingEnvironment>();
        
        var loggerFactory = application.ApplicationServices.GetRequiredService<ILoggerFactory>();
        
        var logsPath = Path.Combine(hostingEnvironment.ContentRootPath,"Logs", "Log-{Date}.txt");
        loggerFactory.AddFile(logsPath);
    }
}