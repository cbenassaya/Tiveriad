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
            var service = new BlobServiceProvider();
            service.Configure(configuration =>
            {
                configuration
                    .SetRootPath(hostingEnvironment.ContentRootPath);
            });
            return service;
        });
        return services;
    }
}