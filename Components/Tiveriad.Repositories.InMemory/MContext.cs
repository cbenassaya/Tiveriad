#region

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Repositories.InMemory;

public class MContext
{
    private readonly IDictionary<string, IList> _dictionary = new ConcurrentDictionary<string, IList>();

    public IQueryable<TEntity> QuerySet<TEntity>() where TEntity : class, IEntity
    {
        IList enumerable = null;
        if (!_dictionary.TryGetValue(typeof(TEntity).Name, out enumerable))
        {
            enumerable = new List<TEntity>();
            _dictionary.Add(typeof(TEntity).Name, enumerable);
        }

        return enumerable.OfType<TEntity>().AsQueryable();
    }

    public IList<TEntity> CommandSet<TEntity>() where TEntity : class, IEntity
    {
        IList enumerable = null;
        if (!_dictionary.TryGetValue(typeof(TEntity).Name, out enumerable))
        {
            enumerable = new List<TEntity>();
            _dictionary.Add(typeof(TEntity).Name, enumerable);
        }

        return enumerable.OfType<TEntity>().ToList();
    }
}