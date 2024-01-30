#region

using Microsoft.AspNetCore.Routing.Constraints;
using Tiveriad.Commons.Extensions;
using Tiveriad.Documents.Core.Services;

#endregion

namespace Tiveriad.Documents.Providers.LocalDrive;

[BlobProviderName("LocalDrive")]
public class LocalDriveBlobService : IBlobService
{
    private readonly LocalDriveConfiguration _configuration;


    internal LocalDriveBlobService(LocalDriveConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<byte[]> GetAsync(string relativePath, string fileName, CancellationToken cancellationToken = default)
    {
        return await File.ReadAllBytesAsync(relativePath.Build(_configuration,fileName), cancellationToken);
    }

    public async Task PutAsync(byte[] content, string relativePath, string fileName, CancellationToken cancellationToken = default)
    {
        relativePath.Build(_configuration).CreateIfNotExists();
        await File.WriteAllBytesAsync(relativePath.Build(_configuration,fileName), content, cancellationToken);
    }

    public async Task DeleteAsync(string relativePath, string fileName, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => File.Delete(relativePath.Build(_configuration,fileName)), cancellationToken);
    }

    public string Name => "LocalDrive";


}


public static class LocalDriveFilePathBuilderExtensions 
{
    public static string Build(this string relativePath,  LocalDriveConfiguration configuration)
    {
        string directoryPath = configuration.RootPath;
        
        if (string.IsNullOrEmpty(configuration.GetOrganizationId()))
        {
            directoryPath = Path.Combine(directoryPath, "host");
        }
        else
        {
            directoryPath = Path.Combine(directoryPath, "tenants", configuration.GetOrganizationId() ?? string.Empty);
        }

        return directoryPath;
    }
    public static string Build(this string relativePath,  LocalDriveConfiguration configuration, string fileName)
    {
        return Path.Combine(relativePath.Build(configuration), fileName);
    }
}