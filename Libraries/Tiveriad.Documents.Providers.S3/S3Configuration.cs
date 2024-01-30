#region

using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Tiveriad.Documents.Core.Services;

#endregion

namespace Tiveriad.Documents.Providers.S3;

public class S3Configuration
{
    private string _accessKeyId;
    private string _bucket;
    private RegionEndpoint _regionEndpoint;
    private string _secretKey;

    internal S3Configuration()
    {
    }

    public S3Configuration SetAccessKeyId(string accessKeyId)
    {
        _accessKeyId = accessKeyId;
        return this;
    }

    public S3Configuration SetSecretKey(string secretKey)
    {
        _secretKey = secretKey;
        return this;
    }

    public S3Configuration SetRegionEndpoint(RegionEndpoint regionEndpoint)
    {
        _regionEndpoint = regionEndpoint;
        return this;
    }

    public S3Configuration SetBucket(string bucket)
    {
        _bucket = bucket;
        return this;
    }

    internal string GetBucket()
    {
        return _bucket;
    }

    internal AmazonS3Config GetS3Config()
    {
        return new AmazonS3Config
        {
            RegionEndpoint = _regionEndpoint
        };
    }

    internal AWSCredentials GetCredentials()
    {
        return string.IsNullOrWhiteSpace(_accessKeyId)
            ? new AnonymousAWSCredentials()
            : new BasicAWSCredentials(_accessKeyId, _secretKey);
    }
}

public static class Extensions
{
    public static IBlobServiceProvider Configure(this IBlobServiceProvider serviceProvider, Action<S3Configuration> configurator)
    {
        var config = new S3Configuration();
        configurator(config);
        serviceProvider.Add(new S3Service(config));
        return serviceProvider;
    }
}