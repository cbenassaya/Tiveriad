using Tiveriad.Documents.Core.Services;

namespace Tiveriad.Documents.Providers.LocalDrive;

public class LocalDriveConfiguration
{
    public string RootPath { get; private set; }
    public Func<string?> GetOrganizationId { get; private set; } = ()=>null;

    public LocalDriveConfiguration SetRootPath(string rootPath)
    {
        RootPath = rootPath;
        return this;
    }

    public LocalDriveConfiguration SetOrganizationIdProvider(Func<string>? getOrganizationId)
    {
        GetOrganizationId = getOrganizationId ?? (()=> null);
        return this;
    }
}

public static class Extensions
{
    public static IBlobServiceProvider Configure(this IBlobServiceProvider serviceProvider, Action<LocalDriveConfiguration> configurator)
    {
        var config = new LocalDriveConfiguration();
        configurator(config);
        serviceProvider.Add(new LocalDriveBlobService(config));
        return serviceProvider;
    }
}