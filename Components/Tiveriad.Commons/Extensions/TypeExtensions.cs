using System.Reflection;
using System.Runtime.CompilerServices;

namespace Tiveriad.Commons.Extensions;

public static class TypeExtensions
{
    private static readonly IDictionary<Type, HashSet<Type>> _childCache = new Dictionary<Type, HashSet<Type>>();

    /// <summary>Determines if <paramref name="type" /> is visible to <paramref name="assembly" />.</summary>
    /// <param name="type"><see cref="Type" /> to check.</param>
    /// <param name="assembly">Name of the <see cref="Assembly" />.</param>
    /// <returns>
    ///     <c>true</c> if <paramref name="type" /> is visible to
    ///     <paramref name="assembly" />; <c>false</c> otherwise.
    /// </returns>
    public static bool IsVisibleTo(this Type type, AssemblyName assembly)
    {
        if (type == null) throw new ArgumentNullException(nameof(type));
        if (assembly == null) throw new ArgumentNullException(nameof(assembly));

        return type.IsVisible || type.Assembly
            .GetCustomAttributes<InternalsVisibleToAttribute>()
            .Any(a => a.AssemblyName == assembly.Name);
    }

    /// <summary>Attempts to get the root generic type of <paramref name="type" />.</summary>
    /// <param name="type"><see cref="Type" /> to cast.</param>
    /// <returns>The casted <paramref name="type" /> if generic; null otherwise.</returns>
    public static Type AsGenericType(this Type type)
    {
        if (type == null) throw new ArgumentNullException(nameof(type));

        return type.IsGenericType ? type.GetGenericTypeDefinition() : null;
    }

    /// <summary>Checks if <paramref name="parent" /> inherits <typeparamref name="T" />.</summary>
    /// <typeparam name="T">Potential child <see cref="Type" /> of <paramref name="parent" />.</typeparam>
    /// <param name="parent">Potential parent <see cref="Type" /> of <typeparamref name="T" />.</param>
    /// <returns>
    ///     <c>true</c> if <paramref name="parent" /> inherits <typeparamref name="T" />; <c>false</c> otherwise.
    /// </returns>
    public static bool Inherits<T>(this Type parent)
    {
        return Inherits(parent, typeof(T));
    }

    /// <summary>Checks if <paramref name="parent" /> inherits <paramref name="child" />.</summary>
    /// <param name="parent">Potential parent <see cref="Type" /> of <paramref name="child" />.</param>
    /// <param name="child">Potential child <see cref="Type" /> of <paramref name="parent" />.</param>
    /// <returns>
    ///     <c>true</c> if <paramref name="parent" /> inherits <paramref name="child" />; <c>false</c> otherwise.
    /// </returns>
    public static bool Inherits(this Type parent, Type child)
    {
        return IsInheritedBy(child, parent);
    }

    /// <summary>Checks if <typeparamref name="T" /> inherits <paramref name="child" />.</summary>
    /// <typeparam name="T">Potential parent <see cref="Type" /> of <paramref name="child" />.</typeparam>
    /// <param name="child">Potential child <see cref="Type" /> of <typeparamref name="T" />.</param>
    /// <returns>
    ///     <c>true</c> if <typeparamref name="T" /> inherits <paramref name="child" />; <c>false</c> otherwise.
    /// </returns>
    public static bool IsInheritedBy<T>(this Type child)
    {
        return IsInheritedBy(child, typeof(T));
    }

    /// <inheritdoc cref="Inherits" />
    public static bool IsInheritedBy(this Type child, Type parent)
    {
        HashSet<Type> children;
        lock (_childCache)
        {
            if (!_childCache.TryGetValue(parent, out children))
                _childCache[parent] = children = new HashSet<Type>(FindChildren(parent).Distinct());
        }

        return children.Contains(child)
               || children.Contains(Nullable.GetUnderlyingType(child));
    }

    /// <summary>Finds all types <paramref name="type" /> inherits.</summary>
    /// <param name="type"><see cref="Type" /> to check.</param>
    /// <returns>The found types inherited by <paramref name="type" />.</returns>
    private static IEnumerable<Type> FindChildren(Type type)
    {
        if (type == null) yield break;

        yield return type;

        if (type.IsGenericType) yield return type.GetGenericTypeDefinition();

        foreach (var child in type.GetInterfaces().SelectMany(t => FindChildren(t))) yield return child;

        foreach (var child in FindChildren(type.BaseType)) yield return child;
    }
}