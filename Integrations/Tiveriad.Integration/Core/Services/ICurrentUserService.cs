using Tiveriad.Identities.Core.Entities;

namespace Tiveriad.Integration.Core.Services;

public interface ICurrentUserService
{
    string GetUserId();
}

public interface IIdentityService
{
    public  Task Update(User user, Organization organization);
}