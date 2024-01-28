using Microsoft.EntityFrameworkCore;
using Tiveriad.Documents.Core.Entities;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Persistence;
using Tiveriad.Integration.Persistence;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories.EntityFrameworkCore.Repositories;
using Tiveriad.Repositories.Microsoft.DependencyInjection;

namespace Tiveriad.Integration.Extensions;
public static class DatabaseDependencyInjection
{

    public static IServiceCollection AddDatabase(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddDbContextPool<DbContext, DefaultContext>(options =>
        {
            var logger = servicesCollection.BuildServiceProvider().GetService<ILogger<DefaultContext>>();
            if (logger!=null) 
                options.LogTo(message => { logger.LogInformation(message); }).EnableSensitiveDataLogging().EnableDetailedErrors();
            options.UseSqlite("Data Source=integration.db");
        });
        
        servicesCollection.AddRepositories(typeof(EFRepository<, >), 
            typeof(DocumentDescription).Assembly, typeof(Notification).Assembly,typeof(User).Assembly);

        var serviceProvider = servicesCollection.BuildServiceProvider();
        var defaultContext = serviceProvider.GetRequiredService<DbContext>();
        defaultContext.Database.EnsureCreated();
        
        
        return servicesCollection;
    }

}