using Tiveriad.Keycloak.Models;namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IKeyApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>KeysMetadataRepresentation</returns>
    KeysMetadataRepresentation RealmKeysGet(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of KeysMetadataRepresentation</returns>
    ApiResponse<KeysMetadataRepresentation> RealmKeysGetWithHttpInfo(string realm);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of KeysMetadataRepresentation</returns>
    Task<KeysMetadataRepresentation> RealmKeysGetAsync(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (KeysMetadataRepresentation)</returns>
    Task<ApiResponse<KeysMetadataRepresentation>> RealmKeysGetAsyncWithHttpInfo(string realm);

    #endregion Asynchronous Operations
}