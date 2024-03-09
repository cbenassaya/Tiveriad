
namespace Tiveriad.Core.Abstractions.Services;

public interface ICurrentUserService<TKey>
{
    TKey GetUserId();
    string GetUserName();
    string GetFirstName();
    string GetLastName();
    string GetEmail();
}

