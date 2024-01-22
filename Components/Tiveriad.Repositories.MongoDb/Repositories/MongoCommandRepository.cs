#region

using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using Tiveriad.Connections;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Repositories.MongoDb.Repositories;

public class MongoCommandRepository<TEntity> : MongoRepositoryBase<TEntity>, ICommandRepository<TEntity, ObjectId>
    where TEntity : class, IEntity<ObjectId>
{
    public MongoCommandRepository(IConnectionFactory<IMongoDatabase> connectionFactory) : base(connectionFactory)
    {
    }

    public Task AddOneAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return GetCollection().InsertOneAsync(entity, null, cancellationToken);
    }

    public void AddOne(TEntity entity)
    {
        GetCollection().InsertOne(entity);
    }

    public Task AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => AddMany(entities), cancellationToken);
    }

    public void AddMany(IEnumerable<TEntity> entities)
    {
        GetCollection().InsertMany(entities);
    }

    public Task<long> DeleteOneAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteOne(entity), cancellationToken);
    }

    public long DeleteOne(TEntity entity)
    {
        var filter = Builders<TEntity>.Filter.Eq("Id", entity.Id);
        return GetCollection().DeleteOne(filter).DeletedCount;
    }

    public Task<long> DeleteOneAsync(ObjectId key, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteOne(key), cancellationToken);
    }

    public long DeleteOne(ObjectId key)
    {
        var filter = Builders<TEntity>.Filter.Eq("Id", key);
        return GetCollection().DeleteOne(filter).DeletedCount;
    }

    public Task<long> DeleteManyAsync(IEnumerable<ObjectId> keys, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteMany(keys), cancellationToken);
    }

    public long DeleteMany(IEnumerable<ObjectId> keys)
    {
        var idsFilter = Builders<TEntity>.Filter.In(d => d.Id, keys);
        return GetCollection().DeleteMany(idsFilter).DeletedCount;
    }

    public Task<long> DeleteManyAsync(Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteMany(filter), cancellationToken);
    }

    public long DeleteMany(Expression<Func<TEntity, bool>> filter)
    {
        return GetCollection().DeleteMany(filter).DeletedCount;
    }

    public Task<long> DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteMany(entities), cancellationToken);
    }

    public long DeleteMany(IEnumerable<TEntity> entities)
    {
        var idsFilter = Builders<TEntity>.Filter.In(d => d.Id, entities.Select(x => x.Id).ToList());
        return GetCollection().DeleteMany(idsFilter).DeletedCount;
    }

    public void UpdateOne(TEntity entity)
    {
        var filter = Builders<TEntity>.Filter.Eq("Id", entity.Id);
        GetCollection().ReplaceOne(filter, entity);
    }

    public Task UpdateOneAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => UpdateOne(entity), cancellationToken);
    }

    public void UpdateMany(IEnumerable<TEntity> entities)
    {
        GetCollection().BulkWrite(CreateUpdates(entities));
    }

    public Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => UpdateManyAsync(entities), cancellationToken);
    }

    private IEnumerable<WriteModel<TEntity>> CreateUpdates(IEnumerable<TEntity> items)
    {
        var updates = new List<WriteModel<TEntity>>();

        foreach (var item in items)
        {
            var filter = Builders<TEntity>.Filter.Eq("Id", item.Id);
            updates.Add(new ReplaceOneModel<TEntity>(filter, item));
        }

        return updates;
    }
}