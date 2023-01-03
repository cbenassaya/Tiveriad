using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Tiveriad.Repositories.MongoDb.Repositories;

public class MongoQueryRepository<TEntity> : MongoRepositoryBase<TEntity>, IQueryRepository<TEntity, ObjectId>
    where TEntity : class, IEntity<ObjectId>
{
    public MongoQueryRepository(IConnectionFactory<IMongoDatabase> connectionFactory) : base(connectionFactory)  { }

    public IQueryable<TEntity> Queryable { get; }
    public bool Any()
    {
        return Queryable.Any();
    }

    public bool Any(Expression<Func<TEntity, bool>> where)
    {
        return Queryable.Where(where).Any();
    }

    public Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        var queryable = Queryable as IMongoQueryable<TEntity>;
        return queryable.AnyAsync(cancellationToken);
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
    {
        var queryable = Queryable as IMongoQueryable<TEntity>;
        return queryable.Where(where).AnyAsync(cancellationToken);
    }

    public long Count()
    {
        return Queryable.Count();
    }

    public long Count(Expression<Func<TEntity, bool>> where)
    {
        var queryable = Queryable as IMongoQueryable<TEntity>;
        return queryable.Where(where).Count();
    }

    public Task<long> CountAsync(CancellationToken cancellationToken = default)
    {
        var queryable = Queryable as IMongoQueryable<TEntity>;
        return Task.Run(() => (long)queryable.Count(), cancellationToken);
    }

    public Task<long> CountAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
    {
        var queryable = Queryable as IMongoQueryable<TEntity>;
        return Task.Run(() => (long)queryable.Where(where).Count(), cancellationToken);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return GetCollection().Find(Builders<TEntity>.Filter.Empty).ToList();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.Run(() => GetCollection().Find(Builders<TEntity>.Filter.Empty).ToEnumerable(),cancellationToken);
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
    {
        return GetCollection().Find(filter).ToList();
    }

    public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => GetCollection().Find(filter).ToEnumerable(),cancellationToken);
    }

    public TEntity GetById(ObjectId id)
    {
        var filter = Builders<TEntity>.Filter.Eq("Id", id);
        return GetCollection().Find(filter).FirstOrDefault();
    }

    public Task<TEntity> GetByIdAsync(ObjectId id, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => GetById(id),cancellationToken);
    }
}