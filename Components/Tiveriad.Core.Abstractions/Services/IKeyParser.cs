namespace Tiveriad.Core.Abstractions.Services;

public interface IKeyParser<TKey> where TKey : IEquatable<TKey>
{
    TKey Parse(string? key);
}

public interface ITenantService<TKey> where TKey : IEquatable<TKey>
{
    TKey GetTenantId();
}

public interface ILanguageService<TKey> where TKey : IEquatable<TKey>
{
    TKey GetLanguage();
}