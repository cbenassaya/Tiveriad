using System;

namespace Tiveriad.Repositories
{
    public interface IRepository<TEntity, TKey> : IQueryRepository<TEntity, TKey>, ICommandRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}