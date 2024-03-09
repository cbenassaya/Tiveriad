#region

using FluentValidation;
using Identities.Integration.Apis.Filters;
using Identities.Integration.Applications.Pipelines;
using Identities.Integration.Infrastructure.Services;
using Identities.Integration.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Identities.Apis.Mappings;
using Tiveriad.Identities.Applications.Commands.UserCommands;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories.EntityFrameworkCore.Repositories;
using Tiveriad.Repositories.Microsoft.DependencyInjection;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

#endregion

namespace Identities.Integration.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection servicesCollection)
    {
        //DBContext
        servicesCollection.AddDbContextPool<DbContext, DefaultContext>(options =>
        {
            var hostingEnvironment =
                servicesCollection.BuildServiceProvider().GetRequiredService<IHostingEnvironment>();

            var logger = servicesCollection.BuildServiceProvider().GetService<ILogger<DefaultContext>>();
            if (logger != null)
                options.LogTo(message => { logger.LogInformation(message); }).EnableSensitiveDataLogging()
                    .EnableDetailedErrors();

            var databasePath = Path.Combine(hostingEnvironment.ContentRootPath, "database.db");
            options.UseSqlite($"Data Source={databasePath}");
        });

        var serviceProvider = servicesCollection.BuildServiceProvider();
        var defaultContext = serviceProvider.GetRequiredService<DbContext>();
        defaultContext.Database.EnsureCreated();


        //Repositories
        servicesCollection.AddRepositories(typeof(EFRepository<,>), typeof(User));

        return servicesCollection;
    }

    public static IServiceCollection AddServices(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        servicesCollection.AddScoped<ICurrentUserService<string>, CurrentUserService>();
        servicesCollection.AddScoped<ITenantService<string>, TenantService>();

        return servicesCollection;
    }

    public static IServiceCollection AddCqrs(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddMediatR(cfg =>
        {
            cfg.Lifetime = ServiceLifetime.Scoped;
            cfg.RegisterServicesFromAssemblies(typeof(UserSaveCommandHandler).Assembly);
        });
        return servicesCollection;
    }

    public static IServiceCollection AddValidators(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddValidatorsFromAssembly(typeof(UserSaveCommandHandlerValidator).Assembly);
        return servicesCollection;
    }

    public static IServiceCollection AddMappers(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddAutoMapper(typeof(UserProfile).Assembly);
        return servicesCollection;
    }

    public static IServiceCollection AddPipelines(this IServiceCollection servicesCollection)
    {
        servicesCollection
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        return servicesCollection;
    }

    public static IServiceCollection AddEndPointServices(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddCors(options =>
        {
            options.AddDefaultPolicy(builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
        });

        servicesCollection.AddMvc(opt =>
        {
            opt.Filters.Add<TransactionActionFilter>();
            opt.Filters.Add<ApiExceptionFilter>();
        });

        servicesCollection.AddEndpointsApiExplorer();
        servicesCollection.AddSwaggerGen();
        return servicesCollection;
    }
}