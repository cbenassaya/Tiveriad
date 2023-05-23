#region

using System;

#endregion

namespace Tiveriad.Repositories;

/// <summary>
///     This class represents a basic entity that can be stored.
/// </summary>
public abstract class EntityBase<TKey> : IVersionable, IEntity<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    ///     The Id of the document
    /// </summary>
    public virtual TKey Id { get; set; }

    /// <summary>
    ///     The version of the schema of the document
    /// </summary>
    public virtual int Version { get; set; }
}