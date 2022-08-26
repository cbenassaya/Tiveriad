using System;

namespace Tiveriad.Repositories
{
    public interface IEntity
    {
    }

    /// <summary>
    ///     This class represents a basic document that can be stored in MongoDb.
    ///     Your document must implement this class in order for the MongoDbRepository to handle them.
    /// </summary>
    public interface IEntity<TKey> : IEntity where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     The Primary Key, which must be decorated with the [BsonId] attribute
        ///     if you want the MongoDb C# driver to consider it to be the document ID.
        /// </summary>
        public TKey Id { get; set; }
    }


    public interface IBusinessEntity<TKey> : IEntity<TKey> where TKey : IEquatable<TKey>
    {
        public bool IsArchived { get; set; }
        public int Visibility { get; set; } //0:private/1:public/2:protected     
        public TKey OwnerId { get; set; }
    }
}