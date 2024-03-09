#region

#endregion

namespace Tiveriad.Core.Abstractions.Entities;

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

public abstract class PagedResultBase
{
    public int Page { get; set; } 
    public int PageCount { get; set; } 
    public int Limit { get; set; } 
    public int RowCount { get; set; }
 
    public int FirstRowOnPage
    {
        get { return (Page - 1) * Limit + 1; }
    }
 
    public int LastRowOnPage
    {
        get { return Math.Min(Page * Limit, RowCount); }
    }
}
 
public class PagedResult<T> : PagedResultBase where T : class
{
    public List<T> Items { get; set; }
}