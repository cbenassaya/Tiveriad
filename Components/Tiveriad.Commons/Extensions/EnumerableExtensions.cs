using System.Collections;

namespace Tiveriad.Commons.Extensions;

public static class EnumerableExtensions
{
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