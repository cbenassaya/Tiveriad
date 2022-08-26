using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Tiveriad.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>

    {
        private readonly ICommandRepository<TEntity, TKey> _commandRepository;
        private readonly IQueryRepository<TEntity, TKey> _queryRepository;

        public RepositoryBase(IQueryRepository<TEntity, TKey> queryRepository,
            ICommandRepository<TEntity, TKey> commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        public IQueryable<TEntity> Queryable => _queryRepository.Queryable;

        public bool Any()
        {
            return _queryRepository.Any();
        }

        public bool Any(Expression<Func<TEntity, bool>> where)
        {
            return _queryRepository.Any(where);
        }

        public Task<bool> AnyAsync(CancellationToken cancellationToken = default)
        {
            return _queryRepository.AnyAsync(cancellationToken);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
        {
            return _queryRepository.AnyAsync(where, cancellationToken);
        }

        public long Count()
        {
            return _queryRepository.Count();
        }

        public long Count(Expression<Func<TEntity, bool>> where)
        {
            return _queryRepository.Count(where);
        }

        public Task<long> CountAsync(CancellationToken cancellationToken = default)
        {
            return _queryRepository.CountAsync(cancellationToken);
        }

        public Task<long> CountAsync(Expression<Func<TEntity, bool>> where,
            CancellationToken cancellationToken = default)
        {
            return _queryRepository.CountAsync(where, cancellationToken);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _queryRepository.GetAll();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _queryRepository.GetAllAsync(cancellationToken);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return _queryRepository.Find(filter);
        }

        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter,
            CancellationToken cancellationToken = default)
        {
            return _queryRepository.FindAsync(filter, cancellationToken);
        }

        public TEntity GetById(TKey id)
        {
            return _queryRepository.GetById(id);
        }

        public Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return _queryRepository.GetByIdAsync(id, cancellationToken);
        }

        public Task AddOneAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return _commandRepository.AddOneAsync(entity, cancellationToken);
        }

        public void AddOne(TEntity entity)
        {
            _commandRepository.AddOne(entity);
        }

        public Task AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return _commandRepository.AddManyAsync(entities, cancellationToken);
        }

        public void AddMany(IEnumerable<TEntity> entities)
        {
            _commandRepository.AddMany(entities);
        }

        public Task<long> DeleteOneAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return _commandRepository.DeleteOneAsync(entity, cancellationToken);
        }

        public long DeleteOne(TEntity entity)
        {
            return _commandRepository.DeleteOne(entity);
        }

        public Task<long> DeleteOneAsync(TKey key, CancellationToken cancellationToken = default)
        {
            return _commandRepository.DeleteOneAsync(key, cancellationToken);
        }

        public long DeleteOne(TKey key)
        {
            return _commandRepository.DeleteOne(key);
        }

        public Task<long> DeleteManyAsync(IEnumerable<TKey> keys, CancellationToken cancellationToken = default)
        {
            return _commandRepository.DeleteManyAsync(keys, cancellationToken);
        }

        public long DeleteMany(IEnumerable<TKey> keys)
        {
            return _commandRepository.DeleteMany(keys);
        }

        public Task<long> DeleteManyAsync(Expression<Func<TEntity, bool>> filter,
            CancellationToken cancellationToken = default)
        {
            return _commandRepository.DeleteManyAsync(filter, cancellationToken);
        }

        public long DeleteMany(Expression<Func<TEntity, bool>> filter)
        {
            return _commandRepository.DeleteMany(filter);
        }

        public Task<long> DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return _commandRepository.DeleteManyAsync(entities, cancellationToken);
        }

        public long DeleteMany(IEnumerable<TEntity> entities)
        {
            return _commandRepository.DeleteMany(entities);
        }

        public void UpdateOne(TEntity entity)
        {
            _commandRepository.UpdateOne(entity);
        }

        public Task UpdateOneAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return _commandRepository.UpdateOneAsync(entity, cancellationToken);
        }

        public void UpdatePartial(TEntity entity)
        {
            _commandRepository.UpdatePartial(entity);
        }

        public Task UpdatePartialAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return _commandRepository.UpdatePartialAsync(entity, cancellationToken);
        }

        public void UpdateMany(IEnumerable<TEntity> entities)
        {
            _commandRepository.UpdateMany(entities);
        }

        public Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return _commandRepository.UpdateManyAsync(entities, cancellationToken);
        }
    }
}