namespace Tiveriad.Documents.Core.Services;

public interface IBlobProvider
{
    Task<byte[]> GetAsync(string path, CancellationToken cancellationToken = default);
    Task PutAsync(byte[] content, string path, CancellationToken cancellationToken = default);
    Task DeleteAsync(string path, CancellationToken cancellationToken = default);
    string Name { get; }
}