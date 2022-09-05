using System.Collections;
using System.Collections.Specialized;

// Return not available on all .NET versions.
#pragma warning disable IDE0058 // Expression value is never used

namespace Tiveriad.Commons.Cloning.CopyHints;

/// <summary>Handles copying legacy collections for the cloner.</summary>
public sealed class LegacyCollectionCopyHint : CopyHint
{
    /// <summary>Supported types and the methods used to generate them.</summary>
    private static readonly IDictionary<Type, Func<object, CloneChainer, object>> _Copiers
        = new Dictionary<Type, Func<object, CloneChainer, object>>
        {
            { typeof(Hashtable), CreateAndCopy<Hashtable> },
            { typeof(SortedList), CreateAndCopy<SortedList> },
            { typeof(ListDictionary), CreateAndCopy<ListDictionary> },
            { typeof(HybridDictionary), CreateAndCopy<HybridDictionary> },
            { typeof(OrderedDictionary), CreateAndCopy<OrderedDictionary> },

            { typeof(BitArray), (data, cloner) => new BitArray((BitArray)data) },
            { typeof(NameValueCollection), (data, cloner) => new NameValueCollection((NameValueCollection)data) },

            {
                typeof(StringCollection), (data, cloner) =>
                {
                    StringCollection result = new();
                    foreach (var item in (StringCollection)data) result.Add(item);
                    return result;
                }
            },
            {
                typeof(StringDictionary), (data, cloner) =>
                {
                    StringDictionary result = new();
                    foreach (DictionaryEntry entry in (StringDictionary)data)
                        result.Add((string)entry.Key, (string)entry.Value);
                    return result;
                }
            }
        };

    /// <inheritdoc />
    protected internal override (bool, object) TryCopy(object source, CloneChainer clone)
    {
        if (clone == null) throw new ArgumentNullException(nameof(clone));
        if (source == null) return (true, null);

        if (_Copiers.TryGetValue(source.GetType(), out var copier))
            return (true, copier.Invoke(source, clone));
        return (false, null);
    }

    /// <summary>Clones <paramref name="source" />.</summary>
    /// <typeparam name="T">Collection type being cloned.</typeparam>
    /// <param name="source">Collection to clone.</param>
    /// <param name="clone">Handles callback behavior for child values.</param>
    /// <returns>Clone of <paramref name="source" />.</returns>
    private static T CreateAndCopy<T>(object source, CloneChainer clone) where T : IDictionary, new()
    {
        T result = new();
        foreach (DictionaryEntry entry in (T)source)
            result.Add(clone.Copy(entry.Key), clone.Copy(entry.Value));
        return result;
    }
}

#pragma warning restore IDE0058 // Expression value is never used