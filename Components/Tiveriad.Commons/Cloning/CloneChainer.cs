#region

using System.Runtime.CompilerServices;

#endregion

namespace Tiveriad.Commons.Cloning;

/// <summary>Provides a callback into the cloner to create child values.</summary>
public sealed class CloneChainer
{
    /// <summary>Callback to the cloner to handle child values.</summary>
    private readonly Func<object, CloneChainer, object> _callback;

    /// <summary>History of clones to match up references.</summary>
    private readonly ConditionalWeakTable<object, object> _history;

    /// <summary>Initializes a new instance of the <see cref="CloneChainer" /> class.</summary>
    /// <param name="cloner">Reference to the actual cloner.</param>
    /// <param name="callback">Callback to the cloner to handle child values.</param>
    public CloneChainer(ICloner cloner, Func<object, CloneChainer, object> callback)
    {
        Cloner = cloner ?? throw new ArgumentNullException(nameof(cloner));
        _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        _history = new ConditionalWeakTable<object, object>();
    }

    /// <summary>Reference to the actual cloner.</summary>
    internal ICloner Cloner { get; }

    /// <summary>Adds successful clone details to history.</summary>
    /// <param name="source">Object cloned.</param>
    /// <param name="clone">The clone.</param>
    public void AddToHistory(object source, object clone)
    {
        if (CanTrack(source)) _history.Add(source, clone);
    }

    /// <typeparam name="T">Type being cloned.</typeparam>
    /// <inheritdoc cref="Copy" />
    public T Copy<T>(T source)
    {
        return (T)Copy((object)source);
    }

    /// <summary>Deep clones <paramref name="source" />.</summary>
    /// <param name="source">Object to clone.</param>
    /// <returns>Clone of <paramref name="source" />.</returns>
    /// <exception cref="NotSupportedException">If no hint supports cloning the object.</exception>
    public object Copy(object source)
    {
        RuntimeHelpers.EnsureSufficientExecutionStack();
        if (!CanTrack(source)) return _callback.Invoke(source, this);

        if (_history.TryGetValue(source, out var clone)) return clone;

        var result = _callback.Invoke(source, this);
        if (!_history.TryGetValue(source, out _)) _history.Add(source, result);
        return result;
    }

    /// <summary>If <paramref name="source" /> can be tracked in history.</summary>
    /// <param name="source">Item to check.</param>
    /// <returns><c>true</c> if possible; <c>false</c> otherwise.</returns>
    private static bool CanTrack(object source)
    {
        return !(source == null || source.GetType().IsValueType);
    }
}