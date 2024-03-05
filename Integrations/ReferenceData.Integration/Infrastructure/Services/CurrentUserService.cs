#region

using ReferenceData.Integration.Core.Services;

#endregion

namespace ReferenceData.Integration.Infrastructure.Services;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public string GetUserId() => httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "id")?.Value ?? string.Empty;

    public string GetUserName() => httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "username")?.Value ?? string.Empty;

    public string GetFirstName() => httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "given_name")?.Value ?? string.Empty;

    public string GetLastName() => httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "family_name")?.Value ?? string.Empty;

    public string GetEmail() => httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "email")?.Value ?? string.Empty;
}