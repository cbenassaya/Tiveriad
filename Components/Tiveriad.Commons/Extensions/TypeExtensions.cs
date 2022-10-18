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

    public static bool ImplementsGenericInterface(this Type type, Type interfaceType)
    {
        return type.IsGenericType(interfaceType) || type.GetTypeInfo().ImplementedInterfaces
            .Any(@interface => @interface.IsGenericType(interfaceType));
    }

    public static bool IsGenericType(this Type type, Type genericType)
    {
        return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == genericType;
    }

    public static bool IsOpenGeneric(this Type type)
    {
        return type.GetTypeInfo().IsGenericTypeDefinition || type.GetTypeInfo().ContainsGenericParameters;
    }

    public static bool IsConcrete(this Type type)
    {
        return !type.GetTypeInfo().IsAbstract && !type.GetTypeInfo().IsInterface;
    }

    public static IEnumerable<Type> FindInterfacesThatClose(this Type pluggedType, Type templateType)
    {
        return FindInterfacesThatClosesCore(pluggedType, templateType).Distinct();
    }

    public static IEnumerable<Type> FindInterfacesThatClosesCore(Type pluggedType, Type templateType)
    {
        if (pluggedType == null) yield break;

        if (!pluggedType.IsConcrete()) yield break;

        if (templateType.GetTypeInfo().IsInterface)
            foreach (
                var interfaceType in
                pluggedType.GetInterfaces()
                    .Where(type => type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == templateType))
                yield return interfaceType;
        else if (pluggedType.GetTypeInfo().BaseType.GetTypeInfo().IsGenericType &&
                 pluggedType.GetTypeInfo().BaseType.GetGenericTypeDefinition() == templateType)
            yield return pluggedType.GetTypeInfo().BaseType;

        if (pluggedType.GetTypeInfo().BaseType == typeof(object)) yield break;

        foreach (var interfaceType in FindInterfacesThatClosesCore(pluggedType.GetTypeInfo().BaseType, templateType))
            yield return interfaceType;
    }

    public static bool CanBeCastTo(this Type from, Type to)
    {
        if (from == null) return false;

        if (from == to) return true;

        return to.GetTypeInfo().IsAssignableFrom(from.GetTypeInfo());
    }

    public static bool CouldCloseTo(this Type openConcretion, Type closedInterface)
    {
        var openInterface = closedInterface.GetGenericTypeDefinition();
        var arguments = closedInterface.GenericTypeArguments;

        var concreteArguments = openConcretion.GenericTypeArguments;
        return arguments.Length == concreteArguments.Length && openConcretion.CanBeCastTo(openInterface);
    }
}