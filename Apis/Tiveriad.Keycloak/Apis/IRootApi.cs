using Tiveriad.Keycloak.Models;namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IRootApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Get themes, social providers, auth providers, and event listeners available on this server
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <returns>ServerInfoRepresentation</returns>
    ServerInfoRepresentation RootGet();

    /// <summary>
    ///     Get themes, social providers, auth providers, and event listeners available on this server
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <returns>ApiResponse of ServerInfoRepresentation</returns>
    ApiResponse<ServerInfoRepresentation> RootGetWithHttpInfo();

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Get themes, social providers, auth providers, and event listeners available on this server
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <returns>Task of ServerInfoRepresentation</returns>
    Task<ServerInfoRepresentation> RootGetAsync();

    /// <summary>
    ///     Get themes, social providers, auth providers, and event listeners available on this server
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <returns>Task of ApiResponse (ServerInfoRepresentation)</returns>
    Task<ApiResponse<ServerInfoRepresentation>> RootGetAsyncWithHttpInfo();

    #endregion Asynchronous Operations
}