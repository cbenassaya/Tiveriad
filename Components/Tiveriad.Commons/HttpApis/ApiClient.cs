namespace Tiveriad.Commons.HttpApis;

/// <summary>
///     Provides a fluent class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.
/// </summary>
public class ApiClient : IApiClient
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ApiClient" /> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public ApiClient(HttpClient httpClient) : this(httpClient, null)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ApiClient" /> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    /// <param name="contentSerializer">The content serializer.</param>
    public ApiClient(HttpClient httpClient, IContentSerializer contentSerializer)
    {
        HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        ContentSerializer = contentSerializer ?? HttpApis.ContentSerializer.Current;
    }


    /// <summary>
    ///     Gets or sets the serializer used to convert to and from <see cref="HttpContent" />.
    /// </summary>
    /// <value>
    ///     The serializer used to convert to and from <see cref="HttpContent" />.
    /// </value>
    public IContentSerializer ContentSerializer { get; set; }

    /// <summary>
    ///     Gets the <see cref="HttpClient" /> used to send request.
    /// </summary>
    /// <value>
    ///     The <see cref="HttpClient" /> used to send request.
    /// </value>
    public HttpClient HttpClient { get; }

    /// <inheritdoc />
    public void Dispose()
    {
        HttpClient?.Dispose();
    }
}