#nullable enable
using System;

namespace Tiveriad.Repositories
{
    public interface IVersionable
    {
        /// <summary>
        ///     A version number, to indicate the version of the schema.
        /// </summary>
        int Version { get; set; }
    }

    public interface IAuditable<TKey> where TKey : IEquatable<TKey>
    {
        public TKey CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public TKey? LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}