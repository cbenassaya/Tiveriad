using Microsoft.Extensions.DependencyInjection;
using Mongo2Go;
using MongoDB.Driver;
using Tiveriad.Repositories.Microsoft.DependencyInjection;
using Tiveriad.Repositories.MongoDb.Repositories;
using Tiveriad.Repositories.MongoDb.Tests.Models;
using Tiveriad.UnitTests;

namespace Tiveriad.Repositories.MongoDb.Tests;

public class Startup : StartupBase
{
    private readonly MongoDbRunner _runner =  MongoDbRunner.Start();
    public override void Configure(IServiceCollection services)
    {
        var factory = new MongoConnectionFactoryBuilder();

        services.ConfigureConnectionFactory<MongoConnectionFactoryBuilder, IMongoDatabase, MongoConnectionConfigurator>(
            configurator =>
            {
                configurator.SetConnectionString(_runner.ConnectionString);
                configurator.SetDatabaseName("TEST");
            });

        services.AddRepositories(typeof(MongoRepository<>), typeof(Course));
        
      
    }

    public override void Clean(IServiceProvider serviceProvider)
    {
        base.Clean(serviceProvider);
        _runner.Dispose();
    }
}