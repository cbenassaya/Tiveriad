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

    public static IEnumerable<T> AsEnumerableItems<T>(this T value)
    {
        var values = new List<T>();
        if (value is IEnumerable<T> items)
            foreach (var obj in items)
                if (obj != null)
                    values.Add(obj);
        return values;
    }

    public static bool AtLeast<T>(this IEnumerable<T> source, int count)
    {
        return source.Take(count).Count() == count;
    }

    public static TResult[] SelectToArray<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
    {
        return source.Select(selector).ToArray();
    }
}