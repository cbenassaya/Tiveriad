using Tiveriad.Commons.Cloning.CopyHints;

namespace Tiveriad.Commons.Cloning;

/// <inheritdoc cref="ICloner" />
public sealed class Cloner : ICloner
{
    /// <summary>Default set of hints to use for copying.</summary>
    private static readonly CopyHint[] _DefaultHints =
    {
        new CommonSystemCopyHint(),
        new TaskCopyHint(),
        new BasicCopyHint(),
        new AsyncCollectionCopyHint(),
        new LegacyCollectionCopyHint(),
        new CollectionCopyHint(),
        new CloneableCopyHint(),
        new SerializableCopyHint(),
        new ObjectCopyHint()
    };


    /// <summary>Hints used to copy specific types.</summary>
    private readonly IList<CopyHint> _hints;

    /// <summary>Initializes a new instance of the <see cref="Cloner" /> class.</summary>
    /// <param name="includeDefaultHints">If the default set of hints should be added.</param>
    /// <param name="hints">Hints used to copy specific types.</param>
    public Cloner(bool includeDefaultHints = true, params CopyHint[] hints)
    {
        var inputHints = hints ?? Enumerable.Empty<CopyHint>();
        _hints = includeDefaultHints
            ? inputHints.Concat(_DefaultHints).ToList()
            : inputHints.ToList();
    }

    /// <inheritdoc />
    public T Copy<T>(T source)
    {
        try
        {
            var result = Copy(source, new CloneChainer(this, Copy));
            return result;
        }
        catch (InsufficientExecutionStackException)
        {
            throw new InsufficientExecutionStackException(
                $"Ran into infinite generation trying to duplicate type '{source.GetType().Name}'.");
        }
    }


    /// <inheritdoc />
    public void AddHint(CopyHint hint)
    {
        _hints.Insert(0, hint ?? throw new ArgumentNullException(nameof(hint)));
    }

    /// <summary>Deep clones <paramref name="source" />.</summary>
    /// <typeparam name="T">Type being cloned.</typeparam>
    /// <param name="source">Object to clone.</param>
    /// <param name="chainer">Handles callback behavior for child values.</param>
    /// <returns>Clone of <paramref name="source" />.</returns>
    /// <exception cref="NotSupportedException">If no hint supports cloning the object.</exception>
    private T Copy<T>(T source, CloneChainer chainer)
    {
        if (source == null) return default;

        var result = _hints
            .Select(h => h.TryCopy(source, chainer))
            .FirstOrDefault(r => r.Item1);

        if (!result.Equals(default))
            return (T)result.Item2;
        throw new NotSupportedException(
            $"Type '{source.GetType().FullName}' not supported by the cloner. " +
            "Create a hint to generate the type and pass it to the cloner.");
    }
}