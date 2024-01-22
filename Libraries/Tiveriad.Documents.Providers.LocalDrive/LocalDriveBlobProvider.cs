#region

using Tiveriad.Documents.Core.Services;

#endregion

namespace Tiveriad.Documents.Providers.LocalDrive;

public class LocalDriveBlobProvider : IBlobProvider
{
    private readonly LocalDriveConfiguration _configuration;


    private LocalDriveBlobProvider(LocalDriveConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<byte[]> GetAsync(string virtualPath, CancellationToken cancellationToken = default)
    {
        return await File.ReadAllBytesAsync(Path.Combine(_configuration.RootPath, virtualPath), cancellationToken);
    }

    public async Task PutAsync(byte[] content, string path, CancellationToken cancellationToken = default)
    {
        await File.WriteAllBytesAsync(Path.Combine(_configuration.RootPath), content, cancellationToken);
    }

    public async Task DeleteAsync(string virtualPath, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => File.Delete(Path.Combine(_configuration.RootPath, virtualPath)), cancellationToken);
    }

    public static LocalDriveBlobProvider Configure(Action<LocalDriveConfiguration> configurator)
    {
        var configuration = new LocalDriveConfiguration();
        configurator(configuration);
        return new LocalDriveBlobProvider(configuration);
    }
}