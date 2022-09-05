using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tiveriad.Commons.Reflexions;
using Tiveriad.IdGenerator;

namespace Tiveriad.Repositories.EntityFrameworkCore.Repositories;

public class DetachedCommand2<TKey> : AbstractProcessor<IEntity<TKey>> where TKey : IEquatable<TKey>
{
    protected override bool ApplyIf(IEntity<TKey> entity)
    {
        var defaultValue = default(TKey);
        return entity.Id == null || entity.Id.Equals(defaultValue);
    }

    protected override void DoApply(IEntity<TKey> entity)
    {
        entity.Id = KeyGenerator.NewId<TKey>();
    }
}

public class DetachedCommand
{
    private readonly Action<object> _detachedDelegate;

    private readonly IList<int> _hashListOfFoundElements = new List<int>();

    public DetachedCommand(Action<object> detachedDelegate)
    {
        _detachedDelegate = detachedDelegate;
    }

    private bool AlreadyTouched(object value)
    {
        if (value == null) return false;
        return _hashListOfFoundElements.Contains(value.GetHashCode());
    }

    public void DetachChildren(object entity)
    {
        if (entity == null) return;

        _hashListOfFoundElements.Add(entity.GetHashCode());

        var propertyInfos = entity.GetType().GetProperties()
            .Where(x => x.CanRead && x.GetIndexParameters().Length == 0).ToList();

        foreach (var propertyInfo in propertyInfos)
        {
            if (propertyInfo.GetCustomAttributes(typeof(IgnoredAttribute)).Any())
                continue;

            var value = propertyInfo.GetValue(entity, null);

            if (value is null or string or ValueType) continue;

            if (value is IEntity)
                if (propertyInfo.GetCustomAttributes(typeof(DetachedAttribute)).Any())
                    _detachedDelegate(value);
                else if (!AlreadyTouched(value))
                    DetachChildren(value);

            if (value is IEnumerable)
                foreach (var item in value.AsEnumerableItems())
                    if (propertyInfo.GetCustomAttributes(typeof(DetachedAttribute)).Any())
                        _detachedDelegate(item);
                    else if (!AlreadyTouched(item))
                        DetachChildren(item);
        }
    }
}