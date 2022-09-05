namespace Tiveriad.Commons.Cloning;

/// <summary>Handles copying specific types for the cloner.</summary>
public abstract class CopyHint
{
    /// <summary>Tries to deep clone <paramref name="source" />.</summary>
    /// <param name="source">Object to clone.</param>
    /// <param name="clone">Handles callback behavior for child values.</param>
    /// <returns>
    ///     (<c>true</c>, clone of <paramref name="source" />) if successful;
    ///     (<c>false</c>, <c>null</c>) otherwise.
    /// </returns>
    protected internal abstract (bool, object) TryCopy(object source, CloneChainer clone);
}

/// <typeparam name="T">Type to handle.</typeparam>
/// <inheritdoc />
public abstract class CopyHint<T> : CopyHint
{
    /// <inheritdoc />
    protected internal sealed override (bool, object) TryCopy(object source, CloneChainer clone)
    {
        if (source == null)
            return (true, Copy(default, clone));
        if (source is T data)
            return (true, Copy(data, clone));
        return (false, null);
    }

    /// <summary>Deep clones <paramref name="source" />.</summary>
    /// <param name="source">Object to clone.</param>
    /// <param name="clone">Handles callback behavior for child values.</param>
    /// <returns>Clone of <paramref name="source" />.</returns>
    protected abstract T Copy(T source, CloneChainer clone);
}