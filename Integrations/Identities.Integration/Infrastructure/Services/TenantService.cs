#region

using Tiveriad.Core.Abstractions.Services;
using Tiveriad.IdGenerators;

#endregion

namespace Identities.Integration.Infrastructure.Services;

public class TenantService : ITenantService<string>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TenantService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetTenantId()
        => _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "organizationId")?.Value ?? string.Empty;
}

