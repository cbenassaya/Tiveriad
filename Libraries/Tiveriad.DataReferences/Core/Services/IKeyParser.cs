namespace Tiveriad.DataReferences.Apis.Services;

public interface IKeyParser<TKey> where TKey : IEquatable<TKey>
{
    TKey Parse(string? key);
}