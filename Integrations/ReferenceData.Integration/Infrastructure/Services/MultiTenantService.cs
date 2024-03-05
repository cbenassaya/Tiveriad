#region

using ReferenceData.Integration.Core.Services;
using Tiveriad.IdGenerators;

#endregion

namespace ReferenceData.Integration.Infrastructure.Services;

public class MultiTenantService : IMultiTenantService
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