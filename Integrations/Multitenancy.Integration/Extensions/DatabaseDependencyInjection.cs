using MongoDB.Driver;
using Multitenancy.Integration.Infrastructure;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories.Microsoft.DependencyInjection;
using Tiveriad.Repositories.MongoDb;
using Tiveriad.Repositories.MongoDb.Repositories;

namespace Multitenancy.Integration;
public static class DatabaseDependencyInjection
{

    public static IServiceCollection AddDatabase(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddSingleton<Database>();

        var database = servicesCollection.BuildServiceProvider().GetRequiredService<Database>();

        servicesCollection
            .ConfigureConnectionFactory<MongoConnectionFactoryBuilder, IMongoDatabase, MongoConnectionConfigurator,
                IMongoConnectionConfiguration>(configurator =>
                {
                    configurator.SetConnectionString(database.ConnectionString);
                    configurator.SetDatabaseName("TEST");
                });
        
        
        servicesCollection.AddRepositories(typeof(MongoRepository<>), typeof(Organization));

        return servicesCollection;
    }

}