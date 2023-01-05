using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace Tiveriad.Repositories.NHibernate.Repositories;

public class NHQueryRepository<TEntity, TKey> : IQueryRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    
    private readonly ISession _session;
    public NHQueryRepository(ISession session)
    {
        _session = session;
    }

    public IQueryable<TEntity> Queryable => _session.Query<TEntity>();
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
        return Queryable.AnyAsync(cancellationToken: cancellationToken);
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
    {
        return Queryable.AnyAsync(where, cancellationToken: cancellationToken);
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
        return Queryable.LongCountAsync(cancellationToken: cancellationToken);
    }

    public Task<long> CountAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
    {
        return Queryable.LongCountAsync(where, cancellationToken: cancellationToken);
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

    public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
    {
        return Task.Run(() => Queryable.Where(filter).ToList().AsEnumerable(), cancellationToken);
    }

    public TEntity GetById(TKey id)
    {
        return _session.Get<TEntity>(id);
    }

    public Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return _session.GetAsync<TEntity>(id, cancellationToken);
    }
}