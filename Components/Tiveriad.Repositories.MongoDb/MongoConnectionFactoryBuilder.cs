using MongoDB.Driver;
using Tiveriad.Connections;

namespace Tiveriad.Repositories.MongoDb;

public class MongoConnectionFactoryBuilder:IConnectionFactoryBuilder<MongoConnectionConfigurator,IMongoConnectionConfiguration,IMongoDatabase>
{
    private MongoConnectionConfigurator _configurator;
    
    public IMongoConnectionConfiguration Configuration => _configurator;
    
    public IConnectionFactoryBuilder<MongoConnectionConfigurator,IMongoConnectionConfiguration,IMongoDatabase> Configure(Action<MongoConnectionConfigurator> action)
    {
        _configurator = new MongoConnectionConfigurator();
        action(_configurator);
        return this;
    }
    
    public IConnectionFactory<IMongoDatabase> Build()
    {
        var client = string.IsNullOrEmpty(_configurator.ConnectionString) ? new MongoClient(_configurator.Build()): new MongoClient(_configurator.ConnectionString);
        return new MongoConnectionFactory(client, client.GetDatabase(_configurator.DatabaseName));
    }
    
}