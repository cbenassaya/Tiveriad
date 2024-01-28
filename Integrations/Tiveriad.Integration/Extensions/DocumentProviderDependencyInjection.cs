using Tiveriad.Documents.Core.Services;
using Tiveriad.Documents.Providers.LocalDrive;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Tiveriad.Integration.Extensions;

public static class DocumentProviderDependencyInjection
{ 
    public static IServiceCollection AddDocumentProvider(this IServiceCollection services)
    {
        services.AddSingleton<IBlobProviderService>((container) =>
        {
            var hostingEnvironment = services.BuildServiceProvider().GetRequiredService<IHostingEnvironment>();
            var service = new BlobProviderService();
            service.Add(LocalDriveBlobProvider.Configure((configuration) =>
            {
                configuration.SetRootPath(hostingEnvironment.ContentRootPath);
            }));
                
            return service;
        });
        return services;
    }
}