#region

using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Integration.Core.Services;
using Tiveriad.Integration.Infrastructure.Services;

#endregion

namespace Tiveriad.Integration.Extensions;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastrureService(this IServiceCollection services)
    {
        services.AddScoped<ITenantService<string>, TenantService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        return services;
    }
}