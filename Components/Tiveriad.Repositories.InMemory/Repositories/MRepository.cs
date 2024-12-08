#region

using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;

#endregion

namespace Tiveriad.Repositories.InMemory.Repositories;

public class MRepository<TEntity, TKey> : RepositoryBase<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    public MRepository(MContext context, IOptionalService<ITenantService<TKey>> optionalTenantService) :
        base(new MQueryRepository<TEntity, TKey>(context), new MCommandRepository<TEntity, TKey>(context),optionalTenantService)
    {
    }
}