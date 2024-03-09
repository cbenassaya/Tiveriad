using Tiveriad.Core.Abstractions.Services;

namespace ReferenceData.Integration.Infrastructure.Services;

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