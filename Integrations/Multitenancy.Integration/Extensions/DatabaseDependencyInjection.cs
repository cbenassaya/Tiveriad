using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Persistence;
using Tiveriad.Repositories.EntityFrameworkCore.Repositories;
using Tiveriad.Repositories.Microsoft.DependencyInjection;

namespace Multitenancy.Integration.Extensions;
public static class DatabaseDependencyInjection
{

    public static IServiceCollection AddDatabase(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddDbContextPool<DbContext, DefaultContext>(options =>
        {
            var logger = servicesCollection.BuildServiceProvider().GetService<ILogger<DefaultContext>>();
            if (logger!=null) 
                options.LogTo(message => { logger.LogInformation(message); }).EnableSensitiveDataLogging().EnableDetailedErrors();
            options.UseSqlite("Data Source=multi-tenancy.db");
        });
        servicesCollection.AddRepositories(typeof(EFRepository<, >), typeof(Organization));

        var serviceProvider = servicesCollection.BuildServiceProvider();
        var defaultContext = serviceProvider.GetRequiredService<DbContext>();
        defaultContext.Database.EnsureCreated();
        
        
        return servicesCollection;
    }

}