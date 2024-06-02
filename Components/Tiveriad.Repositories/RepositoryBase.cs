#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Tiveriad.Commons.Extensions;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;

#endregion

namespace Tiveriad.Repositories;

public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>

{
    private readonly ICommandRepository<TEntity, TKey> _commandRepository;
    private readonly IQueryRepository<TEntity, TKey> _queryRepository;
    private readonly IOptionalService<ITenantService<TKey>> _optionalTenantService;

    public RepositoryBase(IQueryRepository<TEntity, TKey> queryRepository,
        ICommandRepository<TEntity, TKey> commandRepository, IOptionalService<ITenantService<TKey>> optionalTenantService)
    {
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
        _optionalTenantService = optionalTenantService;
    }

    public IQueryable<TEntity> Queryable
    {
        get {
            var queryable = _queryRepository.Queryable;
           
            var entityType = typeof(TEntity);
            if (_optionalTenantService.HasService && entityType.GetInterfaces().Contains(typeof(IWithTenant<TKey>)))
            {
                queryable = queryable.Where(x=>(
                        (IWithTenant<TKey>)x).Visibility == Visibility.Public ||
                        ((IWithTenant<TKey>)x).OrganizationId.Equals(_optionalTenantService.GetService().GetTenantId()));
            }
            return queryable;
            
        }
    }

    public bool Any()
    {
        var queryable = Queryable;
        return queryable.Any();
    }

    public bool Any(Expression<Func<TEntity, bool>> where)
    {

        var queryable = Queryable;
        queryable = queryable.Where(where);
        return queryable.Any();
    }

    public Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        var queryable = Queryable;
        return Task.FromResult( queryable.Any());
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
    {
        var queryable = Queryable;
        queryable = queryable.Where(where);
        return Task.FromResult( queryable.Any());
    }

    public long Count()
    {
        var queryable = Queryable;
        return queryable.Count();
    }

    public long Count(Expression<Func<TEntity, bool>> where)
    {
        var queryable = Queryable;
        queryable = queryable.Where(where);
        return queryable.Count();
    }

    public Task<long> CountAsync(CancellationToken cancellationToken = default)
    {
        var queryable = Queryable;
        return Task.FromResult( (long) queryable.Count());
    }

    public Task<long> CountAsync(Expression<Func<TEntity, bool>> where,
        CancellationToken cancellationToken = default)
    {
        var queryable = Queryable;
        queryable = queryable.Where(where);
        return Task.FromResult( (long) queryable.Count());
    }

    public IEnumerable<TEntity> GetAll()
    {
        var queryable = Queryable;
        return queryable.ToList();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var queryable = Queryable;
        return Task.FromResult( queryable.ToList().AsEnumerable());
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
    {
        var queryable = Queryable;
        queryable = queryable.Where(filter);
        return queryable.ToList().AsEnumerable();
    }

    public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        var queryable = Queryable;
        queryable = queryable.Where(filter);
        return Task.FromResult( queryable.ToList().AsEnumerable());
    }

    public TEntity GetById(TKey id)
    {
        var queryable = Queryable;
        queryable = queryable.Where(x=>x.Id.Equals(id));
        return queryable.First();
    }

    public Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        var queryable = Queryable;
        queryable = queryable.Where(x=>x.Id.Equals(id));
        return Task.FromResult( queryable.First());
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

    public void UpdateMany(IEnumerable<TEntity> entities)
    {
        _commandRepository.UpdateMany(entities);
    }

    public Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        return _commandRepository.UpdateManyAsync(entities, cancellationToken);
    }
}