#region

using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Documents.Core.Services;
using Tiveriad.Documents.Providers.LocalDrive;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

#endregion

namespace Tiveriad.Integration.Extensions;

public static class DocumentProviderDependencyInjection
{
    public static IServiceCollection AddDocumentProvider(this IServiceCollection services)
    {
        services.AddSingleton<IBlobServiceProvider>(container =>
        {
            var hostingEnvironment = services.BuildServiceProvider().GetRequiredService<IHostingEnvironment>();
            var tenantService = services.BuildServiceProvider().GetRequiredService<ITenantService<string>>();
            var service = new BlobServiceProvider();
            service.Configure(configuration =>
            {
                configuration
                    .SetOrganizationIdProvider(tenantService.GetCurrentOrganizationId)
                    .SetRootPath(hostingEnvironment.ContentRootPath);
            });
            return service;
        });
        return services;
    }
}