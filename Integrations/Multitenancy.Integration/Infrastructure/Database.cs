using Mongo2Go;

namespace Multitenancy.Integration.Infrastructure;

public class Database : IDisposable
{
    private readonly MongoDbRunner _runner;
    public  Database()
    {
        _runner = MongoDbRunner.Start();
    }
    public string ConnectionString => _runner.ConnectionString;
    
    public void Dispose()
    {
        using (_runner) ;

    }
}
