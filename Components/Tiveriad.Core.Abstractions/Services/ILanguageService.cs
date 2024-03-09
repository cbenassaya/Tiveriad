namespace Tiveriad.Core.Abstractions.Services;

public interface ILanguageService<TKey> where TKey : IEquatable<TKey>
{
    TKey GetLanguage();
}