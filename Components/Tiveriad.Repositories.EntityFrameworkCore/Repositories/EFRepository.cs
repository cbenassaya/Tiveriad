#region

using System;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;

#endregion

namespace Tiveriad.Repositories.EntityFrameworkCore.Repositories;

public class EFRepository<TEntity, TKey> : RepositoryBase<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    public EFRepository(DbContext context, IOptionalService<ITenantService<TKey>> optionalTenantService) :
        base(new EFQueryRepository<TEntity, TKey>(context), new EFCommandRepository<TEntity, TKey>(context), optionalTenantService  )
    {
    }

    public EFRepository(DbContext queryContext, DbContext commandContext, IOptionalService<ITenantService<TKey>> optionalTenantService) :
        base(new EFQueryRepository<TEntity, TKey>(queryContext), new EFCommandRepository<TEntity, TKey>(commandContext), optionalTenantService  )
    {
    }
}