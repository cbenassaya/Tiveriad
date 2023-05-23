#region

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

#endregion

#pragma warning disable SYSLIB0011 // Type or member is obsolete

namespace Tiveriad.Commons.Cloning.CopyHints;

/// <summary>Handles copying serializables for the cloner.</summary>
public sealed class SerializableCopyHint : CopyHint
{
    /// <summary>Handles the serialization process.</summary>
    private static readonly IFormatter _Serializer = new BinaryFormatter();

    /// <inheritdoc />
    protected internal override (bool, object) TryCopy(object source, CloneChainer clone)
    {
        if (source == null) return (true, null);

        if (source is ISerializable && source.GetType().IsSerializable)
            using (Stream stream = new MemoryStream())
            {
                _Serializer.Serialize(stream, source);
                _ = stream.Seek(0, SeekOrigin.Begin);
                return (true, _Serializer.Deserialize(stream));
            }

        return (false, null);
    }
}

#pragma warning restore SYSLIB0011 // Type or member is obsolete