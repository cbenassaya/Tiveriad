using FluentValidation;
using Identities.Integration.Filters;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Identities.Apis.Contracts;
using Tiveriad.Identities.Apis.Filters;
using Tiveriad.Identities.Applications.Commands.UserCommands;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.ServiceResolvers;
using Tiveriad.ServiceResolvers.Microsoft.DependencyInjection;

namespace Identities.Integration.Extensions;

public static class MvcDependencyInjection
{
    public static IServiceCollection AddIdentities(this IServiceCollection services)
    {
        
        services.AddAutoMapper(typeof(UserReaderModel).Assembly);
        
        services.AddMvc(opt =>
        {
            opt.Filters.Add<TransactionActionFilter>();
            opt.Filters.Add<DomainEventActionFilter>();
            
        });
        
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