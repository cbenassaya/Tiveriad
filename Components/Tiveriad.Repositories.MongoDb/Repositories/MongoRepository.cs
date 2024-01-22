#region

using MongoDB.Bson;
using MongoDB.Driver;
using Tiveriad.Connections;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Repositories.MongoDb.Repositories;

public class MongoRepository<TEntity> : RepositoryBase<TEntity, ObjectId>
    where TEntity : class, IEntity<ObjectId>
{
    public MongoRepository(IConnectionFactory<IMongoDatabase> connectionFactory) :
        base(new MongoQueryRepository<TEntity>(connectionFactory),
            new MongoCommandRepository<TEntity>(connectionFactory))
    {
    }

    public MongoRepository(IConnectionFactory<IMongoDatabase> queryConnectionFactory,
        IConnectionFactory<IMongoDatabase> commandConnectionFactory) :
        base(new MongoQueryRepository<TEntity>(queryConnectionFactory),
            new MongoCommandRepository<TEntity>(commandConnectionFactory))
    {
    }
}