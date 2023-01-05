using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IClientsApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Get clients belonging to the realm   Returns a list of clients belonging to the realm
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientId">filter by clientId (optional)</param>
    /// <param name="first">the first result (optional)</param>
    /// <param name="max">the max results to return (optional)</param>
    /// <param name="q"> (optional)</param>
    /// <param name="search">whether this is a search query or a getClientById query (optional)</param>
    /// <param name="viewableOnly">filter clients that cannot be viewed in full by admin (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsGet(string realm, string clientId = null, int? first = null,
        int? max = null, string q = null, bool? search = null, bool? viewableOnly = null);

    /// <summary>
    ///     Get clients belonging to the realm   Returns a list of clients belonging to the realm
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientId">filter by clientId (optional)</param>
    /// <param name="first">the first result (optional)</param>
    /// <param name="max">the max results to return (optional)</param>
    /// <param name="q"> (optional)</param>
    /// <param name="search">whether this is a search query or a getClientById query (optional)</param>
    /// <param name="viewableOnly">filter clients that cannot be viewed in full by admin (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsGetWithHttpInfo(string realm, string clientId = null,
        int? first = null, int? max = null, string q = null, bool? search = null, bool? viewableOnly = null);

    /// <summary>
    ///     Get the client secret
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>CredentialRepresentation</returns>
    CredentialRepresentation RealmClientsIdClientSecretGet(string realm, string id);

    /// <summary>
    ///     Get the client secret
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of CredentialRepresentation</returns>
    ApiResponse<CredentialRepresentation> RealmClientsIdClientSecretGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Generate a new secret for the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>CredentialRepresentation</returns>
    CredentialRepresentation RealmClientsIdClientSecretPost(string realm, string id);

    /// <summary>
    ///     Generate a new secret for the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of CredentialRepresentation</returns>
    ApiResponse<CredentialRepresentation> RealmClientsIdClientSecretPostWithHttpInfo(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns></returns>
    void RealmClientsIdDefaultClientScopesClientScopeIdDelete(string realm, string id, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdDefaultClientScopesClientScopeIdDeleteWithHttpInfo(string realm, string id,
        string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns></returns>
    void RealmClientsIdDefaultClientScopesClientScopeIdPut(string realm, string id, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdDefaultClientScopesClientScopeIdPutWithHttpInfo(string realm, string id,
        string clientScopeId);

    /// <summary>
    ///     Get default client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdDefaultClientScopesGet(string realm, string id);

    /// <summary>
    ///     Get default client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdDefaultClientScopesGetWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Delete the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns></returns>
    void RealmClientsIdDelete(string realm, string id);

    /// <summary>
    ///     Delete the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdDeleteWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Create JSON with payload of example access token
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <returns>AccessToken</returns>
    AccessToken RealmClientsIdEvaluateScopesGenerateExampleAccessTokenGet(string realm, string id, string scope = null,
        string userId = null);

    /// <summary>
    ///     Create JSON with payload of example access token
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <returns>ApiResponse of AccessToken</returns>
    ApiResponse<AccessToken> RealmClientsIdEvaluateScopesGenerateExampleAccessTokenGetWithHttpInfo(string realm,
        string id, string scope = null, string userId = null);

    /// <summary>
    ///     Create JSON with payload of example id token
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <returns>IDToken</returns>
    IDToken RealmClientsIdEvaluateScopesGenerateExampleIdTokenGet(string realm, string id, string scope = null,
        string userId = null);

    /// <summary>
    ///     Create JSON with payload of example id token
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <returns>ApiResponse of IDToken</returns>
    ApiResponse<IDToken> RealmClientsIdEvaluateScopesGenerateExampleIdTokenGetWithHttpInfo(string realm, string id,
        string scope = null, string userId = null);

    /// <summary>
    ///     Create JSON with payload of example user info
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <returns>Dictionary&lt;string, Object&gt;</returns>
    Dictionary<string, object> RealmClientsIdEvaluateScopesGenerateExampleUserinfoGet(string realm, string id,
        string scope = null, string userId = null);

    /// <summary>
    ///     Create JSON with payload of example user info
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
    ApiResponse<Dictionary<string, object>> RealmClientsIdEvaluateScopesGenerateExampleUserinfoGetWithHttpInfo(
        string realm, string id, string scope = null, string userId = null);

    /// <summary>
    ///     Return list of all protocol mappers, which will be used when generating tokens issued for particular client.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdEvaluateScopesProtocolMappersGet(string realm, string id,
        string scope = null);

    /// <summary>
    ///     Return list of all protocol mappers, which will be used when generating tokens issued for particular client.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdEvaluateScopesProtocolMappersGetWithHttpInfo(
        string realm, string id, string scope = null);

    /// <summary>
    ///     Get effective scope mapping of all roles of particular role container, which this client is defacto allowed to have
    ///     in the accessToken issued for him.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleContainerId">either realm name OR client UUID</param>
    /// <param name="scope"> (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdEvaluateScopesScopeMappingsRoleContainerIdGrantedGet(string realm,
        string id, string roleContainerId, string scope = null);

    /// <summary>
    ///     Get effective scope mapping of all roles of particular role container, which this client is defacto allowed to have
    ///     in the accessToken issued for him.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleContainerId">either realm name OR client UUID</param>
    /// <param name="scope"> (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>>
        RealmClientsIdEvaluateScopesScopeMappingsRoleContainerIdGrantedGetWithHttpInfo(string realm, string id,
            string roleContainerId, string scope = null);

    /// <summary>
    ///     Get roles, which this client doesn’t have scope for and can’t have them in the accessToken issued for him.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleContainerId">either realm name OR client UUID</param>
    /// <param name="scope"> (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdEvaluateScopesScopeMappingsRoleContainerIdNotGrantedGet(string realm,
        string id, string roleContainerId, string scope = null);

    /// <summary>
    ///     Get roles, which this client doesn’t have scope for and can’t have them in the accessToken issued for him.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleContainerId">either realm name OR client UUID</param>
    /// <param name="scope"> (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>>
        RealmClientsIdEvaluateScopesScopeMappingsRoleContainerIdNotGrantedGetWithHttpInfo(string realm, string id,
            string roleContainerId, string scope = null);

    /// <summary>
    ///     Get representation of the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ClientRepresentation</returns>
    ClientRepresentation RealmClientsIdGet(string realm, string id);

    /// <summary>
    ///     Get representation of the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of ClientRepresentation</returns>
    ApiResponse<ClientRepresentation> RealmClientsIdGetWithHttpInfo(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="providerId"></param>
    /// <returns></returns>
    void RealmClientsIdInstallationProvidersProviderIdGet(string realm, string id, string providerId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="providerId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdInstallationProvidersProviderIdGetWithHttpInfo(string realm, string id,
        string providerId);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ManagementPermissionReference</returns>
    ManagementPermissionReference RealmClientsIdManagementPermissionsGet(string realm, string id);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of ManagementPermissionReference</returns>
    ApiResponse<ManagementPermissionReference> RealmClientsIdManagementPermissionsGetWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ManagementPermissionReference</returns>
    ManagementPermissionReference RealmClientsIdManagementPermissionsPut(ManagementPermissionReference body,
        string realm, string id);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of ManagementPermissionReference</returns>
    ApiResponse<ManagementPermissionReference> RealmClientsIdManagementPermissionsPutWithHttpInfo(
        ManagementPermissionReference body, string realm, string id);

    /// <summary>
    ///     Unregister a cluster node from the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="node"></param>
    /// <returns></returns>
    void RealmClientsIdNodesNodeDelete(string realm, string id, string node);

    /// <summary>
    ///     Unregister a cluster node from the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="node"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdNodesNodeDeleteWithHttpInfo(string realm, string id, string node);

    /// <summary>
    ///     Register a cluster node with the client   Manually register cluster node to this client - usually it’s not needed
    ///     to call this directly as adapter should handle  by sending registration request to Keycloak
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns></returns>
    void RealmClientsIdNodesPost(Dictionary<string, object> body, string realm, string id);

    /// <summary>
    ///     Register a cluster node with the client   Manually register cluster node to this client - usually it’s not needed
    ///     to call this directly as adapter should handle  by sending registration request to Keycloak
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdNodesPostWithHttpInfo(Dictionary<string, object> body, string realm, string id);

    /// <summary>
    ///     Get application offline session count   Returns a number of offline user sessions associated with this client   {
    ///     \&quot;count\&quot;: number  }
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Dictionary&lt;string, Object&gt;</returns>
    Dictionary<string, object> RealmClientsIdOfflineSessionCountGet(string realm, string id);

    /// <summary>
    ///     Get application offline session count   Returns a number of offline user sessions associated with this client   {
    ///     \&quot;count\&quot;: number  }
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
    ApiResponse<Dictionary<string, object>> RealmClientsIdOfflineSessionCountGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get offline sessions for client   Returns a list of offline user sessions associated with this client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdOfflineSessionsGet(string realm, string id, int? first = null,
        int? max = null);

    /// <summary>
    ///     Get offline sessions for client   Returns a list of offline user sessions associated with this client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdOfflineSessionsGetWithHttpInfo(string realm, string id,
        int? first = null, int? max = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns></returns>
    void RealmClientsIdOptionalClientScopesClientScopeIdDelete(string realm, string id, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdOptionalClientScopesClientScopeIdDeleteWithHttpInfo(string realm, string id,
        string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns></returns>
    void RealmClientsIdOptionalClientScopesClientScopeIdPut(string realm, string id, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdOptionalClientScopesClientScopeIdPutWithHttpInfo(string realm, string id,
        string clientScopeId);

    /// <summary>
    ///     Get optional client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdOptionalClientScopesGet(string realm, string id);

    /// <summary>
    ///     Get optional client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdOptionalClientScopesGetWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Push the client’s revocation policy to its admin URL   If the client has an admin URL, push revocation policy to
    ///     it.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>GlobalRequestResult</returns>
    GlobalRequestResult RealmClientsIdPushRevocationPost(string realm, string id);

    /// <summary>
    ///     Push the client’s revocation policy to its admin URL   If the client has an admin URL, push revocation policy to
    ///     it.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of GlobalRequestResult</returns>
    ApiResponse<GlobalRequestResult> RealmClientsIdPushRevocationPostWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Update the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns></returns>
    void RealmClientsIdPut(ClientRepresentation body, string realm, string id);

    /// <summary>
    ///     Update the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdPutWithHttpInfo(ClientRepresentation body, string realm, string id);

    /// <summary>
    ///     Generate a new registration access token for the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ClientRepresentation</returns>
    ClientRepresentation RealmClientsIdRegistrationAccessTokenPost(string realm, string id);

    /// <summary>
    ///     Generate a new registration access token for the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of ClientRepresentation</returns>
    ApiResponse<ClientRepresentation> RealmClientsIdRegistrationAccessTokenPostWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get a user dedicated to the service account
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>UserRepresentation</returns>
    UserRepresentation RealmClientsIdServiceAccountUserGet(string realm, string id);

    /// <summary>
    ///     Get a user dedicated to the service account
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of UserRepresentation</returns>
    ApiResponse<UserRepresentation> RealmClientsIdServiceAccountUserGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get application session count   Returns a number of user sessions associated with this client   {      \&quot;
    ///     count\&quot;: number  }
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Dictionary&lt;string, Object&gt;</returns>
    Dictionary<string, object> RealmClientsIdSessionCountGet(string realm, string id);

    /// <summary>
    ///     Get application session count   Returns a number of user sessions associated with this client   {      \&quot;
    ///     count\&quot;: number  }
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
    ApiResponse<Dictionary<string, object>> RealmClientsIdSessionCountGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Test if registered cluster nodes are available   Tests availability by sending &#x27;ping&#x27; request to all
    ///     cluster nodes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>GlobalRequestResult</returns>
    GlobalRequestResult RealmClientsIdTestNodesAvailableGet(string realm, string id);

    /// <summary>
    ///     Test if registered cluster nodes are available   Tests availability by sending &#x27;ping&#x27; request to all
    ///     cluster nodes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of GlobalRequestResult</returns>
    ApiResponse<GlobalRequestResult> RealmClientsIdTestNodesAvailableGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get user sessions for client   Returns a list of user sessions associated with this client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdUserSessionsGet(string realm, string id, int? first = null,
        int? max = null);

    /// <summary>
    ///     Get user sessions for client   Returns a list of user sessions associated with this client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdUserSessionsGetWithHttpInfo(string realm, string id,
        int? first = null, int? max = null);

    /// <summary>
    ///     Create a new client   Client’s client_id must be unique!
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmClientsPost(ClientRepresentation body, string realm);

    /// <summary>
    ///     Create a new client   Client’s client_id must be unique!
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsPostWithHttpInfo(ClientRepresentation body, string realm);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Get clients belonging to the realm   Returns a list of clients belonging to the realm
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientId">filter by clientId (optional)</param>
    /// <param name="first">the first result (optional)</param>
    /// <param name="max">the max results to return (optional)</param>
    /// <param name="q"> (optional)</param>
    /// <param name="search">whether this is a search query or a getClientById query (optional)</param>
    /// <param name="viewableOnly">filter clients that cannot be viewed in full by admin (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsGetAsync(string realm, string clientId = null, int? first = null,
        int? max = null, string q = null, bool? search = null, bool? viewableOnly = null);

    /// <summary>
    ///     Get clients belonging to the realm   Returns a list of clients belonging to the realm
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientId">filter by clientId (optional)</param>
    /// <param name="first">the first result (optional)</param>
    /// <param name="max">the max results to return (optional)</param>
    /// <param name="q"> (optional)</param>
    /// <param name="search">whether this is a search query or a getClientById query (optional)</param>
    /// <param name="viewableOnly">filter clients that cannot be viewed in full by admin (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsGetAsyncWithHttpInfo(string realm,
        string clientId = null, int? first = null, int? max = null, string q = null, bool? search = null,
        bool? viewableOnly = null);

    /// <summary>
    ///     Get the client secret
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of CredentialRepresentation</returns>
    Task<CredentialRepresentation> RealmClientsIdClientSecretGetAsync(string realm, string id);

    /// <summary>
    ///     Get the client secret
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (CredentialRepresentation)</returns>
    Task<ApiResponse<CredentialRepresentation>> RealmClientsIdClientSecretGetAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Generate a new secret for the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of CredentialRepresentation</returns>
    Task<CredentialRepresentation> RealmClientsIdClientSecretPostAsync(string realm, string id);

    /// <summary>
    ///     Generate a new secret for the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (CredentialRepresentation)</returns>
    Task<ApiResponse<CredentialRepresentation>>
        RealmClientsIdClientSecretPostAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdDefaultClientScopesClientScopeIdDeleteAsync(string realm, string id, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdDefaultClientScopesClientScopeIdDeleteAsyncWithHttpInfo(string realm,
        string id, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdDefaultClientScopesClientScopeIdPutAsync(string realm, string id, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdDefaultClientScopesClientScopeIdPutAsyncWithHttpInfo(string realm,
        string id, string clientScopeId);

    /// <summary>
    ///     Get default client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdDefaultClientScopesGetAsync(string realm, string id);

    /// <summary>
    ///     Get default client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsIdDefaultClientScopesGetAsyncWithHttpInfo(
        string realm, string id);

    /// <summary>
    ///     Delete the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdDeleteAsync(string realm, string id);

    /// <summary>
    ///     Delete the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdDeleteAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Create JSON with payload of example access token
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <returns>Task of AccessToken</returns>
    Task<AccessToken> RealmClientsIdEvaluateScopesGenerateExampleAccessTokenGetAsync(string realm, string id,
        string scope = null, string userId = null);

    /// <summary>
    ///     Create JSON with payload of example access token
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <returns>Task of ApiResponse (AccessToken)</returns>
    Task<ApiResponse<AccessToken>> RealmClientsIdEvaluateScopesGenerateExampleAccessTokenGetAsyncWithHttpInfo(
        string realm, string id, string scope = null, string userId = null);

    /// <summary>
    ///     Create JSON with payload of example id token
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <returns>Task of IDToken</returns>
    Task<IDToken> RealmClientsIdEvaluateScopesGenerateExampleIdTokenGetAsync(string realm, string id,
        string scope = null, string userId = null);

    /// <summary>
    ///     Create JSON with payload of example id token
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <returns>Task of ApiResponse (IDToken)</returns>
    Task<ApiResponse<IDToken>> RealmClientsIdEvaluateScopesGenerateExampleIdTokenGetAsyncWithHttpInfo(string realm,
        string id, string scope = null, string userId = null);

    /// <summary>
    ///     Create JSON with payload of example user info
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
    Task<Dictionary<string, object>> RealmClientsIdEvaluateScopesGenerateExampleUserinfoGetAsync(string realm,
        string id, string scope = null, string userId = null);

    /// <summary>
    ///     Create JSON with payload of example user info
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <param name="userId"> (optional)</param>
    /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
    Task<ApiResponse<Dictionary<string, object>>>
        RealmClientsIdEvaluateScopesGenerateExampleUserinfoGetAsyncWithHttpInfo(string realm, string id,
            string scope = null, string userId = null);

    /// <summary>
    ///     Return list of all protocol mappers, which will be used when generating tokens issued for particular client.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdEvaluateScopesProtocolMappersGetAsync(string realm, string id,
        string scope = null);

    /// <summary>
    ///     Return list of all protocol mappers, which will be used when generating tokens issued for particular client.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="scope"> (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsIdEvaluateScopesProtocolMappersGetAsyncWithHttpInfo(
        string realm, string id, string scope = null);

    /// <summary>
    ///     Get effective scope mapping of all roles of particular role container, which this client is defacto allowed to have
    ///     in the accessToken issued for him.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleContainerId">either realm name OR client UUID</param>
    /// <param name="scope"> (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdEvaluateScopesScopeMappingsRoleContainerIdGrantedGetAsync(
        string realm, string id, string roleContainerId, string scope = null);

    /// <summary>
    ///     Get effective scope mapping of all roles of particular role container, which this client is defacto allowed to have
    ///     in the accessToken issued for him.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleContainerId">either realm name OR client UUID</param>
    /// <param name="scope"> (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmClientsIdEvaluateScopesScopeMappingsRoleContainerIdGrantedGetAsyncWithHttpInfo(string realm, string id,
            string roleContainerId, string scope = null);

    /// <summary>
    ///     Get roles, which this client doesn’t have scope for and can’t have them in the accessToken issued for him.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleContainerId">either realm name OR client UUID</param>
    /// <param name="scope"> (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdEvaluateScopesScopeMappingsRoleContainerIdNotGrantedGetAsync(
        string realm, string id, string roleContainerId, string scope = null);

    /// <summary>
    ///     Get roles, which this client doesn’t have scope for and can’t have them in the accessToken issued for him.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleContainerId">either realm name OR client UUID</param>
    /// <param name="scope"> (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmClientsIdEvaluateScopesScopeMappingsRoleContainerIdNotGrantedGetAsyncWithHttpInfo(string realm, string id,
            string roleContainerId, string scope = null);

    /// <summary>
    ///     Get representation of the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ClientRepresentation</returns>
    Task<ClientRepresentation> RealmClientsIdGetAsync(string realm, string id);

    /// <summary>
    ///     Get representation of the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (ClientRepresentation)</returns>
    Task<ApiResponse<ClientRepresentation>> RealmClientsIdGetAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="providerId"></param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdInstallationProvidersProviderIdGetAsync(string realm, string id, string providerId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="providerId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdInstallationProvidersProviderIdGetAsyncWithHttpInfo(string realm, string id,
        string providerId);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ManagementPermissionReference</returns>
    Task<ManagementPermissionReference> RealmClientsIdManagementPermissionsGetAsync(string realm, string id);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (ManagementPermissionReference)</returns>
    Task<ApiResponse<ManagementPermissionReference>> RealmClientsIdManagementPermissionsGetAsyncWithHttpInfo(
        string realm, string id);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ManagementPermissionReference</returns>
    Task<ManagementPermissionReference> RealmClientsIdManagementPermissionsPutAsync(ManagementPermissionReference body,
        string realm, string id);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (ManagementPermissionReference)</returns>
    Task<ApiResponse<ManagementPermissionReference>> RealmClientsIdManagementPermissionsPutAsyncWithHttpInfo(
        ManagementPermissionReference body, string realm, string id);

    /// <summary>
    ///     Unregister a cluster node from the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="node"></param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdNodesNodeDeleteAsync(string realm, string id, string node);

    /// <summary>
    ///     Unregister a cluster node from the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="node"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdNodesNodeDeleteAsyncWithHttpInfo(string realm, string id, string node);

    /// <summary>
    ///     Register a cluster node with the client   Manually register cluster node to this client - usually it’s not needed
    ///     to call this directly as adapter should handle  by sending registration request to Keycloak
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdNodesPostAsync(Dictionary<string, object> body, string realm, string id);

    /// <summary>
    ///     Register a cluster node with the client   Manually register cluster node to this client - usually it’s not needed
    ///     to call this directly as adapter should handle  by sending registration request to Keycloak
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdNodesPostAsyncWithHttpInfo(Dictionary<string, object> body, string realm,
        string id);

    /// <summary>
    ///     Get application offline session count   Returns a number of offline user sessions associated with this client   {
    ///     \&quot;count\&quot;: number  }
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
    Task<Dictionary<string, object>> RealmClientsIdOfflineSessionCountGetAsync(string realm, string id);

    /// <summary>
    ///     Get application offline session count   Returns a number of offline user sessions associated with this client   {
    ///     \&quot;count\&quot;: number  }
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
    Task<ApiResponse<Dictionary<string, object>>> RealmClientsIdOfflineSessionCountGetAsyncWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Get offline sessions for client   Returns a list of offline user sessions associated with this client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdOfflineSessionsGetAsync(string realm, string id,
        int? first = null, int? max = null);

    /// <summary>
    ///     Get offline sessions for client   Returns a list of offline user sessions associated with this client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsIdOfflineSessionsGetAsyncWithHttpInfo(string realm,
        string id, int? first = null, int? max = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdOptionalClientScopesClientScopeIdDeleteAsync(string realm, string id, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdOptionalClientScopesClientScopeIdDeleteAsyncWithHttpInfo(string realm,
        string id, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdOptionalClientScopesClientScopeIdPutAsync(string realm, string id, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdOptionalClientScopesClientScopeIdPutAsyncWithHttpInfo(string realm,
        string id, string clientScopeId);

    /// <summary>
    ///     Get optional client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdOptionalClientScopesGetAsync(string realm, string id);

    /// <summary>
    ///     Get optional client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsIdOptionalClientScopesGetAsyncWithHttpInfo(
        string realm, string id);

    /// <summary>
    ///     Push the client’s revocation policy to its admin URL   If the client has an admin URL, push revocation policy to
    ///     it.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of GlobalRequestResult</returns>
    Task<GlobalRequestResult> RealmClientsIdPushRevocationPostAsync(string realm, string id);

    /// <summary>
    ///     Push the client’s revocation policy to its admin URL   If the client has an admin URL, push revocation policy to
    ///     it.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (GlobalRequestResult)</returns>
    Task<ApiResponse<GlobalRequestResult>> RealmClientsIdPushRevocationPostAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Update the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdPutAsync(ClientRepresentation body, string realm, string id);

    /// <summary>
    ///     Update the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdPutAsyncWithHttpInfo(ClientRepresentation body, string realm, string id);

    /// <summary>
    ///     Generate a new registration access token for the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ClientRepresentation</returns>
    Task<ClientRepresentation> RealmClientsIdRegistrationAccessTokenPostAsync(string realm, string id);

    /// <summary>
    ///     Generate a new registration access token for the client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (ClientRepresentation)</returns>
    Task<ApiResponse<ClientRepresentation>> RealmClientsIdRegistrationAccessTokenPostAsyncWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Get a user dedicated to the service account
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of UserRepresentation</returns>
    Task<UserRepresentation> RealmClientsIdServiceAccountUserGetAsync(string realm, string id);

    /// <summary>
    ///     Get a user dedicated to the service account
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (UserRepresentation)</returns>
    Task<ApiResponse<UserRepresentation>> RealmClientsIdServiceAccountUserGetAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get application session count   Returns a number of user sessions associated with this client   {      \&quot;
    ///     count\&quot;: number  }
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
    Task<Dictionary<string, object>> RealmClientsIdSessionCountGetAsync(string realm, string id);

    /// <summary>
    ///     Get application session count   Returns a number of user sessions associated with this client   {      \&quot;
    ///     count\&quot;: number  }
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
    Task<ApiResponse<Dictionary<string, object>>> RealmClientsIdSessionCountGetAsyncWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Test if registered cluster nodes are available   Tests availability by sending &#x27;ping&#x27; request to all
    ///     cluster nodes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of GlobalRequestResult</returns>
    Task<GlobalRequestResult> RealmClientsIdTestNodesAvailableGetAsync(string realm, string id);

    /// <summary>
    ///     Test if registered cluster nodes are available   Tests availability by sending &#x27;ping&#x27; request to all
    ///     cluster nodes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (GlobalRequestResult)</returns>
    Task<ApiResponse<GlobalRequestResult>>
        RealmClientsIdTestNodesAvailableGetAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get user sessions for client   Returns a list of user sessions associated with this client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdUserSessionsGetAsync(string realm, string id,
        int? first = null, int? max = null);

    /// <summary>
    ///     Get user sessions for client   Returns a list of user sessions associated with this client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsIdUserSessionsGetAsyncWithHttpInfo(string realm,
        string id, int? first = null, int? max = null);

    /// <summary>
    ///     Create a new client   Client’s client_id must be unique!
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmClientsPostAsync(ClientRepresentation body, string realm);

    /// <summary>
    ///     Create a new client   Client’s client_id must be unique!
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsPostAsyncWithHttpInfo(ClientRepresentation body, string realm);

    #endregion Asynchronous Operations
}