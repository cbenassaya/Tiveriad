using System.Runtime.Serialization;
using Tiveriad.Commons.Extensions;

namespace Tiveriad.Commons.Cloning.CopyHints;

/// <summary>Handles copying basic types for the cloner.</summary>
public sealed class BasicCopyHint : CopyHint
{
    /// <inheritdoc />
    protected internal override (bool, object) TryCopy(object source, CloneChainer clone)
    {
        var type = source?.GetType();
        if (type == null
            || type.IsPrimitive
            || type.IsEnum
            || type == typeof(object)
            || type == typeof(string)
            || type.Inherits<IObjectReference>())
            return (true, source);
        return (false, null);
    }
}