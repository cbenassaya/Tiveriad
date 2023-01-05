using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IRoleMapperApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Get role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>MappingsRepresentation</returns>
    MappingsRepresentation RealmGroupsIdRoleMappingsGet(string realm, string id);

    /// <summary>
    ///     Get role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of MappingsRepresentation</returns>
    ApiResponse<MappingsRepresentation> RealmGroupsIdRoleMappingsGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get realm-level roles that can be mapped
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmGroupsIdRoleMappingsRealmAvailableGet(string realm, string id);

    /// <summary>
    ///     Get realm-level roles that can be mapped
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmGroupsIdRoleMappingsRealmAvailableGetWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Get effective realm-level role mappings   This will recurse all composite roles to get the result.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmGroupsIdRoleMappingsRealmCompositeGet(string realm, string id,
        bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective realm-level role mappings   This will recurse all composite roles to get the result.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmGroupsIdRoleMappingsRealmCompositeGetWithHttpInfo(string realm,
        string id, bool? briefRepresentation = null);

    /// <summary>
    ///     Delete realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns></returns>
    void RealmGroupsIdRoleMappingsRealmDelete(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Delete realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmGroupsIdRoleMappingsRealmDeleteWithHttpInfo(List<RoleRepresentation> body, string realm,
        string id);

    /// <summary>
    ///     Get realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmGroupsIdRoleMappingsRealmGet(string realm, string id);

    /// <summary>
    ///     Get realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>>
        RealmGroupsIdRoleMappingsRealmGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Add realm-level role mappings to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Roles to add</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns></returns>
    void RealmGroupsIdRoleMappingsRealmPost(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Add realm-level role mappings to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Roles to add</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmGroupsIdRoleMappingsRealmPostWithHttpInfo(List<RoleRepresentation> body, string realm,
        string id);

    /// <summary>
    ///     Get role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>MappingsRepresentation</returns>
    MappingsRepresentation RealmUsersIdRoleMappingsGet(string realm, string id);

    /// <summary>
    ///     Get role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of MappingsRepresentation</returns>
    ApiResponse<MappingsRepresentation> RealmUsersIdRoleMappingsGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get realm-level roles that can be mapped
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmUsersIdRoleMappingsRealmAvailableGet(string realm, string id);

    /// <summary>
    ///     Get realm-level roles that can be mapped
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmUsersIdRoleMappingsRealmAvailableGetWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Get effective realm-level role mappings   This will recurse all composite roles to get the result.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmUsersIdRoleMappingsRealmCompositeGet(string realm, string id,
        bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective realm-level role mappings   This will recurse all composite roles to get the result.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmUsersIdRoleMappingsRealmCompositeGetWithHttpInfo(string realm,
        string id, bool? briefRepresentation = null);

    /// <summary>
    ///     Delete realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns></returns>
    void RealmUsersIdRoleMappingsRealmDelete(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Delete realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdRoleMappingsRealmDeleteWithHttpInfo(List<RoleRepresentation> body, string realm,
        string id);

    /// <summary>
    ///     Get realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmUsersIdRoleMappingsRealmGet(string realm, string id);

    /// <summary>
    ///     Get realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmUsersIdRoleMappingsRealmGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Add realm-level role mappings to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Roles to add</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns></returns>
    void RealmUsersIdRoleMappingsRealmPost(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Add realm-level role mappings to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Roles to add</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdRoleMappingsRealmPostWithHttpInfo(List<RoleRepresentation> body, string realm,
        string id);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Get role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of MappingsRepresentation</returns>
    Task<MappingsRepresentation> RealmGroupsIdRoleMappingsGetAsync(string realm, string id);

    /// <summary>
    ///     Get role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse (MappingsRepresentation)</returns>
    Task<ApiResponse<MappingsRepresentation>> RealmGroupsIdRoleMappingsGetAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get realm-level roles that can be mapped
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmGroupsIdRoleMappingsRealmAvailableGetAsync(string realm, string id);

    /// <summary>
    ///     Get realm-level roles that can be mapped
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmGroupsIdRoleMappingsRealmAvailableGetAsyncWithHttpInfo(
        string realm, string id);

    /// <summary>
    ///     Get effective realm-level role mappings   This will recurse all composite roles to get the result.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmGroupsIdRoleMappingsRealmCompositeGetAsync(string realm, string id,
        bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective realm-level role mappings   This will recurse all composite roles to get the result.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmGroupsIdRoleMappingsRealmCompositeGetAsyncWithHttpInfo(
        string realm, string id, bool? briefRepresentation = null);

    /// <summary>
    ///     Delete realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of void</returns>
    Task RealmGroupsIdRoleMappingsRealmDeleteAsync(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Delete realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmGroupsIdRoleMappingsRealmDeleteAsyncWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id);

    /// <summary>
    ///     Get realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmGroupsIdRoleMappingsRealmGetAsync(string realm, string id);

    /// <summary>
    ///     Get realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmGroupsIdRoleMappingsRealmGetAsyncWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Add realm-level role mappings to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Roles to add</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of void</returns>
    Task RealmGroupsIdRoleMappingsRealmPostAsync(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Add realm-level role mappings to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Roles to add</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmGroupsIdRoleMappingsRealmPostAsyncWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id);

    /// <summary>
    ///     Get role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of MappingsRepresentation</returns>
    Task<MappingsRepresentation> RealmUsersIdRoleMappingsGetAsync(string realm, string id);

    /// <summary>
    ///     Get role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse (MappingsRepresentation)</returns>
    Task<ApiResponse<MappingsRepresentation>> RealmUsersIdRoleMappingsGetAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get realm-level roles that can be mapped
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmUsersIdRoleMappingsRealmAvailableGetAsync(string realm, string id);

    /// <summary>
    ///     Get realm-level roles that can be mapped
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmUsersIdRoleMappingsRealmAvailableGetAsyncWithHttpInfo(
        string realm, string id);

    /// <summary>
    ///     Get effective realm-level role mappings   This will recurse all composite roles to get the result.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmUsersIdRoleMappingsRealmCompositeGetAsync(string realm, string id,
        bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective realm-level role mappings   This will recurse all composite roles to get the result.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmUsersIdRoleMappingsRealmCompositeGetAsyncWithHttpInfo(
        string realm, string id, bool? briefRepresentation = null);

    /// <summary>
    ///     Delete realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdRoleMappingsRealmDeleteAsync(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Delete realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdRoleMappingsRealmDeleteAsyncWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id);

    /// <summary>
    ///     Get realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmUsersIdRoleMappingsRealmGetAsync(string realm, string id);

    /// <summary>
    ///     Get realm-level role mappings
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmUsersIdRoleMappingsRealmGetAsyncWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Add realm-level role mappings to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Roles to add</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdRoleMappingsRealmPostAsync(List<RoleRepresentation> body, string realm, string id);

    /// <summary>
    ///     Add realm-level role mappings to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Roles to add</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdRoleMappingsRealmPostAsyncWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id);

    #endregion Asynchronous Operations
}