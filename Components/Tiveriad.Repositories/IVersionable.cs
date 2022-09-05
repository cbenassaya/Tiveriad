#nullable enable
namespace Tiveriad.Repositories;

public interface IVersionable
{
    /// <summary>
    ///     A version number, to indicate the version of the schema.
    /// </summary>
    int Version { get; set; }
}