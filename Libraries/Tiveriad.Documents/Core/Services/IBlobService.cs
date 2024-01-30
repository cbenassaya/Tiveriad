namespace Tiveriad.Documents.Core.Services;

public interface IBlobService
{
    Task<byte[]> GetAsync(string relativePath, string fileName, CancellationToken cancellationToken = default);
    Task PutAsync(byte[] content, string relativePath, string fileName, CancellationToken cancellationToken = default);
    Task DeleteAsync(string relativePath, string fileName, CancellationToken cancellationToken = default);
    string Name { get; }
}