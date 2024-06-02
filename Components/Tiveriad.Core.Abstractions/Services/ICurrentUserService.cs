
namespace Tiveriad.Core.Abstractions.Services;

public interface ICurrentUserService<TKey>
{
    TKey GetUserId();
    string GetUserName();
    string GetFirstName();
    string GetLastName();
    string GetEmail();
}

public interface IOptionalService<T>
{
    bool HasService { get; }
    T? GetService();
}

