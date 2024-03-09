namespace Tiveriad.Core.Abstractions.Services;

public interface ITenantService<TKey> where TKey : IEquatable<TKey>
{
    TKey GetTenantId();
}