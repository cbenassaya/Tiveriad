#region

using System.Linq.Expressions;
using NHibernate;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Repositories.NHibernate.Repositories;

public class NHCommandRepository<TEntity, TKey> : ICommandRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly ISession _session;

    public NHCommandRepository(ISession session)
    {
        _session = session;
    }

    public Task AddOneAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return _session.SaveAsync(entity, cancellationToken);
    }

    public void AddOne(TEntity entity)
    {
        _session.Save(entity);
    }

    public Task AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => { AddMany(entities); }, cancellationToken);
    }

    public void AddMany(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities) _session.Save(entity);
    }

    public Task<long> DeleteOneAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(() =>
        {
            _session.Delete(entity);
            return 1L;
        }, cancellationToken);
    }

    public long DeleteOne(TEntity entity)
    {
        _session.Delete(entity);
        return 1L;
    }

    public Task<long> DeleteOneAsync(TKey key, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteOne(key), cancellationToken);
    }

    public long DeleteOne(TKey key)
    {
        var entity = _session.Query<TEntity>().FirstOrDefault(x => x.Id.Equals(key));
        if (entity == null)
            return 0L;
        _session.Delete(entity);
        return 1L;
    }

    public Task<long> DeleteManyAsync(IEnumerable<TKey> keys, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteMany(keys), cancellationToken);
    }

    public long DeleteMany(IEnumerable<TKey> keys)
    {
        return keys.Sum(DeleteOne);
    }

    public Task<long> DeleteManyAsync(Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteMany(filter), cancellationToken);
    }

    public long DeleteMany(Expression<Func<TEntity, bool>> filter)
    {
        var results = _session.Query<TEntity>().Where(filter).ToList();
        return results.Sum(DeleteOne);
    }

    public Task<long> DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteMany(entities), cancellationToken);
    }

    public long DeleteMany(IEnumerable<TEntity> entities)
    {
        return entities.Sum(DeleteOne);
    }

    public void UpdateOne(TEntity entity)
    {
        _session.Update(entity);
    }

    public Task UpdateOneAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return _session.UpdateAsync(entity, cancellationToken);
    }

    public void UpdateMany(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities) _session.Update(entity);
    }

    public Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => { UpdateMany(entities); }, cancellationToken);
    }
}