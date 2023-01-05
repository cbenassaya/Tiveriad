using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IClientRoleMappingsApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Get available client-level roles that can be mapped to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmGroupsIdRoleMappingsClientsClientAvailableGet(string realm, string id,
        string _client);

    /// <summary>
    ///     Get available client-level roles that can be mapped to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmGroupsIdRoleMappingsClientsClientAvailableGetWithHttpInfo(
        string realm, string id, string _client);

    /// <summary>
    ///     Get effective client-level role mappings   This recurses any composite roles
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmGroupsIdRoleMappingsClientsClientCompositeGet(string realm, string id,
        string _client, bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective client-level role mappings   This recurses any composite roles
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmGroupsIdRoleMappingsClientsClientCompositeGetWithHttpInfo(
        string realm, string id, string _client, bool? briefRepresentation = null);

    /// <summary>
    ///     Delete client-level roles from user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns></returns>
    void RealmGroupsIdRoleMappingsClientsClientDelete(List<RoleRepresentation> body, string realm, string id,
        string _client);

    /// <summary>
    ///     Delete client-level roles from user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmGroupsIdRoleMappingsClientsClientDeleteWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id, string _client);

    /// <summary>
    ///     Get client-level role mappings for the user, and the app
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmGroupsIdRoleMappingsClientsClientGet(string realm, string id, string _client);

    /// <summary>
    ///     Get client-level role mappings for the user, and the app
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmGroupsIdRoleMappingsClientsClientGetWithHttpInfo(string realm,
        string id, string _client);

    /// <summary>
    ///     Add client-level roles to the user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns></returns>
    void RealmGroupsIdRoleMappingsClientsClientPost(List<RoleRepresentation> body, string realm, string id,
        string _client);

    /// <summary>
    ///     Add client-level roles to the user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmGroupsIdRoleMappingsClientsClientPostWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id, string _client);

    /// <summary>
    ///     Get available client-level roles that can be mapped to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmUsersIdRoleMappingsClientsClientAvailableGet(string realm, string id,
        string _client);

    /// <summary>
    ///     Get available client-level roles that can be mapped to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmUsersIdRoleMappingsClientsClientAvailableGetWithHttpInfo(
        string realm, string id, string _client);

    /// <summary>
    ///     Get effective client-level role mappings   This recurses any composite roles
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmUsersIdRoleMappingsClientsClientCompositeGet(string realm, string id,
        string _client, bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective client-level role mappings   This recurses any composite roles
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmUsersIdRoleMappingsClientsClientCompositeGetWithHttpInfo(
        string realm, string id, string _client, bool? briefRepresentation = null);

    /// <summary>
    ///     Delete client-level roles from user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns></returns>
    void RealmUsersIdRoleMappingsClientsClientDelete(List<RoleRepresentation> body, string realm, string id,
        string _client);

    /// <summary>
    ///     Delete client-level roles from user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdRoleMappingsClientsClientDeleteWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id, string _client);

    /// <summary>
    ///     Get client-level role mappings for the user, and the app
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmUsersIdRoleMappingsClientsClientGet(string realm, string id, string _client);

    /// <summary>
    ///     Get client-level role mappings for the user, and the app
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmUsersIdRoleMappingsClientsClientGetWithHttpInfo(string realm,
        string id, string _client);

    /// <summary>
    ///     Add client-level roles to the user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns></returns>
    void RealmUsersIdRoleMappingsClientsClientPost(List<RoleRepresentation> body, string realm, string id,
        string _client);

    /// <summary>
    ///     Add client-level roles to the user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdRoleMappingsClientsClientPostWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id, string _client);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Get available client-level roles that can be mapped to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmGroupsIdRoleMappingsClientsClientAvailableGetAsync(string realm,
        string id, string _client);

    /// <summary>
    ///     Get available client-level roles that can be mapped to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmGroupsIdRoleMappingsClientsClientAvailableGetAsyncWithHttpInfo(string realm, string id, string _client);

    /// <summary>
    ///     Get effective client-level role mappings   This recurses any composite roles
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmGroupsIdRoleMappingsClientsClientCompositeGetAsync(string realm,
        string id, string _client, bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective client-level role mappings   This recurses any composite roles
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmGroupsIdRoleMappingsClientsClientCompositeGetAsyncWithHttpInfo(string realm, string id, string _client,
            bool? briefRepresentation = null);

    /// <summary>
    ///     Delete client-level roles from user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns>Task of void</returns>
    Task RealmGroupsIdRoleMappingsClientsClientDeleteAsync(List<RoleRepresentation> body, string realm, string id,
        string _client);

    /// <summary>
    ///     Delete client-level roles from user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmGroupsIdRoleMappingsClientsClientDeleteAsyncWithHttpInfo(
        List<RoleRepresentation> body, string realm, string id, string _client);

    /// <summary>
    ///     Get client-level role mappings for the user, and the app
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmGroupsIdRoleMappingsClientsClientGetAsync(string realm, string id,
        string _client);

    /// <summary>
    ///     Get client-level role mappings for the user, and the app
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmGroupsIdRoleMappingsClientsClientGetAsyncWithHttpInfo(
        string realm, string id, string _client);

    /// <summary>
    ///     Add client-level roles to the user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns>Task of void</returns>
    Task RealmGroupsIdRoleMappingsClientsClientPostAsync(List<RoleRepresentation> body, string realm, string id,
        string _client);

    /// <summary>
    ///     Add client-level roles to the user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmGroupsIdRoleMappingsClientsClientPostAsyncWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id, string _client);

    /// <summary>
    ///     Get available client-level roles that can be mapped to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmUsersIdRoleMappingsClientsClientAvailableGetAsync(string realm,
        string id, string _client);

    /// <summary>
    ///     Get available client-level roles that can be mapped to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmUsersIdRoleMappingsClientsClientAvailableGetAsyncWithHttpInfo(string realm, string id, string _client);

    /// <summary>
    ///     Get effective client-level role mappings   This recurses any composite roles
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmUsersIdRoleMappingsClientsClientCompositeGetAsync(string realm,
        string id, string _client, bool? briefRepresentation = null);

    /// <summary>
    ///     Get effective client-level role mappings   This recurses any composite roles
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmUsersIdRoleMappingsClientsClientCompositeGetAsyncWithHttpInfo(string realm, string id, string _client,
            bool? briefRepresentation = null);

    /// <summary>
    ///     Delete client-level roles from user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdRoleMappingsClientsClientDeleteAsync(List<RoleRepresentation> body, string realm, string id,
        string _client);

    /// <summary>
    ///     Delete client-level roles from user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdRoleMappingsClientsClientDeleteAsyncWithHttpInfo(
        List<RoleRepresentation> body, string realm, string id, string _client);

    /// <summary>
    ///     Get client-level role mappings for the user, and the app
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmUsersIdRoleMappingsClientsClientGetAsync(string realm, string id,
        string _client);

    /// <summary>
    ///     Get client-level role mappings for the user, and the app
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmUsersIdRoleMappingsClientsClientGetAsyncWithHttpInfo(
        string realm, string id, string _client);

    /// <summary>
    ///     Add client-level roles to the user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdRoleMappingsClientsClientPostAsync(List<RoleRepresentation> body, string realm, string id,
        string _client);

    /// <summary>
    ///     Add client-level roles to the user role mapping
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdRoleMappingsClientsClientPostAsyncWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id, string _client);

    #endregion Asynchronous Operations
}