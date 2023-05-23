#nullable enable

#region

using System;

#endregion

namespace Tiveriad.Repositories;

public interface IAuditable<TKey> where TKey : IEquatable<TKey>
{
    public TKey CreatedBy { get; set; }

    public DateTime Created { get; set; }

    public TKey? LastModifiedBy { get; set; }

    public DateTime? LastModified { get; set; }
}