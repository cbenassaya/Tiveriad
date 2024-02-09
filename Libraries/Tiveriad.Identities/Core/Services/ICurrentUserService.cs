#region

using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Core.Services;

public interface ICurrentUserService
{
    string GetUserId();
}

public interface IIdentityService
{
    Task Update(User user, Organization organization);
}