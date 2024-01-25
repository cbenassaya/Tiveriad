
using Tiveriad.Identities.Core.Services;

namespace Identities.Integration.Infrastructure.Services;

public class CurrentUserService:ICurrentUserService
{
    public string GetUserId()
    {
        return string.Empty;
    }
}