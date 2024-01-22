#region

using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Core.Services;

public interface IIdentityService
{
    public Task Update(User user, Organization organization);
}