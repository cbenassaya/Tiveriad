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

public class MQueryRepository<TEntity, TKey> : IQueryRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly MContext _context;

    public MQueryRepository(MContext context)
    {
        _context = context;
    }

    public IQueryable<TEntity> Queryable => _context.QuerySet<TEntity>();

    public bool Any()
    {
        return Queryable.Any();
    }

    public bool Any(Expression<Func<TEntity, bool>> where)
    {
        return Queryable.Any(where);
    }

    public Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        return Task.Run(() => Any(), cancellationToken);
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => Any(where), cancellationToken);
    }

    public long Count()
    {
        return Queryable.LongCount();
    }

    public long Count(Expression<Func<TEntity, bool>> where)
    {
        return Queryable.Count(where);
    }

    public Task<long> CountAsync(CancellationToken cancellationToken = default)
    {
        return Task.Run(() => Count(), cancellationToken);
    }

    public Task<long> CountAsync(Expression<Func<TEntity, bool>> where,
        CancellationToken cancellationToken = default)
    {
        return Task.Run(() => Count(where), cancellationToken);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return Queryable.ToList();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.Run(() => Queryable.ToList().AsEnumerable(), cancellationToken);
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
    {
        return Queryable.Where(filter).ToList().AsEnumerable();
    }

    public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        return Task.Run(() => Queryable.Where(filter).ToList().AsEnumerable(), cancellationToken);
    }

    public TEntity GetById(TKey id)
    {
        return Queryable.FirstOrDefault(x => x.Id.Equals(id));
    }

    public Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => GetById(id), cancellationToken);
    }
}