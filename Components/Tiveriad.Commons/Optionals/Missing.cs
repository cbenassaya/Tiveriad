// --------------------------------------------------------------------------------------------------------------------

namespace Tiveriad.Commons.Optionals;

public sealed class Missing
{
    public static readonly Missing Value = new();

    private Missing()
    {
    }
}