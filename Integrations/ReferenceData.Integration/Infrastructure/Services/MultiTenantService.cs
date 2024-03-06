#region

using ReferenceData.Integration.Core.Services;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.IdGenerators;

#endregion

namespace ReferenceData.Integration.Infrastructure.Services;

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

public class LanguageService : ILanguageService<string>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LanguageService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetLanguage()
        => _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "language")?.Value ?? "en";
}