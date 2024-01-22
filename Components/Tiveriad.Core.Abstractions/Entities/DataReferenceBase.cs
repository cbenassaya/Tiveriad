namespace Tiveriad.Core.Abstractions.Entities;

public class DataReferenceBase<TKey> : IDataReference<TKey> where TKey : IEquatable<TKey>
{
    public virtual TKey Id { get; set; } = default;
    public virtual TKey OrganizationId { get; set; } = default;
    public virtual string DocumentDescriptionId { get; set; } = default;
    public virtual InternationalizedString Label { get; set; } = string.Empty;
    public virtual string Description { get; set; } = string.Empty;
    public virtual string Code { get; set; } = string.Empty;
    public virtual Visibility Visibility { get; set; } = Visibility.Private;
}