namespace Tiveriad.Keycloak.Models;

/// <summary>
///     API Response
/// </summary>
public class ApiResponse<T>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ApiResponse&lt;T&gt;" /> class.
    /// </summary>
    /// <param name="statusCode">HTTP status code.</param>
    /// <param name="headers">HTTP headers.</param>
    /// <param name="data">Data (parsed HTTP body)</param>
    public ApiResponse(int statusCode, IDictionary<string, string> headers, T data)
    {
        StatusCode = statusCode;
        Headers = headers;
        Data = data;
    }

    /// <summary>
    ///     Gets or sets the status code (HTTP status code)
    /// </summary>
    /// <value>The status code.</value>
    public int StatusCode { get; }

    /// <summary>
    ///     Gets or sets the HTTP headers
    /// </summary>
    /// <value>HTTP headers</value>
    public IDictionary<string, string> Headers { get; }

    /// <summary>
    ///     Gets or sets the data (parsed HTTP body)
    /// </summary>
    /// <value>The data.</value>
    public T Data { get; }
}