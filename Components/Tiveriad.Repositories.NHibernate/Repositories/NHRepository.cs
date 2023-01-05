using NHibernate;

namespace Tiveriad.Repositories.NHibernate.Repositories;

public class NHRepository<TEntity, TKey> : RepositoryBase<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    public NHRepository(ISession session) :
        base(new NHQueryRepository<TEntity, TKey>(session), new NHCommandRepository<TEntity, TKey>(session))
    {
    }
    
    public NHRepository(ISession querySession, ISession commandSession) :
        base(new NHQueryRepository<TEntity, TKey>(querySession), new NHCommandRepository<TEntity, TKey>(commandSession))
    {
    }
}