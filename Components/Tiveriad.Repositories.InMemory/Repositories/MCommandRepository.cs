#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Repositories.InMemory.Repositories;

public class MCommandRepository<TEntity, TKey> : ICommandRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly MContext _context;

    public MCommandRepository(MContext context)
    {
        _context = context;
    }

    private IList<TEntity> Set => _context.CommandSet<TEntity>();


    public Task AddOneAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => AddOne(entity), cancellationToken);
    }

    public void AddOne(TEntity entity)
    {
        Set.Add(entity);
    }

    public Task AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => AddMany(entities), cancellationToken);
    }

    public void AddMany(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities) Set.Add(entity);
    }

    public Task<long> DeleteOneAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteOne(entity), cancellationToken);
    }

    public long DeleteOne(TEntity entity)
    {
        var item = Set.FirstOrDefault(x => x.Id.Equals(entity.Id));
        if (item is null) return -1;
        Set.Remove(item);
        return 1;
    }

    public Task<long> DeleteOneAsync(TKey key, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteOne(key), cancellationToken);
    }

    public long DeleteOne(TKey key)
    {
        var item = Set.FirstOrDefault(x => x.Id.Equals(key));
        if (item is null) return -1;
        Set.Remove(item);
        return 1;
    }

    public Task<long> DeleteManyAsync(IEnumerable<TKey> keys, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteMany(keys), cancellationToken);
    }

    public long DeleteMany(IEnumerable<TKey> keys)
    {
        var items = Set.Where(x => keys.Contains(x.Id)).ToArray();
        var count = items.Count();
        if (count == 0) return -1;
        foreach (var entity in items) Set.Remove(entity);
        return count;
    }

    public Task<long> DeleteManyAsync(Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteMany(filter), cancellationToken);
    }

    public long DeleteMany(Expression<Func<TEntity, bool>> filter)
    {
        var items = Set.AsQueryable().Where(filter).ToArray();
        var count = items.Count();
        if (count == 0) return -1;
        foreach (var entity in items) Set.Remove(entity);
        return count;
    }

    public Task<long> DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteMany(entities.Select(x => x.Id)), cancellationToken);
    }

    public long DeleteMany(IEnumerable<TEntity> entities)
    {
        return DeleteMany(entities.Select(x => x.Id));
    }

    public void UpdateOne(TEntity entity)
    {
        //do nothing
    }

    public Task UpdateOneAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => UpdateOne(entity), cancellationToken);
    }

    public void UpdateMany(IEnumerable<TEntity> entities)
    {
        //do nothing
    }

    public Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => UpdateMany(entities));
    }

    public void UpdatePartial(TEntity entity)
    {
        //do nothing
    }

    public Task UpdatePartialAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => UpdatePartial(entity), cancellationToken);
    }
}