using Tiveriad.Keycloak.Models;namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IScopeMappingsApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     The available client-level roles   Returns the roles for the client that can be associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientScopesIdScopeMappingsClientsClientAvailableGet(string realm, string id,
        string _client);

    /// <summary>
    ///     The available client-level roles   Returns the roles for the client that can be associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientScopesIdScopeMappingsClientsClientAvailableGetWithHttpInfo(
        string realm, string id, string _client);

    /// <summary>
    ///     Get effective client roles   Returns the roles for the client that are associated with the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientScopesIdScopeMappingsClientsClientCompositeGet(string realm, string id,
        string _client, bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective client roles   Returns the roles for the client that are associated with the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientScopesIdScopeMappingsClientsClientCompositeGetWithHttpInfo(
        string realm, string id, string _client, bool? briefRepresentation = null);

    /// <summary>
    ///     Remove client-level roles from the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns></returns>
    void RealmClientScopesIdScopeMappingsClientsClientDelete(List<RoleRepresentation> body, string realm, string id,
        string _client);

    /// <summary>
    ///     Remove client-level roles from the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientScopesIdScopeMappingsClientsClientDeleteWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id, string _client);

    /// <summary>
    ///     Get the roles associated with a client’s scope   Returns roles for the client.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientScopesIdScopeMappingsClientsClientGet(string realm, string id,
        string _client);

    /// <summary>
    ///     Get the roles associated with a client’s scope   Returns roles for the client.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientScopesIdScopeMappingsClientsClientGetWithHttpInfo(
        string realm, string id, string _client);

    /// <summary>
    ///     Add client-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns></returns>
    void RealmClientScopesIdScopeMappingsClientsClientPost(List<RoleRepresentation> body, string realm, string id,
        string _client);

    /// <summary>
    ///     Add client-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientScopesIdScopeMappingsClientsClientPostWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id, string _client);

    /// <summary>
    ///     Get realm-level roles that are available to attach to this client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientScopesIdScopeMappingsRealmAvailableGet(string realm, string id);

    /// <summary>
    ///     Get realm-level roles that are available to attach to this client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientScopesIdScopeMappingsRealmAvailableGetWithHttpInfo(
        string realm, string id);

    /// <summary>
    ///     Get effective realm-level roles associated with the client’s scope   What this does is recurse  any composite roles
    ///     associated with the client’s scope and adds the roles to this lists.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientScopesIdScopeMappingsRealmCompositeGet(string realm, string id,
        bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective realm-level roles associated with the client’s scope   What this does is recurse  any composite roles
    ///     associated with the client’s scope and adds the roles to this lists.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientScopesIdScopeMappingsRealmCompositeGetWithHttpInfo(
        string realm, string id, bool? briefRepresentation = null);

    /// <summary>
    ///     Remove a set of realm-level roles from the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns></returns>
    void RealmClientScopesIdScopeMappingsRealmDelete(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Remove a set of realm-level roles from the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientScopesIdScopeMappingsRealmDeleteWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id);

    /// <summary>
    ///     Get realm-level roles associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientScopesIdScopeMappingsRealmGet(string realm, string id);

    /// <summary>
    ///     Get realm-level roles associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientScopesIdScopeMappingsRealmGetWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Add a set of realm-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns></returns>
    void RealmClientScopesIdScopeMappingsRealmPost(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Add a set of realm-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientScopesIdScopeMappingsRealmPostWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id);

    /// <summary>
    ///     The available client-level roles   Returns the roles for the client that can be associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdScopeMappingsClientsClientAvailableGet(string realm, string id,
        string _client);

    /// <summary>
    ///     The available client-level roles   Returns the roles for the client that can be associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdScopeMappingsClientsClientAvailableGetWithHttpInfo(
        string realm, string id, string _client);

    /// <summary>
    ///     Get effective client roles   Returns the roles for the client that are associated with the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdScopeMappingsClientsClientCompositeGet(string realm, string id,
        string _client, bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective client roles   Returns the roles for the client that are associated with the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdScopeMappingsClientsClientCompositeGetWithHttpInfo(
        string realm, string id, string _client, bool? briefRepresentation = null);

    /// <summary>
    ///     Remove client-level roles from the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns></returns>
    void RealmClientsIdScopeMappingsClientsClientDelete(List<RoleRepresentation> body, string realm, string id,
        string _client);

    /// <summary>
    ///     Remove client-level roles from the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdScopeMappingsClientsClientDeleteWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id, string _client);

    /// <summary>
    ///     Get the roles associated with a client’s scope   Returns roles for the client.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdScopeMappingsClientsClientGet(string realm, string id,
        string _client);

    /// <summary>
    ///     Get the roles associated with a client’s scope   Returns roles for the client.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdScopeMappingsClientsClientGetWithHttpInfo(string realm,
        string id, string _client);

    /// <summary>
    ///     Add client-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns></returns>
    void RealmClientsIdScopeMappingsClientsClientPost(List<RoleRepresentation> body, string realm, string id,
        string _client);

    /// <summary>
    ///     Add client-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdScopeMappingsClientsClientPostWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id, string _client);

    /// <summary>
    ///     Get realm-level roles that are available to attach to this client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdScopeMappingsRealmAvailableGet(string realm, string id);

    /// <summary>
    ///     Get realm-level roles that are available to attach to this client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdScopeMappingsRealmAvailableGetWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Get effective realm-level roles associated with the client’s scope   What this does is recurse  any composite roles
    ///     associated with the client’s scope and adds the roles to this lists.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdScopeMappingsRealmCompositeGet(string realm, string id,
        bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective realm-level roles associated with the client’s scope   What this does is recurse  any composite roles
    ///     associated with the client’s scope and adds the roles to this lists.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdScopeMappingsRealmCompositeGetWithHttpInfo(string realm,
        string id, bool? briefRepresentation = null);

    /// <summary>
    ///     Remove a set of realm-level roles from the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns></returns>
    void RealmClientsIdScopeMappingsRealmDelete(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Remove a set of realm-level roles from the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdScopeMappingsRealmDeleteWithHttpInfo(List<RoleRepresentation> body, string realm,
        string id);

    /// <summary>
    ///     Get realm-level roles associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdScopeMappingsRealmGet(string realm, string id);

    /// <summary>
    ///     Get realm-level roles associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdScopeMappingsRealmGetWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Add a set of realm-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns></returns>
    void RealmClientsIdScopeMappingsRealmPost(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Add a set of realm-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdScopeMappingsRealmPostWithHttpInfo(List<RoleRepresentation> body, string realm,
        string id);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     The available client-level roles   Returns the roles for the client that can be associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientScopesIdScopeMappingsClientsClientAvailableGetAsync(string realm,
        string id, string _client);

    /// <summary>
    ///     The available client-level roles   Returns the roles for the client that can be associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmClientScopesIdScopeMappingsClientsClientAvailableGetAsyncWithHttpInfo(string realm, string id,
            string _client);

    /// <summary>
    ///     Get effective client roles   Returns the roles for the client that are associated with the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientScopesIdScopeMappingsClientsClientCompositeGetAsync(string realm,
        string id, string _client, bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective client roles   Returns the roles for the client that are associated with the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmClientScopesIdScopeMappingsClientsClientCompositeGetAsyncWithHttpInfo(string realm, string id,
            string _client, bool? briefRepresentation = null);

    /// <summary>
    ///     Remove client-level roles from the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns>Task of void</returns>
    Task RealmClientScopesIdScopeMappingsClientsClientDeleteAsync(List<RoleRepresentation> body, string realm,
        string id, string _client);

    /// <summary>
    ///     Remove client-level roles from the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientScopesIdScopeMappingsClientsClientDeleteAsyncWithHttpInfo(
        List<RoleRepresentation> body, string realm, string id, string _client);

    /// <summary>
    ///     Get the roles associated with a client’s scope   Returns roles for the client.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientScopesIdScopeMappingsClientsClientGetAsync(string realm,
        string id, string _client);

    /// <summary>
    ///     Get the roles associated with a client’s scope   Returns roles for the client.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmClientScopesIdScopeMappingsClientsClientGetAsyncWithHttpInfo(string realm, string id, string _client);

    /// <summary>
    ///     Add client-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns>Task of void</returns>
    Task RealmClientScopesIdScopeMappingsClientsClientPostAsync(List<RoleRepresentation> body, string realm, string id,
        string _client);

    /// <summary>
    ///     Add client-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientScopesIdScopeMappingsClientsClientPostAsyncWithHttpInfo(
        List<RoleRepresentation> body, string realm, string id, string _client);

    /// <summary>
    ///     Get realm-level roles that are available to attach to this client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientScopesIdScopeMappingsRealmAvailableGetAsync(string realm,
        string id);

    /// <summary>
    ///     Get realm-level roles that are available to attach to this client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmClientScopesIdScopeMappingsRealmAvailableGetAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get effective realm-level roles associated with the client’s scope   What this does is recurse  any composite roles
    ///     associated with the client’s scope and adds the roles to this lists.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientScopesIdScopeMappingsRealmCompositeGetAsync(string realm,
        string id, bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective realm-level roles associated with the client’s scope   What this does is recurse  any composite roles
    ///     associated with the client’s scope and adds the roles to this lists.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmClientScopesIdScopeMappingsRealmCompositeGetAsyncWithHttpInfo(string realm, string id,
            bool? briefRepresentation = null);

    /// <summary>
    ///     Remove a set of realm-level roles from the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of void</returns>
    Task RealmClientScopesIdScopeMappingsRealmDeleteAsync(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Remove a set of realm-level roles from the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientScopesIdScopeMappingsRealmDeleteAsyncWithHttpInfo(
        List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Get realm-level roles associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientScopesIdScopeMappingsRealmGetAsync(string realm, string id);

    /// <summary>
    ///     Get realm-level roles associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientScopesIdScopeMappingsRealmGetAsyncWithHttpInfo(
        string realm, string id);

    /// <summary>
    ///     Add a set of realm-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of void</returns>
    Task RealmClientScopesIdScopeMappingsRealmPostAsync(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Add a set of realm-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientScopesIdScopeMappingsRealmPostAsyncWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id);

    /// <summary>
    ///     The available client-level roles   Returns the roles for the client that can be associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdScopeMappingsClientsClientAvailableGetAsync(string realm,
        string id, string _client);

    /// <summary>
    ///     The available client-level roles   Returns the roles for the client that can be associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmClientsIdScopeMappingsClientsClientAvailableGetAsyncWithHttpInfo(string realm, string id, string _client);

    /// <summary>
    ///     Get effective client roles   Returns the roles for the client that are associated with the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdScopeMappingsClientsClientCompositeGetAsync(string realm,
        string id, string _client, bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective client roles   Returns the roles for the client that are associated with the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmClientsIdScopeMappingsClientsClientCompositeGetAsyncWithHttpInfo(string realm, string id, string _client,
            bool? briefRepresentation = null);

    /// <summary>
    ///     Remove client-level roles from the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdScopeMappingsClientsClientDeleteAsync(List<RoleRepresentation> body, string realm, string id,
        string _client);

    /// <summary>
    ///     Remove client-level roles from the client’s scope.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdScopeMappingsClientsClientDeleteAsyncWithHttpInfo(
        List<RoleRepresentation> body, string realm, string id, string _client);

    /// <summary>
    ///     Get the roles associated with a client’s scope   Returns roles for the client.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdScopeMappingsClientsClientGetAsync(string realm, string id,
        string _client);

    /// <summary>
    ///     Get the roles associated with a client’s scope   Returns roles for the client.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsIdScopeMappingsClientsClientGetAsyncWithHttpInfo(
        string realm, string id, string _client);

    /// <summary>
    ///     Add client-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdScopeMappingsClientsClientPostAsync(List<RoleRepresentation> body, string realm, string id,
        string _client);

    /// <summary>
    ///     Add client-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdScopeMappingsClientsClientPostAsyncWithHttpInfo(
        List<RoleRepresentation> body, string realm, string id, string _client);

    /// <summary>
    ///     Get realm-level roles that are available to attach to this client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdScopeMappingsRealmAvailableGetAsync(string realm, string id);

    /// <summary>
    ///     Get realm-level roles that are available to attach to this client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsIdScopeMappingsRealmAvailableGetAsyncWithHttpInfo(
        string realm, string id);

    /// <summary>
    ///     Get effective realm-level roles associated with the client’s scope   What this does is recurse  any composite roles
    ///     associated with the client’s scope and adds the roles to this lists.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdScopeMappingsRealmCompositeGetAsync(string realm, string id,
        bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective realm-level roles associated with the client’s scope   What this does is recurse  any composite roles
    ///     associated with the client’s scope and adds the roles to this lists.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsIdScopeMappingsRealmCompositeGetAsyncWithHttpInfo(
        string realm, string id, bool? briefRepresentation = null);

    /// <summary>
    ///     Remove a set of realm-level roles from the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdScopeMappingsRealmDeleteAsync(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Remove a set of realm-level roles from the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdScopeMappingsRealmDeleteAsyncWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id);

    /// <summary>
    ///     Get realm-level roles associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdScopeMappingsRealmGetAsync(string realm, string id);

    /// <summary>
    ///     Get realm-level roles associated with the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsIdScopeMappingsRealmGetAsyncWithHttpInfo(
        string realm, string id);

    /// <summary>
    ///     Add a set of realm-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdScopeMappingsRealmPostAsync(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Add a set of realm-level roles to the client’s scope
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdScopeMappingsRealmPostAsyncWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id);

    #endregion Asynchronous Operations
}