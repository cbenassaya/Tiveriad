using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tiveriad.Repositories.EntityFrameworkCore.Repositories
{
    public class SetIdCommand
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

            if (entity.Id == null || entity.Id.Equals(defaultValue)) entity.Id = (TKey)IdGenerator.IdGenerator.NewId<TKey>();

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
    }
}