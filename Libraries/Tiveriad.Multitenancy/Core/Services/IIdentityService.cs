using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Core.Services;

public interface IIdentityService
{
    public Task Update(User user, Organization organization);
    
}