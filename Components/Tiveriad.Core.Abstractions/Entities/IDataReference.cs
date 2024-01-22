#region

#endregion

namespace Tiveriad.Core.Abstractions.Entities;

public interface IDataReference<TKey> : IEntity<TKey>, IWithTenant<TKey> where TKey : IEquatable<TKey>
{
    public  string?DocumentDescriptionId { get; set; } 
    public InternationalizedString Label { get; set; }
    public string? Description { get; set; }
    public string Code { get; set; }
    public Visibility Visibility { get; set; }
}