﻿#region

using Tiveriad.Identities.Core.Services;

#endregion

namespace Tiveriad.Integration.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    public string GetUserId()
    {
        return string.Empty;
    }
}