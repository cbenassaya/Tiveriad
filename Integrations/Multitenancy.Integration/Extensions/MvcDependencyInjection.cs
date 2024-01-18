using AutoMapper;

using FluentValidation;
using MongoDB.Bson;
using Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Multitenancy.Apis.Contracts;
using Tiveriad.Multitenancy.Apis.Filters;
using Tiveriad.Multitenancy.Applications.Commands.UserCommands;
using Tiveriad.Multitenancy.Core.DomainEvents;
using Tiveriad.ServiceResolvers;
using Tiveriad.ServiceResolvers.Microsoft.DependencyInjection;

namespace Multitenancy.Integration.Extensions;

public static class MvcDependencyInjection
{
    public static IServiceCollection AddMultitenancy(this IServiceCollection services)
    {
        
        services.AddMvc(opt =>
        {
            opt.Filters.Add<DomainEventActionFilter>();
            
        });
        
        services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<ObjectId,string>().ConvertUsing(o => o.ToString());
                cfg.CreateMap<string, ObjectId>().ConvertUsing(x => string.IsNullOrEmpty(x) ? ObjectId.Empty : ObjectId.Parse(x));
            },
            typeof(UserReaderModel).Assembly
        );
        


        
        services.AddValidatorsFromAssembly(typeof(UpdateMembershipStatePreValidator).Assembly);
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(SaveUserRequest).Assembly);
        });
        
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    
        
        services.AddScoped<IServiceResolver, DependencyInjectionServiceResolver>();
        services.AddTiveriadEip(typeof(UserDomainEvent).Assembly);
        services.AddScoped<IDomainEventStore, DomainEventStore>();
        return services;
    }
}