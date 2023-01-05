using Tiveriad.Keycloak.Models;namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IRealmsAdminApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Delete all admin events
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmAdminEventsDelete(string realm);

    /// <summary>
    ///     Delete all admin events
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAdminEventsDeleteWithHttpInfo(string realm);

    /// <summary>
    ///     Get admin events   Returns all admin events, or filters events based on URL query parameters listed here
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="authClient"> (optional)</param>
    /// <param name="authIpAddress"> (optional)</param>
    /// <param name="authRealm"> (optional)</param>
    /// <param name="authUser">user id (optional)</param>
    /// <param name="dateFrom"> (optional)</param>
    /// <param name="dateTo"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="operationTypes"> (optional)</param>
    /// <param name="resourcePath"> (optional)</param>
    /// <param name="resourceTypes"> (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmAdminEventsGet(string realm, string authClient = null,
        string authIpAddress = null, string authRealm = null, string authUser = null, string dateFrom = null,
        string dateTo = null, int? first = null, int? max = null, List<string> operationTypes = null,
        string resourcePath = null, List<string> resourceTypes = null);

    /// <summary>
    ///     Get admin events   Returns all admin events, or filters events based on URL query parameters listed here
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="authClient"> (optional)</param>
    /// <param name="authIpAddress"> (optional)</param>
    /// <param name="authRealm"> (optional)</param>
    /// <param name="authUser">user id (optional)</param>
    /// <param name="dateFrom"> (optional)</param>
    /// <param name="dateTo"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="operationTypes"> (optional)</param>
    /// <param name="resourcePath"> (optional)</param>
    /// <param name="resourceTypes"> (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmAdminEventsGetWithHttpInfo(string realm,
        string authClient = null, string authIpAddress = null, string authRealm = null, string authUser = null,
        string dateFrom = null, string dateTo = null, int? first = null, int? max = null,
        List<string> operationTypes = null, string resourcePath = null, List<string> resourceTypes = null);

    /// <summary>
    ///     Clear cache of external public keys (Public keys of clients or Identity providers)
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmClearKeysCachePost(string realm);

    /// <summary>
    ///     Clear cache of external public keys (Public keys of clients or Identity providers)
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClearKeysCachePostWithHttpInfo(string realm);

    /// <summary>
    ///     Clear realm cache
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmClearRealmCachePost(string realm);

    /// <summary>
    ///     Clear realm cache
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClearRealmCachePostWithHttpInfo(string realm);

    /// <summary>
    ///     Clear user cache
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmClearUserCachePost(string realm);

    /// <summary>
    ///     Clear user cache
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClearUserCachePostWithHttpInfo(string realm);

    /// <summary>
    ///     Base path for importing clients under this realm.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ClientRepresentation</returns>
    ClientRepresentation RealmClientDescriptionConverterPost(string body, string realm);

    /// <summary>
    ///     Base path for importing clients under this realm.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of ClientRepresentation</returns>
    ApiResponse<ClientRepresentation> RealmClientDescriptionConverterPostWithHttpInfo(string body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ClientPoliciesRepresentation</returns>
    ClientPoliciesRepresentation RealmClientPoliciesPoliciesGet(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of ClientPoliciesRepresentation</returns>
    ApiResponse<ClientPoliciesRepresentation> RealmClientPoliciesPoliciesGetWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmClientPoliciesPoliciesPut(ClientPoliciesRepresentation body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientPoliciesPoliciesPutWithHttpInfo(ClientPoliciesRepresentation body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="includeGlobalProfiles"> (optional)</param>
    /// <returns>ClientProfilesRepresentation</returns>
    ClientProfilesRepresentation RealmClientPoliciesProfilesGet(string realm, bool? includeGlobalProfiles = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="includeGlobalProfiles"> (optional)</param>
    /// <returns>ApiResponse of ClientProfilesRepresentation</returns>
    ApiResponse<ClientProfilesRepresentation> RealmClientPoliciesProfilesGetWithHttpInfo(string realm,
        bool? includeGlobalProfiles = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmClientPoliciesProfilesPut(ClientProfilesRepresentation body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientPoliciesProfilesPutWithHttpInfo(ClientProfilesRepresentation body, string realm);

    /// <summary>
    ///     Get client session stats   Returns a JSON map.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientSessionStatsGet(string realm);

    /// <summary>
    ///     Get client session stats   Returns a JSON map.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientSessionStatsGetWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmCredentialRegistratorsGet(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmCredentialRegistratorsGetWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns></returns>
    void RealmDefaultDefaultClientScopesClientScopeIdDelete(string realm, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmDefaultDefaultClientScopesClientScopeIdDeleteWithHttpInfo(string realm,
        string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns></returns>
    void RealmDefaultDefaultClientScopesClientScopeIdPut(string realm, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmDefaultDefaultClientScopesClientScopeIdPutWithHttpInfo(string realm, string clientScopeId);

    /// <summary>
    ///     Get realm default client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmDefaultDefaultClientScopesGet(string realm);

    /// <summary>
    ///     Get realm default client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmDefaultDefaultClientScopesGetWithHttpInfo(string realm);

    /// <summary>
    ///     Get group hierarchy.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmDefaultGroupsGet(string realm);

    /// <summary>
    ///     Get group hierarchy.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmDefaultGroupsGetWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="groupId"></param>
    /// <returns></returns>
    void RealmDefaultGroupsGroupIdDelete(string realm, string groupId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="groupId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmDefaultGroupsGroupIdDeleteWithHttpInfo(string realm, string groupId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="groupId"></param>
    /// <returns></returns>
    void RealmDefaultGroupsGroupIdPut(string realm, string groupId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="groupId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmDefaultGroupsGroupIdPutWithHttpInfo(string realm, string groupId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns></returns>
    void RealmDefaultOptionalClientScopesClientScopeIdDelete(string realm, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmDefaultOptionalClientScopesClientScopeIdDeleteWithHttpInfo(string realm,
        string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns></returns>
    void RealmDefaultOptionalClientScopesClientScopeIdPut(string realm, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object>
        RealmDefaultOptionalClientScopesClientScopeIdPutWithHttpInfo(string realm, string clientScopeId);

    /// <summary>
    ///     Get realm optional client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmDefaultOptionalClientScopesGet(string realm);

    /// <summary>
    ///     Get realm optional client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmDefaultOptionalClientScopesGetWithHttpInfo(string realm);

    /// <summary>
    ///     Delete the realm
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmDelete(string realm);

    /// <summary>
    ///     Delete the realm
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmDeleteWithHttpInfo(string realm);

    /// <summary>
    ///     Get the events provider configuration   Returns JSON object with events provider configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>RealmEventsConfigRepresentation</returns>
    RealmEventsConfigRepresentation RealmEventsConfigGet(string realm);

    /// <summary>
    ///     Get the events provider configuration   Returns JSON object with events provider configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of RealmEventsConfigRepresentation</returns>
    ApiResponse<RealmEventsConfigRepresentation> RealmEventsConfigGetWithHttpInfo(string realm);

    /// <summary>
    ///     Update the events provider   Change the events provider and/or its configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmEventsConfigPut(RealmEventsConfigRepresentation body, string realm);

    /// <summary>
    ///     Update the events provider   Change the events provider and/or its configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmEventsConfigPutWithHttpInfo(RealmEventsConfigRepresentation body, string realm);

    /// <summary>
    ///     Delete all events
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmEventsDelete(string realm);

    /// <summary>
    ///     Delete all events
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmEventsDeleteWithHttpInfo(string realm);

    /// <summary>
    ///     Get events   Returns all events, or filters them based on URL query parameters listed here
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="_client">App or oauth client name (optional)</param>
    /// <param name="dateFrom">From date (optional)</param>
    /// <param name="dateTo">To date (optional)</param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="ipAddress">IP address (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="type">The types of events to return (optional)</param>
    /// <param name="user">User id (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmEventsGet(string realm, string _client = null, string dateFrom = null,
        string dateTo = null, int? first = null, string ipAddress = null, int? max = null, List<string> type = null,
        string user = null);

    /// <summary>
    ///     Get events   Returns all events, or filters them based on URL query parameters listed here
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="_client">App or oauth client name (optional)</param>
    /// <param name="dateFrom">From date (optional)</param>
    /// <param name="dateTo">To date (optional)</param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="ipAddress">IP address (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="type">The types of events to return (optional)</param>
    /// <param name="user">User id (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmEventsGetWithHttpInfo(string realm, string _client = null,
        string dateFrom = null, string dateTo = null, int? first = null, string ipAddress = null, int? max = null,
        List<string> type = null, string user = null);

    /// <summary>
    ///     Get the top-level representation of the realm   It will not include nested information like User and Client
    ///     representations.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>RealmRepresentation</returns>
    RealmRepresentation RealmGet(string realm);

    /// <summary>
    ///     Get the top-level representation of the realm   It will not include nested information like User and Client
    ///     representations.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of RealmRepresentation</returns>
    ApiResponse<RealmRepresentation> RealmGetWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="path"></param>
    /// <returns>GroupRepresentation</returns>
    GroupRepresentation RealmGroupByPathPathGet(string realm, string path);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="path"></param>
    /// <returns>ApiResponse of GroupRepresentation</returns>
    ApiResponse<GroupRepresentation> RealmGroupByPathPathGetWithHttpInfo(string realm, string path);

    /// <summary>
    ///     Get LDAP supported extensions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">LDAP configuration</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmLdapServerCapabilitiesPost(TestLdapConnectionRepresentation body, string realm);

    /// <summary>
    ///     Get LDAP supported extensions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">LDAP configuration</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object>
        RealmLdapServerCapabilitiesPostWithHttpInfo(TestLdapConnectionRepresentation body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmLocalizationGet(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmLocalizationGetWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <returns></returns>
    void RealmLocalizationLocaleDelete(string realm, string locale);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmLocalizationLocaleDeleteWithHttpInfo(string realm, string locale);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <returns>Dictionary&lt;string, Object&gt;</returns>
    Dictionary<string, object> RealmLocalizationLocaleGet(string realm, string locale);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
    ApiResponse<Dictionary<string, object>> RealmLocalizationLocaleGetWithHttpInfo(string realm, string locale);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    void RealmLocalizationLocaleKeyDelete(string realm, string locale, string key);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <param name="key"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmLocalizationLocaleKeyDeleteWithHttpInfo(string realm, string locale, string key);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <param name="key"></param>
    /// <returns>string</returns>
    string RealmLocalizationLocaleKeyGet(string realm, string locale, string key);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <param name="key"></param>
    /// <returns>ApiResponse of string</returns>
    ApiResponse<string> RealmLocalizationLocaleKeyGetWithHttpInfo(string realm, string locale, string key);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    void RealmLocalizationLocaleKeyPut(string body, string realm, string locale, string key);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <param name="key"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmLocalizationLocaleKeyPutWithHttpInfo(string body, string realm, string locale, string key);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <returns></returns>
    void RealmLocalizationLocalePost(Dictionary<string, object> body, string realm, string locale);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmLocalizationLocalePostWithHttpInfo(Dictionary<string, object> body, string realm,
        string locale);

    /// <summary>
    ///     Removes all user sessions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>GlobalRequestResult</returns>
    GlobalRequestResult RealmLogoutAllPost(string realm);

    /// <summary>
    ///     Removes all user sessions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of GlobalRequestResult</returns>
    ApiResponse<GlobalRequestResult> RealmLogoutAllPostWithHttpInfo(string realm);

    /// <summary>
    ///     Partial export of existing realm into a JSON file.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="exportClients"> (optional)</param>
    /// <param name="exportGroupsAndRoles"> (optional)</param>
    /// <returns>RealmRepresentation</returns>
    RealmRepresentation RealmPartialExportPost(string realm, bool? exportClients = null,
        bool? exportGroupsAndRoles = null);

    /// <summary>
    ///     Partial export of existing realm into a JSON file.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="exportClients"> (optional)</param>
    /// <param name="exportGroupsAndRoles"> (optional)</param>
    /// <returns>ApiResponse of RealmRepresentation</returns>
    ApiResponse<RealmRepresentation> RealmPartialExportPostWithHttpInfo(string realm, bool? exportClients = null,
        bool? exportGroupsAndRoles = null);

    /// <summary>
    ///     Partial import from a JSON file to an existing realm.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmPartialImportPost(PartialImportRepresentation body, string realm);

    /// <summary>
    ///     Partial import from a JSON file to an existing realm.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmPartialImportPostWithHttpInfo(PartialImportRepresentation body, string realm);

    /// <summary>
    ///     Push the realm’s revocation policy to any client that has an admin url associated with it.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmPushRevocationPost(string realm);

    /// <summary>
    ///     Push the realm’s revocation policy to any client that has an admin url associated with it.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmPushRevocationPostWithHttpInfo(string realm);

    /// <summary>
    ///     Update the top-level information of the realm   Any user, roles or client information in the representation  will
    ///     be ignored.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmPut(RealmRepresentation body, string realm);

    /// <summary>
    ///     Update the top-level information of the realm   Any user, roles or client information in the representation  will
    ///     be ignored.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmPutWithHttpInfo(RealmRepresentation body, string realm);

    /// <summary>
    ///     Remove a specific user session.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="session"></param>
    /// <returns></returns>
    void RealmSessionsSessionDelete(string realm, string session);

    /// <summary>
    ///     Remove a specific user session.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="session"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmSessionsSessionDeleteWithHttpInfo(string realm, string session);

    /// <summary>
    ///     Test LDAP connection
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmTestLDAPConnectionPost(TestLdapConnectionRepresentation body, string realm);

    /// <summary>
    ///     Test LDAP connection
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmTestLDAPConnectionPostWithHttpInfo(TestLdapConnectionRepresentation body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmTestSMTPConnectionPost(Dictionary<string, object> body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmTestSMTPConnectionPostWithHttpInfo(Dictionary<string, object> body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ManagementPermissionReference</returns>
    ManagementPermissionReference RealmUsersManagementPermissionsGet(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of ManagementPermissionReference</returns>
    ApiResponse<ManagementPermissionReference> RealmUsersManagementPermissionsGetWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ManagementPermissionReference</returns>
    ManagementPermissionReference RealmUsersManagementPermissionsPut(ManagementPermissionReference body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of ManagementPermissionReference</returns>
    ApiResponse<ManagementPermissionReference> RealmUsersManagementPermissionsPutWithHttpInfo(
        ManagementPermissionReference body, string realm);

    /// <summary>
    ///     Import a realm   Imports a realm from a full representation of that realm.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON representation of the realm</param>
    /// <returns></returns>
    void RootPost(RealmRepresentation body);

    /// <summary>
    ///     Import a realm   Imports a realm from a full representation of that realm.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON representation of the realm</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RootPostWithHttpInfo(RealmRepresentation body);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Delete all admin events
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmAdminEventsDeleteAsync(string realm);

    /// <summary>
    ///     Delete all admin events
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAdminEventsDeleteAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Get admin events   Returns all admin events, or filters events based on URL query parameters listed here
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="authClient"> (optional)</param>
    /// <param name="authIpAddress"> (optional)</param>
    /// <param name="authRealm"> (optional)</param>
    /// <param name="authUser">user id (optional)</param>
    /// <param name="dateFrom"> (optional)</param>
    /// <param name="dateTo"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="operationTypes"> (optional)</param>
    /// <param name="resourcePath"> (optional)</param>
    /// <param name="resourceTypes"> (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmAdminEventsGetAsync(string realm, string authClient = null,
        string authIpAddress = null, string authRealm = null, string authUser = null, string dateFrom = null,
        string dateTo = null, int? first = null, int? max = null, List<string> operationTypes = null,
        string resourcePath = null, List<string> resourceTypes = null);

    /// <summary>
    ///     Get admin events   Returns all admin events, or filters events based on URL query parameters listed here
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="authClient"> (optional)</param>
    /// <param name="authIpAddress"> (optional)</param>
    /// <param name="authRealm"> (optional)</param>
    /// <param name="authUser">user id (optional)</param>
    /// <param name="dateFrom"> (optional)</param>
    /// <param name="dateTo"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="operationTypes"> (optional)</param>
    /// <param name="resourcePath"> (optional)</param>
    /// <param name="resourceTypes"> (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmAdminEventsGetAsyncWithHttpInfo(string realm,
        string authClient = null, string authIpAddress = null, string authRealm = null, string authUser = null,
        string dateFrom = null, string dateTo = null, int? first = null, int? max = null,
        List<string> operationTypes = null, string resourcePath = null, List<string> resourceTypes = null);

    /// <summary>
    ///     Clear cache of external public keys (Public keys of clients or Identity providers)
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmClearKeysCachePostAsync(string realm);

    /// <summary>
    ///     Clear cache of external public keys (Public keys of clients or Identity providers)
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClearKeysCachePostAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Clear realm cache
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmClearRealmCachePostAsync(string realm);

    /// <summary>
    ///     Clear realm cache
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClearRealmCachePostAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Clear user cache
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmClearUserCachePostAsync(string realm);

    /// <summary>
    ///     Clear user cache
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClearUserCachePostAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Base path for importing clients under this realm.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ClientRepresentation</returns>
    Task<ClientRepresentation> RealmClientDescriptionConverterPostAsync(string body, string realm);

    /// <summary>
    ///     Base path for importing clients under this realm.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (ClientRepresentation)</returns>
    Task<ApiResponse<ClientRepresentation>> RealmClientDescriptionConverterPostAsyncWithHttpInfo(string body,
        string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ClientPoliciesRepresentation</returns>
    Task<ClientPoliciesRepresentation> RealmClientPoliciesPoliciesGetAsync(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (ClientPoliciesRepresentation)</returns>
    Task<ApiResponse<ClientPoliciesRepresentation>> RealmClientPoliciesPoliciesGetAsyncWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmClientPoliciesPoliciesPutAsync(ClientPoliciesRepresentation body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientPoliciesPoliciesPutAsyncWithHttpInfo(ClientPoliciesRepresentation body,
        string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="includeGlobalProfiles"> (optional)</param>
    /// <returns>Task of ClientProfilesRepresentation</returns>
    Task<ClientProfilesRepresentation> RealmClientPoliciesProfilesGetAsync(string realm,
        bool? includeGlobalProfiles = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="includeGlobalProfiles"> (optional)</param>
    /// <returns>Task of ApiResponse (ClientProfilesRepresentation)</returns>
    Task<ApiResponse<ClientProfilesRepresentation>> RealmClientPoliciesProfilesGetAsyncWithHttpInfo(string realm,
        bool? includeGlobalProfiles = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmClientPoliciesProfilesPutAsync(ClientProfilesRepresentation body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientPoliciesProfilesPutAsyncWithHttpInfo(ClientProfilesRepresentation body,
        string realm);

    /// <summary>
    ///     Get client session stats   Returns a JSON map.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientSessionStatsGetAsync(string realm);

    /// <summary>
    ///     Get client session stats   Returns a JSON map.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientSessionStatsGetAsyncWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmCredentialRegistratorsGetAsync(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmCredentialRegistratorsGetAsyncWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of void</returns>
    Task RealmDefaultDefaultClientScopesClientScopeIdDeleteAsync(string realm, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmDefaultDefaultClientScopesClientScopeIdDeleteAsyncWithHttpInfo(string realm,
        string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of void</returns>
    Task RealmDefaultDefaultClientScopesClientScopeIdPutAsync(string realm, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmDefaultDefaultClientScopesClientScopeIdPutAsyncWithHttpInfo(string realm,
        string clientScopeId);

    /// <summary>
    ///     Get realm default client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmDefaultDefaultClientScopesGetAsync(string realm);

    /// <summary>
    ///     Get realm default client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmDefaultDefaultClientScopesGetAsyncWithHttpInfo(
        string realm);

    /// <summary>
    ///     Get group hierarchy.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmDefaultGroupsGetAsync(string realm);

    /// <summary>
    ///     Get group hierarchy.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmDefaultGroupsGetAsyncWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="groupId"></param>
    /// <returns>Task of void</returns>
    Task RealmDefaultGroupsGroupIdDeleteAsync(string realm, string groupId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="groupId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmDefaultGroupsGroupIdDeleteAsyncWithHttpInfo(string realm, string groupId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="groupId"></param>
    /// <returns>Task of void</returns>
    Task RealmDefaultGroupsGroupIdPutAsync(string realm, string groupId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="groupId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmDefaultGroupsGroupIdPutAsyncWithHttpInfo(string realm, string groupId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of void</returns>
    Task RealmDefaultOptionalClientScopesClientScopeIdDeleteAsync(string realm, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmDefaultOptionalClientScopesClientScopeIdDeleteAsyncWithHttpInfo(string realm,
        string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of void</returns>
    Task RealmDefaultOptionalClientScopesClientScopeIdPutAsync(string realm, string clientScopeId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientScopeId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmDefaultOptionalClientScopesClientScopeIdPutAsyncWithHttpInfo(string realm,
        string clientScopeId);

    /// <summary>
    ///     Get realm optional client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmDefaultOptionalClientScopesGetAsync(string realm);

    /// <summary>
    ///     Get realm optional client scopes.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmDefaultOptionalClientScopesGetAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Delete the realm
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmDeleteAsync(string realm);

    /// <summary>
    ///     Delete the realm
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmDeleteAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Get the events provider configuration   Returns JSON object with events provider configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of RealmEventsConfigRepresentation</returns>
    Task<RealmEventsConfigRepresentation> RealmEventsConfigGetAsync(string realm);

    /// <summary>
    ///     Get the events provider configuration   Returns JSON object with events provider configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (RealmEventsConfigRepresentation)</returns>
    Task<ApiResponse<RealmEventsConfigRepresentation>> RealmEventsConfigGetAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Update the events provider   Change the events provider and/or its configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmEventsConfigPutAsync(RealmEventsConfigRepresentation body, string realm);

    /// <summary>
    ///     Update the events provider   Change the events provider and/or its configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmEventsConfigPutAsyncWithHttpInfo(RealmEventsConfigRepresentation body, string realm);

    /// <summary>
    ///     Delete all events
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmEventsDeleteAsync(string realm);

    /// <summary>
    ///     Delete all events
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmEventsDeleteAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Get events   Returns all events, or filters them based on URL query parameters listed here
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="_client">App or oauth client name (optional)</param>
    /// <param name="dateFrom">From date (optional)</param>
    /// <param name="dateTo">To date (optional)</param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="ipAddress">IP address (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="type">The types of events to return (optional)</param>
    /// <param name="user">User id (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmEventsGetAsync(string realm, string _client = null,
        string dateFrom = null, string dateTo = null, int? first = null, string ipAddress = null, int? max = null,
        List<string> type = null, string user = null);

    /// <summary>
    ///     Get events   Returns all events, or filters them based on URL query parameters listed here
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="_client">App or oauth client name (optional)</param>
    /// <param name="dateFrom">From date (optional)</param>
    /// <param name="dateTo">To date (optional)</param>
    /// <param name="first">Paging offset (optional)</param>
    /// <param name="ipAddress">IP address (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="type">The types of events to return (optional)</param>
    /// <param name="user">User id (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmEventsGetAsyncWithHttpInfo(string realm,
        string _client = null, string dateFrom = null, string dateTo = null, int? first = null, string ipAddress = null,
        int? max = null, List<string> type = null, string user = null);

    /// <summary>
    ///     Get the top-level representation of the realm   It will not include nested information like User and Client
    ///     representations.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of RealmRepresentation</returns>
    Task<RealmRepresentation> RealmGetAsync(string realm);

    /// <summary>
    ///     Get the top-level representation of the realm   It will not include nested information like User and Client
    ///     representations.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (RealmRepresentation)</returns>
    Task<ApiResponse<RealmRepresentation>> RealmGetAsyncWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="path"></param>
    /// <returns>Task of GroupRepresentation</returns>
    Task<GroupRepresentation> RealmGroupByPathPathGetAsync(string realm, string path);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="path"></param>
    /// <returns>Task of ApiResponse (GroupRepresentation)</returns>
    Task<ApiResponse<GroupRepresentation>> RealmGroupByPathPathGetAsyncWithHttpInfo(string realm, string path);

    /// <summary>
    ///     Get LDAP supported extensions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">LDAP configuration</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmLdapServerCapabilitiesPostAsync(TestLdapConnectionRepresentation body, string realm);

    /// <summary>
    ///     Get LDAP supported extensions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">LDAP configuration</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmLdapServerCapabilitiesPostAsyncWithHttpInfo(TestLdapConnectionRepresentation body,
        string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmLocalizationGetAsync(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmLocalizationGetAsyncWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <returns>Task of void</returns>
    Task RealmLocalizationLocaleDeleteAsync(string realm, string locale);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmLocalizationLocaleDeleteAsyncWithHttpInfo(string realm, string locale);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
    Task<Dictionary<string, object>> RealmLocalizationLocaleGetAsync(string realm, string locale);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
    Task<ApiResponse<Dictionary<string, object>>> RealmLocalizationLocaleGetAsyncWithHttpInfo(string realm,
        string locale);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <param name="key"></param>
    /// <returns>Task of void</returns>
    Task RealmLocalizationLocaleKeyDeleteAsync(string realm, string locale, string key);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <param name="key"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>>
        RealmLocalizationLocaleKeyDeleteAsyncWithHttpInfo(string realm, string locale, string key);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <param name="key"></param>
    /// <returns>Task of string</returns>
    Task<string> RealmLocalizationLocaleKeyGetAsync(string realm, string locale, string key);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <param name="key"></param>
    /// <returns>Task of ApiResponse (string)</returns>
    Task<ApiResponse<string>> RealmLocalizationLocaleKeyGetAsyncWithHttpInfo(string realm, string locale, string key);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <param name="key"></param>
    /// <returns>Task of void</returns>
    Task RealmLocalizationLocaleKeyPutAsync(string body, string realm, string locale, string key);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <param name="key"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmLocalizationLocaleKeyPutAsyncWithHttpInfo(string body, string realm, string locale,
        string key);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <returns>Task of void</returns>
    Task RealmLocalizationLocalePostAsync(Dictionary<string, object> body, string realm, string locale);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="locale"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmLocalizationLocalePostAsyncWithHttpInfo(Dictionary<string, object> body,
        string realm, string locale);

    /// <summary>
    ///     Removes all user sessions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of GlobalRequestResult</returns>
    Task<GlobalRequestResult> RealmLogoutAllPostAsync(string realm);

    /// <summary>
    ///     Removes all user sessions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (GlobalRequestResult)</returns>
    Task<ApiResponse<GlobalRequestResult>> RealmLogoutAllPostAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Partial export of existing realm into a JSON file.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="exportClients"> (optional)</param>
    /// <param name="exportGroupsAndRoles"> (optional)</param>
    /// <returns>Task of RealmRepresentation</returns>
    Task<RealmRepresentation> RealmPartialExportPostAsync(string realm, bool? exportClients = null,
        bool? exportGroupsAndRoles = null);

    /// <summary>
    ///     Partial export of existing realm into a JSON file.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="exportClients"> (optional)</param>
    /// <param name="exportGroupsAndRoles"> (optional)</param>
    /// <returns>Task of ApiResponse (RealmRepresentation)</returns>
    Task<ApiResponse<RealmRepresentation>> RealmPartialExportPostAsyncWithHttpInfo(string realm,
        bool? exportClients = null, bool? exportGroupsAndRoles = null);

    /// <summary>
    ///     Partial import from a JSON file to an existing realm.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmPartialImportPostAsync(PartialImportRepresentation body, string realm);

    /// <summary>
    ///     Partial import from a JSON file to an existing realm.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmPartialImportPostAsyncWithHttpInfo(PartialImportRepresentation body, string realm);

    /// <summary>
    ///     Push the realm’s revocation policy to any client that has an admin url associated with it.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmPushRevocationPostAsync(string realm);

    /// <summary>
    ///     Push the realm’s revocation policy to any client that has an admin url associated with it.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmPushRevocationPostAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Update the top-level information of the realm   Any user, roles or client information in the representation  will
    ///     be ignored.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmPutAsync(RealmRepresentation body, string realm);

    /// <summary>
    ///     Update the top-level information of the realm   Any user, roles or client information in the representation  will
    ///     be ignored.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmPutAsyncWithHttpInfo(RealmRepresentation body, string realm);

    /// <summary>
    ///     Remove a specific user session.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="session"></param>
    /// <returns>Task of void</returns>
    Task RealmSessionsSessionDeleteAsync(string realm, string session);

    /// <summary>
    ///     Remove a specific user session.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="session"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmSessionsSessionDeleteAsyncWithHttpInfo(string realm, string session);

    /// <summary>
    ///     Test LDAP connection
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmTestLDAPConnectionPostAsync(TestLdapConnectionRepresentation body, string realm);

    /// <summary>
    ///     Test LDAP connection
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmTestLDAPConnectionPostAsyncWithHttpInfo(TestLdapConnectionRepresentation body,
        string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmTestSMTPConnectionPostAsync(Dictionary<string, object> body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmTestSMTPConnectionPostAsyncWithHttpInfo(Dictionary<string, object> body,
        string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ManagementPermissionReference</returns>
    Task<ManagementPermissionReference> RealmUsersManagementPermissionsGetAsync(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (ManagementPermissionReference)</returns>
    Task<ApiResponse<ManagementPermissionReference>> RealmUsersManagementPermissionsGetAsyncWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ManagementPermissionReference</returns>
    Task<ManagementPermissionReference> RealmUsersManagementPermissionsPutAsync(ManagementPermissionReference body,
        string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (ManagementPermissionReference)</returns>
    Task<ApiResponse<ManagementPermissionReference>> RealmUsersManagementPermissionsPutAsyncWithHttpInfo(
        ManagementPermissionReference body, string realm);

    /// <summary>
    ///     Import a realm   Imports a realm from a full representation of that realm.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON representation of the realm</param>
    /// <returns>Task of void</returns>
    Task RootPostAsync(RealmRepresentation body);

    /// <summary>
    ///     Import a realm   Imports a realm from a full representation of that realm.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON representation of the realm</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RootPostAsyncWithHttpInfo(RealmRepresentation body);

    #endregion Asynchronous Operations
}