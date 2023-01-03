using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tiveriad.Repositories.EntityFrameworkCore.Repositories;

public class EFCommandRepository<TEntity, TKey> : ICommandRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly DbContext _context;
    private readonly DetachedCommand _detachedCommand;
    private readonly SetIdCommand<TKey> _setIdCommand;
    

    public EFCommandRepository(DbContext context)
    {
        _context = context;
        _detachedCommand = new DetachedCommand(value => { _context.Entry(value).State = EntityState.Detached; });

        _setIdCommand = new SetIdCommand<TKey>();
    }


    private DbSet<TEntity> Set => _context.Set<TEntity>();

    public Task AddOneAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _detachedCommand.DetachChildren(entity);
        _setIdCommand.Traverse(entity);
        return Set.AddAsync(entity, cancellationToken).AsTask();
    }

    public void AddOne(TEntity entity)
    {
        _detachedCommand.DetachChildren(entity);
        _setIdCommand.Traverse(entity);
        Set.Add(entity);
    }

    public Task AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        foreach (var entityBase in entities)
        {
            _detachedCommand.DetachChildren(entityBase);
            _setIdCommand.Traverse(entityBase);
        }

        return Set.AddRangeAsync(entities, cancellationToken);
    }

    public void AddMany(IEnumerable<TEntity> entities)
    {
        foreach (var entityBase in entities)
        {
            _detachedCommand.DetachChildren(entityBase);
            _setIdCommand.Traverse(entityBase);
        }

        Set.AddRange(entities);
    }

    public Task<long> DeleteOneAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteOne(entity), cancellationToken);
    }

    public long DeleteOne(TEntity entity)
    {
        var item = Set.Find(entity.Id);
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
        var item = Set.Find(key);
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
        if (count > 0) return -1;
        Set.RemoveRange(items);
        return count;
    }

    public Task<long> DeleteManyAsync(Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        return Task.Run(() => DeleteMany(filter), cancellationToken);
    }

    public long DeleteMany(Expression<Func<TEntity, bool>> filter)
    {
        var items = Set.Where(filter).ToArray();
        var count = items.Count();
        if (count == 0) return -1;
        Set.RemoveRange(items);
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
        _detachedCommand.DetachChildren(entity);
        _setIdCommand.Traverse(entity);

        var entry = _context.Entry(entity);
        if (entry.State == EntityState.Detached)
        {
            var attachedEntity = _context.Set<TEntity>().Find(entity.Id);
            if (attachedEntity != null)
            {
                _context.Entry(attachedEntity).CurrentValues.SetValues(entity);
                return;
            }
        }

        entry.State = EntityState.Modified;
        Set.Update(entity);
    }

    public Task UpdateOneAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => UpdateOne(entity), cancellationToken);
    }

    public void UpdateMany(IEnumerable<TEntity> entities)
    {
        foreach (var entityBase in entities) _detachedCommand.DetachChildren(entityBase);
        Set.UpdateRange(entities);
    }

    public Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => UpdateMany(entities));
    }
}