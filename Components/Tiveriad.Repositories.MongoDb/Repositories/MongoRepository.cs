#region

using MongoDB.Bson;
using MongoDB.Driver;
using Tiveriad.Connections;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;

#endregion

namespace Tiveriad.Repositories.MongoDb.Repositories;

public class MongoRepository<TEntity> : RepositoryBase<TEntity, ObjectId>
    where TEntity : class, IEntity<ObjectId>
{
    public MongoRepository(IConnectionFactory<IMongoDatabase> connectionFactory, IOptionalService<ITenantService<ObjectId>> optionalTenantService) :
        base(new MongoQueryRepository<TEntity>(connectionFactory),
            new MongoCommandRepository<TEntity>(connectionFactory), optionalTenantService)
    {
    }

    public MongoRepository(IConnectionFactory<IMongoDatabase> queryConnectionFactory,
        IConnectionFactory<IMongoDatabase> commandConnectionFactory, IOptionalService<ITenantService<ObjectId>> optionalTenantService) :
        base(new MongoQueryRepository<TEntity>(queryConnectionFactory),
            new MongoCommandRepository<TEntity>(commandConnectionFactory), optionalTenantService)
    {
    }
}