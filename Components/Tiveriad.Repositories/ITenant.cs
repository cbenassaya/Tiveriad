namespace Tiveriad.Repositories;

public interface IWithTenant
{
    /// <summary>
    /// Id of the related tenant.
    /// </summary>
    public string TenantId { get; }
}