namespace Tiveriad.TextTemplating.Extensions;

public static class StringExtensions
{
    public static string ToResourceName(this string value)
    {
        var temp = value.Split(".");

        return $"{temp[temp.Length - 2]}.{temp[temp.Length - 1]}";
    }
}