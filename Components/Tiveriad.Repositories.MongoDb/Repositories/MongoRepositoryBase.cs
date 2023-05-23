#region

using System.Reflection;
using MongoDB.Driver;
using Tiveriad.Connections;
using Tiveriad.Repositories.MongoDb.Attributes;

#endregion

namespace Tiveriad.Repositories.MongoDb.Repositories;

public abstract class MongoRepositoryBase<TEntity>
{
    private readonly IConnectionFactory<IMongoDatabase> _connectionFactory;

    protected MongoRepositoryBase(IConnectionFactory<IMongoDatabase> connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    private string? GetAttributeCollectionName()
    {
        return (typeof(TEntity).GetTypeInfo()
            .GetCustomAttributes(typeof(CollectionNameAttribute))
            .FirstOrDefault() as CollectionNameAttribute)?.Name;
    }

    private string GetCollectionName()
    {
        var collectionName = GetAttributeCollectionName() ?? GetEntityName();
        return collectionName;
    }

    private string GetEntityName()
    {
        var word = typeof(TEntity).Name;
        return word.Substring(0, 1).ToLower() + word.Substring(1);
    }

    protected IMongoCollection<TEntity> GetCollection()
    {
        return _connectionFactory.GetConnection().GetCollection<TEntity>(GetCollectionName());
    }
}