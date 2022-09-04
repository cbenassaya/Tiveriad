using System;
using System.Collections;
using System.Collections.Generic;

namespace Tiveriad.Repositories.EntityFrameworkCore.Repositories
{
    public static class ReflectionExtensions
    {
        private static bool IsEnumerable(this Type type)
        {
            return type.IsGenericType &&
                   type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
        }

        public static IEnumerable<object> AsEnumerableItems(this object value)
        {
            var values = new List<object>();
            if (value is IEnumerable items)
                foreach (var obj in items)
                    if (obj != null)
                        values.Add(obj);
            return values;
        }
    }
}