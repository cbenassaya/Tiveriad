using Tiveriad.Keycloak.Models;namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IClientScopesApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Get client scopes belonging to the realm   Returns a list of client scopes belonging to the realm
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientScopesGet(string realm);

    /// <summary>
    ///     Get client scopes belonging to the realm   Returns a list of client scopes belonging to the realm
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientScopesGetWithHttpInfo(string realm);

    /// <summary>
    ///     Delete the client scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns></returns>
    void RealmClientScopesIdDelete(string realm, string id);

    /// <summary>
    ///     Delete the client scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientScopesIdDeleteWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get representation of the client scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>ClientScopeRepresentation</returns>
    ClientScopeRepresentation RealmClientScopesIdGet(string realm, string id);

    /// <summary>
    ///     Get representation of the client scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>ApiResponse of ClientScopeRepresentation</returns>
    ApiResponse<ClientScopeRepresentation> RealmClientScopesIdGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Update the client scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns></returns>
    void RealmClientScopesIdPut(ClientScopeRepresentation body, string realm, string id);

    /// <summary>
    ///     Update the client scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientScopesIdPutWithHttpInfo(ClientScopeRepresentation body, string realm, string id);

    /// <summary>
    ///     Create a new client scope   Client Scope’s name must be unique!
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmClientScopesPost(ClientScopeRepresentation body, string realm);

    /// <summary>
    ///     Create a new client scope   Client Scope’s name must be unique!
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientScopesPostWithHttpInfo(ClientScopeRepresentation body, string realm);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Get client scopes belonging to the realm   Returns a list of client scopes belonging to the realm
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientScopesGetAsync(string realm);

    /// <summary>
    ///     Get client scopes belonging to the realm   Returns a list of client scopes belonging to the realm
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientScopesGetAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Delete the client scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of void</returns>
    Task RealmClientScopesIdDeleteAsync(string realm, string id);

    /// <summary>
    ///     Delete the client scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientScopesIdDeleteAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get representation of the client scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of ClientScopeRepresentation</returns>
    Task<ClientScopeRepresentation> RealmClientScopesIdGetAsync(string realm, string id);

    /// <summary>
    ///     Get representation of the client scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of ApiResponse (ClientScopeRepresentation)</returns>
    Task<ApiResponse<ClientScopeRepresentation>> RealmClientScopesIdGetAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Update the client scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of void</returns>
    Task RealmClientScopesIdPutAsync(ClientScopeRepresentation body, string realm, string id);

    /// <summary>
    ///     Update the client scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientScopesIdPutAsyncWithHttpInfo(ClientScopeRepresentation body, string realm,
        string id);

    /// <summary>
    ///     Create a new client scope   Client Scope’s name must be unique!
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmClientScopesPostAsync(ClientScopeRepresentation body, string realm);

    /// <summary>
    ///     Create a new client scope   Client Scope’s name must be unique!
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientScopesPostAsyncWithHttpInfo(ClientScopeRepresentation body, string realm);

    #endregion Asynchronous Operations
}