#region

using System.Collections;
using System.Collections.Concurrent;
using Tiveriad.Commons.Extensions;

#endregion

namespace Tiveriad.Commons.Cloning.CopyHints;

/// <summary>Handles copying collections for the cloner.</summary>
public sealed class CollectionCopyHint : CopyHint<IEnumerable>
{
    /// <summary>Special cases where the data needs to be reversed.</summary>
    private static readonly Type[] _ReverseCases =
    {
        typeof(ConcurrentStack<>),
        typeof(Stack<>),
        typeof(Stack)
    };

    /// <inheritdoc />
    protected override IEnumerable Copy(IEnumerable source, CloneChainer clone)
    {
        if (clone == null) throw new ArgumentNullException(nameof(clone));
        if (source == null) return source;

        var type = source.GetType();
        if (type.IsArray)
            return CopyContents(source, clone);
        return (IEnumerable)Activator.CreateInstance(type, CopyContents(source, clone));
    }

    /// <summary>Copies the contents of <paramref name="source" />.</summary>
    /// <param name="source">Collection with contents to copy.</param>
    /// <param name="clone">Handles callback behavior for child values.</param>
    /// <returns>Clone of <paramref name="source" />'s elements.</returns>
    private static IEnumerable CopyContents(IEnumerable source, CloneChainer clone)
    {
        var type = source.GetType();
        var genericType = type.AsGenericType();

        var data = CopyContentsHelper(source, clone,
            _ReverseCases.Contains(genericType ?? type));

        if (genericType != null)
        {
            var args = type.GetGenericArguments();
            var itemType = args.Length != 1
                ? typeof(KeyValuePair<,>).MakeGenericType(args)
                : args.Single();

            return ArrayCast(itemType, data);
        }

        if (type.IsArray)
            return ArrayCast(type.GetElementType(), data);
        return data;
    }

    /// <summary>Convert <paramref name="data" /> to <paramref name="elementType" /> array.</summary>
    /// <param name="elementType">Array type to create.</param>
    /// <param name="data">Array to convert.</param>
    /// <returns>The converted array.</returns>
    private static Array ArrayCast(Type elementType, object[] data)
    {
        var result = Array.CreateInstance(elementType, data.Length);
        for (var i = 0; i < data.Length; i++) result.SetValue(data[i], i);
        return result;
    }

    /// <summary>Copies the contents of <paramref name="source" />.</summary>
    /// <param name="source">Collection with contents to copy.</param>
    /// <param name="clone">Handles callback behavior for child values.</param>
    /// <param name="reverse">If the copy process should reverse the order of items from the enumerator.</param>
    /// <returns>The duplicate object.</returns>
    private static object[] CopyContentsHelper(IEnumerable source, CloneChainer clone, bool reverse)
    {
        List<object> copy = new();

        var enumerator = source.GetEnumerator();
        while (enumerator.MoveNext()) copy.Add(clone.Copy(enumerator.Current));

        if (reverse) copy.Reverse();

        return copy.ToArray();
    }
}