#region

using NHibernate;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;

#endregion

namespace Tiveriad.Repositories.NHibernate.Repositories;

public class NHRepository<TEntity, TKey> : RepositoryBase<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    public NHRepository(ISession session , IOptionalService<ITenantService<TKey>> optionalTenantService) :
        base(new NHQueryRepository<TEntity, TKey>(session), new NHCommandRepository<TEntity, TKey>(session), optionalTenantService)
    {
    }

    public NHRepository(ISession querySession, ISession commandSession , IOptionalService<ITenantService<TKey>> optionalTenantService) :
        base(new NHQueryRepository<TEntity, TKey>(querySession), new NHCommandRepository<TEntity, TKey>(commandSession), optionalTenantService )
    {
    }
}