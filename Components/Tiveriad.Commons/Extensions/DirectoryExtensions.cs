namespace Tiveriad.Commons.Extensions;

public static class DirectoryExtensions
{
    public static DirectoryInfo CreateIfNotExists(this string directory)
    {
        return !Directory.Exists(directory)
            ? Directory.CreateDirectory(directory)
            : new DirectoryInfo(directory);
    }

    public static void DeleteIfExists(this string directory, bool recursive = false)
    {
        if (Directory.Exists(directory))
        {
            Directory.Delete(directory, recursive);
        }
    }

    public static bool IsSubDirectoryOf( this string parentDirectoryPath,  string childDirectoryPath)
    {
        return IsSubDirectoryOf(
            new DirectoryInfo(parentDirectoryPath),
            new DirectoryInfo(childDirectoryPath)
        );
    }
    public static bool IsSubDirectoryOf( DirectoryInfo parentDirectory,
         DirectoryInfo childDirectory)
    {

        if (parentDirectory.FullName == childDirectory.FullName)
        {
            return true;
        }
        var parentOfChild = childDirectory.Parent;
        if (parentOfChild == null)
        {
            return false;
        }

        return IsSubDirectoryOf(parentDirectory, parentOfChild);
    }


}