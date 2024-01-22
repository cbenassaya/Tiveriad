namespace Tiveriad.Documents.Providers.LocalDrive;

public class LocalDriveConfiguration
{
    internal LocalDriveConfiguration()
    {
    }

    public string RootPath { get; private set; }

    public LocalDriveConfiguration SetRootPath(string rootPath)
    {
        RootPath = rootPath;
        return this;
    }
}