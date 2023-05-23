#region

using System;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Tiveriad.Repositories.EntityFrameworkCore.Repositories;

public class EFRepository<TEntity, TKey> : RepositoryBase<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    public EFRepository(DbContext context) :
        base(new EFQueryRepository<TEntity, TKey>(context), new EFCommandRepository<TEntity, TKey>(context))
    {
    }

    public EFRepository(DbContext queryContext, DbContext commandContext) :
        base(new EFQueryRepository<TEntity, TKey>(queryContext), new EFCommandRepository<TEntity, TKey>(commandContext))
    {
    }
}