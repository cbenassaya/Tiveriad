﻿#region

using Identity.Integration.Core.Services;

#endregion

namespace Identity.Integration.Infrastructure.Services;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public string GetUserId()
    {
        return httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "id")?.Value ?? string.Empty;
    }

    public string GetUserName()
    {
        return httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "username")?.Value ??
               string.Empty;
    }

    public string GetFirstName()
    {
        return httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "given_name")?.Value ??
               string.Empty;
    }

    public string GetLastName()
    {
        return httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "family_name")?.Value ??
               string.Empty;
    }

    public string GetEmail()
    {
        return httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "email")?.Value ??
               string.Empty;
    }
}