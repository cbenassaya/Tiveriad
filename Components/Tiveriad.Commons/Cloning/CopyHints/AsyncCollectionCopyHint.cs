#region

using System.Reflection;
using Tiveriad.Commons.Extensions;

#endregion

namespace Tiveriad.Commons.Cloning.CopyHints;

/// <summary>Handles copying async collections for the cloner.</summary>
public sealed class AsyncCollectionCopyHint : CopyHint
{
    /// <inheritdoc />
    protected internal override (bool, object) TryCopy(object source, CloneChainer clone)
    {
        if (clone == null) throw new ArgumentNullException(nameof(clone));
        if (source == null) return (true, null);

        var sourceType = source.GetType();

        if (sourceType.Inherits(typeof(IAsyncEnumerable<>)))
            return (true, GetType()
                .GetMethod(nameof(CopyAsync), BindingFlags.Static | BindingFlags.NonPublic)
                .MakeGenericMethod(sourceType.GetGenericArguments().Single())
                .Invoke(null, new[] { source, clone }));
        return (false, null);
    }

    /// <summary>Deep clones <paramref name="source" />.</summary>
    /// <typeparam name="T">Item type being copied.</typeparam>
    /// <param name="source">Object to clone.</param>
    /// <param name="clone">Handles callback behavior for child values.</param>
    /// <returns>Clone of <paramref name="source" />.</returns>
    private static async IAsyncEnumerable<T> CopyAsync<T>(IAsyncEnumerable<T> source, CloneChainer clone)
    {
        await foreach (var item in source) yield return clone.Copy(item);
    }
}