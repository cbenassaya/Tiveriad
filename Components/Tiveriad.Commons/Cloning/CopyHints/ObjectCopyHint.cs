using System.Reflection;
using Tiveriad.Commons.Extensions;

namespace Tiveriad.Commons.Cloning.CopyHints;

/// <summary>Handles copying objects for the cloner.</summary>
public sealed class ObjectCopyHint : CopyHint
{
    /// <summary>Flags used to identify members.</summary>
    private const BindingFlags _MemberFlags = BindingFlags.Public
                                              | BindingFlags.NonPublic | BindingFlags.Instance;

    /// <inheritdoc />
    protected internal override (bool, object) TryCopy(object source, CloneChainer clone)
    {
        if (clone == null) throw new ArgumentNullException(nameof(clone));
        if (source == null) return (true, null);

        var result = Copy(source, clone);
        return (result != null, result);
    }

    /// <summary>Deep clones <paramref name="source" />.</summary>
    /// <param name="source">Object to clone.</param>
    /// <param name="clone">Handles callback behavior for child values.</param>
    /// <returns>Clone of <paramref name="source" />.</returns>
    private static object Copy(object source, CloneChainer clone)
    {
        var dupe = CreateNew(source, clone);
        if (dupe == null) return dupe;
        clone.AddToHistory(source, dupe);

        foreach (var field in source.GetType()
                     .GetFields(BindingFlags.Instance | BindingFlags.Public)
                     .Where(f => !f.IsInitOnly && !f.IsLiteral))
            field.SetValue(dupe, clone.Copy(field.GetValue(source)));

        foreach (var property in source.GetType()
                     .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                     .Where(p => p.CanRead && p.CanWrite))
            property.SetValue(dupe, clone.Copy(property.GetValue(source)));

        return dupe;
    }

    /// <summary>Creates an instance of <paramref name="source" />'s <see cref="Type" />.</summary>
    /// <param name="source">Object whose <see cref="Type" /> is to be created.</param>
    /// <param name="clone">Handles callback behavior for child values.</param>
    /// <returns>The created instance.</returns>
    private static object CreateNew(object source, CloneChainer clone)
    {
        var type = source.GetType();

        if (type.GetConstructor(Type.EmptyTypes) != null)
        {
            return Activator.CreateInstance(type);
        }

        var props = type.GetProperties(_MemberFlags).Where(p => p.CanRead).ToArray();
        var fields = type.GetFields(_MemberFlags).ToArray();

        return type.GetConstructors(_MemberFlags)
            .Where(c => !c.IsPrivate)
            .OrderByDescending(c => c.GetParameters().Length)
            .Select(c => TryCreate(source, clone, c, props, fields))
            .FirstOrDefault(o => o != null);
    }

    /// <summary>Attempts to create an instance using a <paramref name="constructor" />.</summary>
    /// <param name="source">Object being cloned.</param>
    /// <param name="clone">Handles callback behavior for child values.</param>
    /// <param name="constructor">Constructor on <paramref name="source" /> to use.</param>
    /// <param name="props">Properties on <paramref name="source" />.</param>
    /// <param name="fields">Fields on <paramref name="source" />.</param>
    /// <returns>Null if failed; created instance otherwise.</returns>
    private static object TryCreate(object source, CloneChainer clone,
        ConstructorInfo constructor, IEnumerable<PropertyInfo> props, IEnumerable<FieldInfo> fields)
    {
        var propList = props.ToList();
        var fieldList = fields.ToList();

        // Attempts to match members with parameters in the constructor.
        List<MemberInfo> matchedMembers = new();
        foreach (var param in constructor.GetParameters())
        {
            var potentialProps = propList
                .Where(p => p.PropertyType.Inherits(param.ParameterType))
                .ToArray();
            if (potentialProps.Any())
            {
                var directPropMatch = potentialProps.FirstOrDefault(
                    p => p.Name.Equals(param.Name, StringComparison.OrdinalIgnoreCase));
                if (directPropMatch != null)
                {
                    _ = propList.Remove(directPropMatch);
                    matchedMembers.Add(directPropMatch);
                }
                else
                {
                    _ = propList.Remove(potentialProps.First());
                    matchedMembers.Add(potentialProps.First());
                }

                continue;
            }

            var potentialFields = fieldList
                .Where(f => f.FieldType.Inherits(param.ParameterType))
                .ToArray();
            if (potentialFields.Any())
            {
                var directFieldMatch = potentialFields.FirstOrDefault(
                    f => f.Name.Equals(param.Name, StringComparison.OrdinalIgnoreCase));
                if (directFieldMatch != null)
                {
                    _ = fieldList.Remove(directFieldMatch);
                    matchedMembers.Add(directFieldMatch);
                }
                else
                {
                    _ = fieldList.Remove(potentialFields.First());
                    matchedMembers.Add(potentialFields.First());
                }

                continue;
            }

            return null;
        }

        return constructor.Invoke(matchedMembers.Select(m => CopyMember(m, source, clone)).ToArray());
    }

    /// <summary>Copies the value of <paramref name="member" /> on <paramref name="source" />.</summary>
    /// <param name="member">Property or field to copy.</param>
    /// <param name="source">Instance containing the member.</param>
    /// <param name="clone">Cloner handling the cloning.</param>
    /// <returns>The duplicate object.</returns>
    private static object CopyMember(MemberInfo member, object source, CloneChainer clone)
    {
        if (member is PropertyInfo prop)
            return clone.Copy(prop.GetValue(source));
        return clone.Copy(((FieldInfo)member).GetValue(source));
    }
}