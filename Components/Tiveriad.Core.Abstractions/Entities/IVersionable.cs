#nullable enable
namespace Tiveriad.Core.Abstractions.Entities;

public interface IVersionable
{
    /// <summary>
    ///     A version number, to indicate the version of the schema.
    /// </summary>
    int Version { get; set; }
}