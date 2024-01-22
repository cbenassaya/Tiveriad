namespace Tiveriad.Core.Abstractions.Services;

public interface IKeyParser<TKey> where TKey : IEquatable<TKey>
{
    TKey Parse(string? key);
}