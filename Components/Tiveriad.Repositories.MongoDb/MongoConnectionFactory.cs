#region

using MongoDB.Driver;
using Tiveriad.Connections;

#endregion

namespace Tiveriad.Repositories.MongoDb;

public class MongoConnectionFactory : IConnectionFactory<IMongoDatabase>
{
    private readonly IMongoClient _client;
    private readonly IMongoDatabase _database;

    public MongoConnectionFactory(IMongoClient client, IMongoDatabase database)
    {
        _client = client;
        _database = database;
    }

    public IMongoDatabase GetConnection()
    {
        return _database.WithWriteConcern(WriteConcern.Acknowledged);
    }
}