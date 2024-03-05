#region

using Microsoft.AspNetCore.Mvc.Filters;
using ReferenceData.Integration.Core.Services;

#endregion

namespace ReferenceData.Integration.Apis.Filters;

public class MultiTenantActionFilter : IAsyncActionFilter
{
    private readonly IMultiTenantService _tenantService;

    public MultiTenantActionFilter(IMultiTenantService tenantService)
    {
        _tenantService = tenantService;
    }

    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.RouteData.Values.TryGetValue("organizationId", out var organizationIdObj))
            if (organizationIdObj is string organizationId)
                _tenantService.SetCurrentOrganizationId(organizationId);

        return next();
    }
}