#region

using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Integration.Infrastructure.Services;

#endregion

namespace Tiveriad.Integration.Extensions;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastrureService(this IServiceCollection services)
    {
        return services;
    }
}