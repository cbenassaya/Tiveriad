
using Tiveriad.Identities.Core.Services;

namespace Multitenancy.Integration.Infrastructure.Services;

public class CurrentUserService:ICurrentUserService
{
    public string GetUserId()
    {
        return string.Empty;
    }
}