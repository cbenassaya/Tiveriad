using Tiveriad.Core.Abstractions.Services;
using Tiveriad.IdGenerators;

namespace Tiveriad.Integration.Infrastructure.Services;

public class TenantService : ITenantService<string>
{
    private string _id = KeyGenerator.NewId<string>();
    public string GetCurrentOrganizationId()
    {
        return _id;
    }

    public void SetCurrentOrganizationId(string organizationId)
    {
        _id = organizationId;
    }
}