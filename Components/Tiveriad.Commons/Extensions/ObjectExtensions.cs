#region

using Tiveriad.Commons.Cloning;

#endregion

namespace Tiveriad.Commons.Extensions;

public static class ObjectExtensions
{
    public static object Clone(this object value)
    {
        var cloner = new Cloner();
        return cloner.Copy(value);
    }
}