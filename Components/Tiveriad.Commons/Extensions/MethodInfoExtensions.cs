using System.Reflection;
using System.Runtime.CompilerServices;

namespace Tiveriad.Commons.Extensions;

public static class MethodInfoExtensions
{
    public static string ExtractMethodNameOrAnonymous(this MethodInfo methodInfo)
    {
        return
            methodInfo.IsLambda()
                ? "anonymous"
                : methodInfo.Name;
    }

    private static bool IsLambda(this MethodInfo methodInfo)
    {
        return methodInfo
            .DeclaringType != null && methodInfo
            .DeclaringType
            .GetTypeInfo()
            .GetCustomAttributes(typeof(CompilerGeneratedAttribute), false)
            .Any();
    }
}