using System;

namespace Tiveriad.Repositories
{
    /// <summary>
    ///     This contract represents a basic entity that can be stored.
    /// </summary>
    public interface IEntity
    {
    }

    /// <summary>
    ///     This contract represents a basic entity that can be stored.
    /// </summary>
    public interface IEntity<TKey> : IEntity where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     The Primary Key
        /// </summary>
        public TKey Id { get; set; }
    }
}