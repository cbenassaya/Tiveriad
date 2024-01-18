#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace Tiveriad.Repositories;

public interface IQueryRepository<TEntity, TKey>
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>
{
     IQueryable<TEntity> Queryable { get; }
    bool Any();
    bool Any(Expression<Func<TEntity, bool>> where);
    Task<bool> AnyAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);
    long Count();
    long Count(Expression<Func<TEntity, bool>> where);
    Task<long> CountAsync(CancellationToken cancellationToken = default);
    Task<long> CountAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);
    IEnumerable<TEntity> GetAll();
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter);

    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default);

    TEntity GetById(TKey id);
    Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
}