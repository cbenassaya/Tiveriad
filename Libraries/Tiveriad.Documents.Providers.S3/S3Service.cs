#region

using System.Net;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Tiveriad.Documents.Core.Exceptions;
using Tiveriad.Documents.Core.Services;

#endregion

namespace Tiveriad.Documents.Providers.S3;

[BlobProviderName("S3")]
public class S3Service : IBlobProvider
{
    private readonly S3Configuration _configuration;


    private S3Service(S3Configuration configuration)
    {
        _configuration = configuration;
    }

    public async Task PutAsync(byte[] content, string path, CancellationToken cancellationToken = default)
    {
        try
        {
            using var client = new AmazonS3Client(_configuration.GetCredentials(), _configuration.GetS3Config());
            var fileTransferUtility = new TransferUtility(client);
            await using var stream = new MemoryStream(content);
            await fileTransferUtility.UploadAsync(stream, _configuration.GetBucket(), path, cancellationToken);
        }
        catch (Exception se)
        {
            throw new DocumentException(DocumentError.INTERNAL_ERROR);
        }
    }

    public async Task DeleteAsync(string path, CancellationToken cancellationToken = default)
    {
        try
        {
            using var client = new AmazonS3Client(_configuration.GetCredentials(), _configuration.GetS3Config());
            var req = new DeleteObjectRequest { BucketName = _configuration.GetBucket(), Key = path };
            await client.DeleteObjectAsync(req, cancellationToken);
        }
        catch (AmazonS3Exception se)
        {
            if (se.StatusCode == HttpStatusCode.NotFound ||
                "NoSuchKey".Equals(se.ErrorCode, StringComparison.OrdinalIgnoreCase))
                throw new BlobMissingException($"Amazon S3 blob \"{path}\" not found.\n({se.Message})", se);
            if (se.StatusCode == HttpStatusCode.Forbidden ||
                "AccessDenied".Equals(se.ErrorCode, StringComparison.OrdinalIgnoreCase))
                throw new BlobMissingException(
                    $"Amazon S3 blob \"{path}\" not accessible. The blob may not exist or you may not have permission to access it.\n({se.Message})",
                    se);
            throw;
        }
    }

    public async Task<byte[]> GetAsync(string path, CancellationToken cancellationToken = default)
    {
        try
        {
            using var client = new AmazonS3Client(_configuration.GetCredentials(), _configuration.GetS3Config());
            var req = new GetObjectRequest { BucketName = _configuration.GetBucket(), Key = path };
            var objectResponse = await client.GetObjectAsync(req, cancellationToken);
            await using var stream = new MemoryStream();
            await objectResponse.ResponseStream.CopyToAsync(stream, cancellationToken);
            var content = stream.TryGetBuffer(out var data) ? data.Array : new byte[0];
            return content;
        }
        catch (AmazonS3Exception se)
        {
            if (se.StatusCode == HttpStatusCode.NotFound ||
                "NoSuchKey".Equals(se.ErrorCode, StringComparison.OrdinalIgnoreCase))
                throw new BlobMissingException($"Amazon S3 blob \"{path}\" not found.\n({se.Message})", se);
            if (se.StatusCode == HttpStatusCode.Forbidden ||
                "AccessDenied".Equals(se.ErrorCode, StringComparison.OrdinalIgnoreCase))
                throw new BlobMissingException(
                    $"Amazon S3 blob \"{path}\" not accessible. The blob may not exist or you may not have permission to access it.\n({se.Message})",
                    se);
            throw;
        }
    }
    
    public string Name => "S3";

    public static S3Service Configure(Action<S3Configuration> configurator)
    {
        var configuration = new S3Configuration();
        configurator(configuration);
        return new S3Service(configuration);
    }
}