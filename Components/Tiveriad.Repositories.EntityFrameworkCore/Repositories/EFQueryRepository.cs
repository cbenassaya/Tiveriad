using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tiveriad.Repositories.EntityFrameworkCore.Repositories;

public class EFQueryRepository<TEntity, TKey> : IQueryRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly DbContext _context;

    public EFQueryRepository(DbContext context)
    {
        _context = context;
    }

    public IQueryable<TEntity> Queryable => _context.Set<TEntity>();

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
        return Queryable.AnyAsync();
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
    {
        return Queryable.AnyAsync(where);
    }

    public long Count()
    {
        return Queryable.LongCount();
    }

    public long Count(Expression<Func<TEntity, bool>> where)
    {
        return Queryable.LongCount(where);
    }

    public Task<long> CountAsync(CancellationToken cancellationToken = default)
    {
        return Queryable.LongCountAsync();
    }

    public Task<long> CountAsync(Expression<Func<TEntity, bool>> where,
        CancellationToken cancellationToken = default)
    {
        return Queryable.LongCountAsync(where);
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
        return _context.Set<TEntity>().Find(id);
    }

    public Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return _context.Set<TEntity>()
            .FindAsync(new object[] { id }, cancellationToken).AsTask();
    }
}