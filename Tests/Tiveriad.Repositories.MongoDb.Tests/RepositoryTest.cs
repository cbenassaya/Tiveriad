using Microsoft.Extensions.DependencyInjection;
using Mongo2Go;
using MongoDB.Bson;
using MongoDB.Driver;
using Tiveriad.Repositories.MongoDb.Repositories;
using Tiveriad.Repositories.Tests.Models;
using Tiveriad.UnitTests;
using Xunit;
using Company = Faker.Company;
using Enum = Faker.Enum;

namespace Tiveriad.Repositories.MongoDb.Tests;


public class Startup : StartupBase
{
    private readonly MongoDbRunner _runner =  MongoDbRunner.Start();
    public override void Configure(IServiceCollection services)
    {
        var factory = new MongoConnectionFactoryBuilder();
        
        

        factory.Configure(configurator =>
        {
            configurator.SetConnectionString(_runner.ConnectionString);
            configurator.SetDatabaseName("TEST");
        });
        var connectionFactory = factory.Build();
        services.AddSingleton<IConnectionFactory<IMongoDatabase>>( connectionFactory);
        
        services.AddScoped<CourseRepository>();
    }

    public override void Clean(IServiceProvider serviceProvider)
    {
        base.Clean(serviceProvider);
        _runner.Dispose();
    }
}


public class CourseRepository : MongoRepository<Course<ObjectId>, ObjectId>
{
    public CourseRepository(IConnectionFactory<IMongoDatabase> connectionFactory) : base(connectionFactory)
    {
    }

}


public class RepositoryTest  : TestBase<Startup>
{
    
    [Fact]
    public async Task Add_Entity()
    {
        var repository = GetService<CourseRepository>();
        var name = Company.Name();
        var course = new Course<ObjectId> { Name = name};
        await repository.AddOneAsync(course);
        var items = await repository.FindAsync(x => x.Name.Equals(name));
        Assert.Equal(1,items.Count());
    }
}