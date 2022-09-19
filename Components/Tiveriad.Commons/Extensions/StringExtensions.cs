using System.Globalization;
using System.Text;

namespace Tiveriad.Commons.Extensions;

public static class StringExtensions
{
    public static string ToCamelCase(this string value)
    {
        return char.ToLowerInvariant(value[0]) + value.Substring(1);
    }

    public static string ToDotPath(this string value)
    {
        var builder = new StringBuilder();
        foreach (var item in value)
        {
            if (builder.Length > 0 && char.IsUpper(item)) builder.Append('.');

            builder.Append(item);
        }
        return builder.ToString();
    }
    
}