#region

using System.Reflection;

#endregion

namespace Tiveriad.Commons.Cloning.CopyHints;

/// <summary>Handles copying common types for the cloner.</summary>
public sealed class CommonSystemCopyHint : CopyHint
{
    /// <inheritdoc />
    protected internal override (bool, object) TryCopy(object source, CloneChainer clone)
    {
        if (clone == null) throw new ArgumentNullException(nameof(clone));
        if (source == null) return (true, null);

        if (source is TimeSpan span)
            return (true, new TimeSpan(clone.Copy(span.Ticks)));
        if (source is Uri link)
            return (true, new Uri(link.OriginalString));
        if (source is WeakReference reference)
            return (true, new WeakReference(reference.Target, reference.TrackResurrection));
        if (source is MemberInfo member)
            return (true, member);
        return (false, null);
    }
}