using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IClientInitialAccessApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsInitialAccessGet(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsInitialAccessGetWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns></returns>
    void RealmClientsInitialAccessIdDelete(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsInitialAccessIdDeleteWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Create a new initial access token.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ClientInitialAccessPresentation</returns>
    ClientInitialAccessPresentation RealmClientsInitialAccessPost(ClientInitialAccessCreatePresentation body,
        string realm);

    /// <summary>
    ///     Create a new initial access token.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of ClientInitialAccessPresentation</returns>
    ApiResponse<ClientInitialAccessPresentation> RealmClientsInitialAccessPostWithHttpInfo(
        ClientInitialAccessCreatePresentation body, string realm);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsInitialAccessGetAsync(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsInitialAccessGetAsyncWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of void</returns>
    Task RealmClientsInitialAccessIdDeleteAsync(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsInitialAccessIdDeleteAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Create a new initial access token.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ClientInitialAccessPresentation</returns>
    Task<ClientInitialAccessPresentation> RealmClientsInitialAccessPostAsync(ClientInitialAccessCreatePresentation body,
        string realm);

    /// <summary>
    ///     Create a new initial access token.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (ClientInitialAccessPresentation)</returns>
    Task<ApiResponse<ClientInitialAccessPresentation>> RealmClientsInitialAccessPostAsyncWithHttpInfo(
        ClientInitialAccessCreatePresentation body, string realm);

    #endregion Asynchronous Operations
}