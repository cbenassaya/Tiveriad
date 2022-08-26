using System;

namespace Tiveriad.Repositories
{
    /// <summary>
    ///     This class represents a basic document that can be stored in MongoDb.
    ///     Your document must implement this class in order for the MongoDbRepository to handle them.
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


    public abstract class BusinessEntityBase<TKey> : IVersionable, IBusinessEntity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     The Id of the document
        /// </summary>
        public virtual TKey Id { get; set; }

        public bool IsArchived { get; set; }

        public int Visibility { get; set; }

        public TKey OwnerId { get; set; }

        /// <summary>
        ///     The version of the schema of the document
        /// </summary>
        public virtual int Version { get; set; }
    }


    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DetachedAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class IgnoredAttribute : Attribute
    {
    }
}