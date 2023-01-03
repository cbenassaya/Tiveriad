using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Tiveriad.Repositories.MongoDb;


public class MongoConnectionConfigurator : IConnectionConfigurator
{
    private readonly MongoClientSettings _mongoClientSettings = new();

    public string DatabaseName { get; private set; }
    public string ConnectionString { get; private set; }
    
    public MongoConnectionConfigurator SetConnectTimeout(TimeSpan timeSpan)
    {
        _mongoClientSettings.ConnectTimeout = timeSpan;
        return this;
    }

    public MongoConnectionConfigurator SetReadPreference(ReadPreferenceMode readPreferenceMode)
    {
        _mongoClientSettings.ReadPreference = new ReadPreference(readPreferenceMode);
        return this;
    }
    
    public MongoConnectionConfigurator SetConnectionString(string connectionString)
    {
        ConnectionString = connectionString;
        return this;
    }


    public MongoConnectionConfigurator IsDirectConnection(bool value)
    {
        _mongoClientSettings.DirectConnection = value;
        return this;
    }

    public MongoConnectionConfigurator ApplyCustomConvention()
    {
        var pack = new ConventionPack
        {
            new NamedIdMemberConvention("Id"),
            new CamelCaseElementNameConvention(),
            new IgnoreExtraElementsConvention(true)
        };
        ConventionRegistry.Register("case", pack, t => true);
        return this;
    }


    public MongoConnectionConfigurator SetCredential(MongoCredential credential)
    {
        _mongoClientSettings.Credential = credential;
        return this;
    }

    public MongoConnectionConfigurator SetCredential(string database, string username, string password)
    {
        _mongoClientSettings.Credential = MongoCredential.CreatePlainCredential(database, username, password);
        return this;
    }

    public MongoConnectionConfigurator SetSocketTimeout(TimeSpan timeSpan)
    {
        _mongoClientSettings.SocketTimeout = timeSpan;
        return this;
    }

    public MongoConnectionConfigurator SetHost(string host)
    {
        _mongoClientSettings.Server = new MongoServerAddress(host);
        return this;
    }

    public MongoConnectionConfigurator SetHost(string host, int port)
    {
        _mongoClientSettings.Server = new MongoServerAddress(host, port);
        return this;
    }
    

    public MongoConnectionConfigurator SetSettings(Action<MongoClientSettings> setter)
    {
        setter(_mongoClientSettings);
        return this;
    }

    public MongoConnectionConfigurator SetDatabaseName(string databaseName)
    {
        DatabaseName = databaseName;
        return this;
    }
    
    public MongoClientSettings Build()
    {
        return _mongoClientSettings;
    }

}