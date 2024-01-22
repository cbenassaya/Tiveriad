#region

using System;
using Tiveriad.Commons.Reflexions;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.IdGenerators;

#endregion

namespace Tiveriad.Repositories.EntityFrameworkCore.Repositories;

public class SetIdCommand<TKey> : AbstractProcessor<IEntity<TKey>> where TKey : IEquatable<TKey>
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

/*public class SetIdCommand
{
    private readonly IList<int> _hashListOfFoundElements = new List<int>();

    private bool AlreadyTouched(object value)
    {
        if (value == null) return false;
        return _hashListOfFoundElements.Contains(value.GetHashCode());
    }

    public void SetId<TKey>(IEntity<TKey> entity) where TKey : IEquatable<TKey>
    {
        if (entity == null) return;

        _hashListOfFoundElements.Add(entity.GetHashCode());

        var defaultValue = default(TKey);

        if (entity.Id == null || entity.Id.Equals(defaultValue)) entity.Id = (TKey)IdGenerator.KeyGenerator.NewId<TKey>();

        var propertyInfos = entity.GetType().GetProperties()
            .Where(x => x.CanRead && x.GetIndexParameters().Length == 0).ToList();


        foreach (var propertyInfo in propertyInfos)
        {
            var value = propertyInfo.GetValue(entity, null);

            if (value is null or string or ValueType) continue;

            if (value is IEnumerable)
                foreach (var item in value.AsEnumerableItems())
                    if (item is IEntity<TKey> && !AlreadyTouched(item))
                        SetId(item as IEntity<TKey>);

            if (value is IEntity<TKey> && !AlreadyTouched(value))
                SetId(value as IEntity<TKey>);
        }
    }
}*/