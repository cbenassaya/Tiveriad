using Tiveriad.Keycloak.Models;namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IGroupsApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Returns the groups counts.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="search"> (optional)</param>
    /// <param name="top"> (optional)</param>
    /// <returns>Dictionary&lt;string, Object&gt;</returns>
    Dictionary<string, object> RealmGroupsCountGet(string realm, string search = null, bool? top = null);

    /// <summary>
    ///     Returns the groups counts.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="search"> (optional)</param>
    /// <param name="top"> (optional)</param>
    /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
    ApiResponse<Dictionary<string, object>> RealmGroupsCountGetWithHttpInfo(string realm, string search = null,
        bool? top = null);

    /// <summary>
    ///     Get group hierarchy.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmGroupsGet(string realm, bool? briefRepresentation = null, int? first = null,
        int? max = null, string search = null);

    /// <summary>
    ///     Get group hierarchy.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmGroupsGetWithHttpInfo(string realm,
        bool? briefRepresentation = null, int? first = null, int? max = null, string search = null);

    /// <summary>
    ///     Set or create child.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns></returns>
    void RealmGroupsIdChildrenPost(GroupRepresentation body, string realm, string id);

    /// <summary>
    ///     Set or create child.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmGroupsIdChildrenPostWithHttpInfo(GroupRepresentation body, string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns></returns>
    void RealmGroupsIdDelete(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmGroupsIdDeleteWithHttpInfo(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>GroupRepresentation</returns>
    GroupRepresentation RealmGroupsIdGet(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of GroupRepresentation</returns>
    ApiResponse<GroupRepresentation> RealmGroupsIdGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ManagementPermissionReference</returns>
    ManagementPermissionReference RealmGroupsIdManagementPermissionsGet(string realm, string id);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of ManagementPermissionReference</returns>
    ApiResponse<ManagementPermissionReference> RealmGroupsIdManagementPermissionsGetWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ManagementPermissionReference</returns>
    ManagementPermissionReference RealmGroupsIdManagementPermissionsPut(ManagementPermissionReference body,
        string realm, string id);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of ManagementPermissionReference</returns>
    ApiResponse<ManagementPermissionReference> RealmGroupsIdManagementPermissionsPutWithHttpInfo(
        ManagementPermissionReference body, string realm, string id);

    /// <summary>
    ///     Get users   Returns a stream of users, filtered according to query parameters
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">
    ///     Only return basic information (only guaranteed to return id, username, created, first
    ///     and last name,  email, enabled state, email verification state, federation link, and access.  Note that it means
    ///     that namely user attributes, required actions, and not before are not returned.) (optional)
    /// </param>
    /// <param name="first">Pagination offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmGroupsIdMembersGet(string realm, string id, bool? briefRepresentation = null,
        int? first = null, int? max = null);

    /// <summary>
    ///     Get users   Returns a stream of users, filtered according to query parameters
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">
    ///     Only return basic information (only guaranteed to return id, username, created, first
    ///     and last name,  email, enabled state, email verification state, federation link, and access.  Note that it means
    ///     that namely user attributes, required actions, and not before are not returned.) (optional)
    /// </param>
    /// <param name="first">Pagination offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmGroupsIdMembersGetWithHttpInfo(string realm, string id,
        bool? briefRepresentation = null, int? first = null, int? max = null);

    /// <summary>
    ///     Update group, ignores subgroups.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns></returns>
    void RealmGroupsIdPut(GroupRepresentation body, string realm, string id);

    /// <summary>
    ///     Update group, ignores subgroups.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmGroupsIdPutWithHttpInfo(GroupRepresentation body, string realm, string id);

    /// <summary>
    ///     create or add a top level realm groupSet or create child.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmGroupsPost(GroupRepresentation body, string realm);

    /// <summary>
    ///     create or add a top level realm groupSet or create child.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmGroupsPostWithHttpInfo(GroupRepresentation body, string realm);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Returns the groups counts.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="search"> (optional)</param>
    /// <param name="top"> (optional)</param>
    /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
    Task<Dictionary<string, object>> RealmGroupsCountGetAsync(string realm, string search = null, bool? top = null);

    /// <summary>
    ///     Returns the groups counts.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="search"> (optional)</param>
    /// <param name="top"> (optional)</param>
    /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
    Task<ApiResponse<Dictionary<string, object>>> RealmGroupsCountGetAsyncWithHttpInfo(string realm,
        string search = null, bool? top = null);

    /// <summary>
    ///     Get group hierarchy.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmGroupsGetAsync(string realm, bool? briefRepresentation = null,
        int? first = null, int? max = null, string search = null);

    /// <summary>
    ///     Get group hierarchy.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmGroupsGetAsyncWithHttpInfo(string realm,
        bool? briefRepresentation = null, int? first = null, int? max = null, string search = null);

    /// <summary>
    ///     Set or create child.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of void</returns>
    Task RealmGroupsIdChildrenPostAsync(GroupRepresentation body, string realm, string id);

    /// <summary>
    ///     Set or create child.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmGroupsIdChildrenPostAsyncWithHttpInfo(GroupRepresentation body, string realm,
        string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of void</returns>
    Task RealmGroupsIdDeleteAsync(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmGroupsIdDeleteAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of GroupRepresentation</returns>
    Task<GroupRepresentation> RealmGroupsIdGetAsync(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse (GroupRepresentation)</returns>
    Task<ApiResponse<GroupRepresentation>> RealmGroupsIdGetAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ManagementPermissionReference</returns>
    Task<ManagementPermissionReference> RealmGroupsIdManagementPermissionsGetAsync(string realm, string id);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse (ManagementPermissionReference)</returns>
    Task<ApiResponse<ManagementPermissionReference>> RealmGroupsIdManagementPermissionsGetAsyncWithHttpInfo(
        string realm, string id);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ManagementPermissionReference</returns>
    Task<ManagementPermissionReference> RealmGroupsIdManagementPermissionsPutAsync(ManagementPermissionReference body,
        string realm, string id);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse (ManagementPermissionReference)</returns>
    Task<ApiResponse<ManagementPermissionReference>> RealmGroupsIdManagementPermissionsPutAsyncWithHttpInfo(
        ManagementPermissionReference body, string realm, string id);

    /// <summary>
    ///     Get users   Returns a stream of users, filtered according to query parameters
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">
    ///     Only return basic information (only guaranteed to return id, username, created, first
    ///     and last name,  email, enabled state, email verification state, federation link, and access.  Note that it means
    ///     that namely user attributes, required actions, and not before are not returned.) (optional)
    /// </param>
    /// <param name="first">Pagination offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmGroupsIdMembersGetAsync(string realm, string id,
        bool? briefRepresentation = null, int? first = null, int? max = null);

    /// <summary>
    ///     Get users   Returns a stream of users, filtered according to query parameters
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">
    ///     Only return basic information (only guaranteed to return id, username, created, first
    ///     and last name,  email, enabled state, email verification state, federation link, and access.  Note that it means
    ///     that namely user attributes, required actions, and not before are not returned.) (optional)
    /// </param>
    /// <param name="first">Pagination offset (optional)</param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmGroupsIdMembersGetAsyncWithHttpInfo(string realm,
        string id, bool? briefRepresentation = null, int? first = null, int? max = null);

    /// <summary>
    ///     Update group, ignores subgroups.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of void</returns>
    Task RealmGroupsIdPutAsync(GroupRepresentation body, string realm, string id);

    /// <summary>
    ///     Update group, ignores subgroups.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmGroupsIdPutAsyncWithHttpInfo(GroupRepresentation body, string realm, string id);

    /// <summary>
    ///     create or add a top level realm groupSet or create child.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmGroupsPostAsync(GroupRepresentation body, string realm);

    /// <summary>
    ///     create or add a top level realm groupSet or create child.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmGroupsPostAsyncWithHttpInfo(GroupRepresentation body, string realm);

    #endregion Asynchronous Operations
}