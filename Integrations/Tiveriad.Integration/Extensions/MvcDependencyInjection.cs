﻿#region

using FluentValidation;
using MediatR;
using Tiveriad.Documents.Apis.Contracts.DocumentDescriptionContracts;
using Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;
using Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Tiveriad.Identities.Applications.Commands.LanguageCommands;
using Tiveriad.Integration.Applications.Pipelines;
using Tiveriad.Integration.Filters;
using Tiveriad.Notifications.Apis.Contracts.NotificationContracts;
using Tiveriad.Notifications.Applications.Commands.NotificationCommands;
using Tiveriad.Registrations.Apis.Contracts.RegistrationContracts;
using Tiveriad.Registrations.Applications.Commands.RegistrationCommands;

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
            opt.Filters.Add<MultiTenancyActionFilter>();
            opt.Filters.Add<DomainEventActionFilter>();
            opt.Filters.Add<TransactionActionFilter>();
            opt.Filters.Add<ApiExceptionFilter>();
        });

        services.AddValidatorsFromAssembly(typeof(LanguageSaveCommandHandlerValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(RegistrationSaveCommandHandlerValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(NotificationSaveCommandHandlerValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(UpdateDocumentCategoryPreValidator).Assembly);


        services.AddMediatR(cfg =>
        {
            cfg.Lifetime = ServiceLifetime.Scoped;
            cfg.RegisterServicesFromAssemblyContaining<LanguageSaveCommandHandlerRequest>();
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
        var loggerFactory = application.ApplicationServices.GetRequiredService<ILoggerFactory>();
        loggerFactory.AddFile("Logs/Log-{Date}.txt");
    }
}