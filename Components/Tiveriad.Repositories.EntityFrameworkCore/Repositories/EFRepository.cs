using System;
using Microsoft.EntityFrameworkCore;

namespace Tiveriad.Repositories.EntityFrameworkCore.Repositories;

public class EFRepository<TEntity, TKey> : RepositoryBase<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    protected EFRepository(DbContext context) :
        base(new EFQueryRepository<TEntity, TKey>(context), new EFCommandRepository<TEntity, TKey>(context))
    {
    }
    
    protected EFRepository(DbContext queryContext, DbContext commandContext) :
        base(new EFQueryRepository<TEntity, TKey>(queryContext), new EFCommandRepository<TEntity, TKey>(commandContext))
    {
    }
}