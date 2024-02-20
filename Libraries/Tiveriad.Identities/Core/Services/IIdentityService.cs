using Tiveriad.Identities.Core.Entities;

namespace Tiveriad.Identities.Core.Services;

public interface IIdentityService
{
    Task Update(User user, Organization organization);
}