using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ReferenceData.Integration.Apis.Filters;
using ReferenceData.Integration.Applications.Pipelines;
using ReferenceData.Integration.Core.Entities;
using ReferenceData.Integration.Core.Services;
using ReferenceData.Integration.Infrastructure.Services;
using ReferenceData.Integration.Persistence;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.ReferenceData.Apis.Controllers;
using Tiveriad.ReferenceData.Apis.Mappings;
using Tiveriad.ReferenceData.Applications.Commands.KeyValueCommands;
using Tiveriad.ReferenceData.Core.Entities;
using Tiveriad.Repositories.EntityFrameworkCore.Repositories;
using Tiveriad.Repositories.Microsoft.DependencyInjection;

using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace ReferenceData.Integration.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection servicesCollection)
    {
        //DBContext
        servicesCollection.AddDbContextPool<DbContext, DefaultContext>(options =>
        {
            
            var hostingEnvironment = servicesCollection.BuildServiceProvider().GetRequiredService<IHostingEnvironment>();
            
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
        servicesCollection.AddRepositories(typeof(EFRepository<,>), typeof(KeyValue));

        return servicesCollection;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        servicesCollection.AddScoped<ICurrentUserService, CurrentUserService>();
        servicesCollection.AddScoped<ITenantService<string>, TenantService>();
        servicesCollection.AddScoped<ILanguageService<string>, LanguageService>();
        return servicesCollection;
    }

    public static IServiceCollection AddCqrs(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddMediatR(cfg =>
        {
            cfg.Lifetime = ServiceLifetime.Scoped;
            cfg.RegisterServicesFromAssemblies(typeof(KeyValueSaveCommandHandler).Assembly);
        });
        return servicesCollection;
    }

    public static IServiceCollection AddValidators(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddValidatorsFromAssembly(typeof(KeyValueSaveCommandHandlerValidator).Assembly);
        return servicesCollection;
    }
    
    public static IServiceCollection AddMappers(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddAutoMapper(typeof(KeyValueProfile).Assembly);
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
        
        servicesCollection
            .AddControllers(o =>
            {
                o.Conventions.Add(
                    new ReferenceDataControllerRouteConvention()
                );
            })
            .ConfigureApplicationPartManager(m =>
            {
                m.FeatureProviders.Add(new ReferenceDataControllerFeatureProvider([typeof(Skill).Assembly]));
            });
        
        servicesCollection.AddEndpointsApiExplorer();
        servicesCollection.AddSwaggerGen();
        return servicesCollection;
    }   
}