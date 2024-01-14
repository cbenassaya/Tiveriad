namespace Tiveriad.Cache.Internal;

/// <summary>
///     Can be used to decorate cache handles which require serialization
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class RequiresSerializerAttribute : Attribute
{
}