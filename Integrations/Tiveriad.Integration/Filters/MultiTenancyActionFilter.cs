#region

using Microsoft.AspNetCore.Mvc.Filters;
using Tiveriad.Core.Abstractions.Services;

#endregion

namespace Tiveriad.Integration.Filters;

public class MultiTenancyActionFilter : IAsyncActionFilter
{
    private readonly ITenantService<string> _tenantService;

    public MultiTenancyActionFilter(ITenantService<string> tenantService)
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