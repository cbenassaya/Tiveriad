namespace Identity.Integration.Core.Services;

public interface IMultiTenantService
{
    string GetCurrentOrganizationId();

    void SetCurrentOrganizationId(string organizationId);
}