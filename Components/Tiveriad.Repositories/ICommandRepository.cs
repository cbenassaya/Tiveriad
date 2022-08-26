using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Tiveriad.Repositories
{
    public interface ICommandRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task AddOneAsync(TEntity entity, CancellationToken cancellationToken = default);
        void AddOne(TEntity entity);
        Task AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        void AddMany(IEnumerable<TEntity> entities);
        Task<long> DeleteOneAsync(TEntity entity, CancellationToken cancellationToken = default);
        long DeleteOne(TEntity entity);
        Task<long> DeleteOneAsync(TKey key, CancellationToken cancellationToken = default);
        long DeleteOne(TKey key);
        Task<long> DeleteManyAsync(IEnumerable<TKey> keys, CancellationToken cancellationToken = default);
        long DeleteMany(IEnumerable<TKey> keys);

        Task<long> DeleteManyAsync(Expression<Func<TEntity, bool>> filter,
            CancellationToken cancellationToken = default);

        long DeleteMany(Expression<Func<TEntity, bool>> filter);
        Task<long> DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        long DeleteMany(IEnumerable<TEntity> entities);
        void UpdateOne(TEntity entity);
        Task UpdateOneAsync(TEntity entity, CancellationToken cancellationToken = default);
        void UpdatePartial(TEntity entity);
        Task UpdatePartialAsync(TEntity entity, CancellationToken cancellationToken = default);
        void UpdateMany(IEnumerable<TEntity> entities);
        Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}