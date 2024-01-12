namespace Tiveriad.DataReferences.Apis.Services;

public interface ITenantService<TKey> where TKey : IEquatable<TKey>
{
    TKey GetOrganizationId();
}