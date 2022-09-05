namespace Tiveriad.Commons.Cloning.CopyHints;

/// <summary>Handles copying cloneables for the cloner.</summary>
public sealed class CloneableCopyHint : CopyHint<ICloneable>
{
    /// <inheritdoc />
    protected override ICloneable Copy(ICloneable source, CloneChainer clone)
    {
        return (ICloneable)source?.Clone();
    }
}