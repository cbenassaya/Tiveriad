#region

using FluentValidation;
using Identity.Integration.Apis.Filters;
using Identity.Integration.Applications.Pipelines;
using Identity.Integration.Core.Services;
using Identity.Integration.Infrastructure.Services;
using Identity.Integration.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Apis.Mappings;
using Tiveriad.Identities.Applications.Commands.UserCommands;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories.EntityFrameworkCore.Repositories;
using Tiveriad.Repositories.Microsoft.DependencyInjection;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

#endregion

namespace Identity.Integration.Extensions;

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
        servicesCollection.AddScoped<ICurrentUserService, CurrentUserService>();
        servicesCollection.AddScoped<IMultiTenantService, MultiTenantService>();

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
            opt.Filters.Add<MultiTenantActionFilter>();
            opt.Filters.Add<TransactionActionFilter>();
            opt.Filters.Add<ApiExceptionFilter>();
        });

        servicesCollection.AddEndpointsApiExplorer();
        servicesCollection.AddSwaggerGen();
        return servicesCollection;
    }
}