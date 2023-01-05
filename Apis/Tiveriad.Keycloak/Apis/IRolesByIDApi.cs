using Tiveriad.Keycloak.Models;namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IRolesByIDApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <param name="clientUuid"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmRolesByIdRoleIdCompositesClientsClientUuidGet(string realm, string roleId,
        string clientUuid);

    /// <summary>
    ///     Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <param name="clientUuid"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmRolesByIdRoleIdCompositesClientsClientUuidGetWithHttpInfo(
        string realm, string roleId, string clientUuid);

    /// <summary>
    ///     Remove a set of roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">A set of roles to be removed</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">Role id</param>
    /// <returns></returns>
    void RealmRolesByIdRoleIdCompositesDelete(List<RoleRepresentation> body, string realm, string roleId);

    /// <summary>
    ///     Remove a set of roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">A set of roles to be removed</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">Role id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmRolesByIdRoleIdCompositesDeleteWithHttpInfo(List<RoleRepresentation> body, string realm,
        string roleId);

    /// <summary>
    ///     Get role’s children   Returns a set of role’s children provided the role is a composite.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">Role id</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmRolesByIdRoleIdCompositesGet(string realm, string roleId, int? first = null,
        int? max = null, string search = null);

    /// <summary>
    ///     Get role’s children   Returns a set of role’s children provided the role is a composite.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">Role id</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmRolesByIdRoleIdCompositesGetWithHttpInfo(string realm,
        string roleId, int? first = null, int? max = null, string search = null);

    /// <summary>
    ///     Make the role a composite role by associating some child roles
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">Role id</param>
    /// <returns></returns>
    void RealmRolesByIdRoleIdCompositesPost(List<RoleRepresentation> body, string realm, string roleId);

    /// <summary>
    ///     Make the role a composite role by associating some child roles
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">Role id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmRolesByIdRoleIdCompositesPostWithHttpInfo(List<RoleRepresentation> body, string realm,
        string roleId);

    /// <summary>
    ///     Get realm-level roles that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmRolesByIdRoleIdCompositesRealmGet(string realm, string roleId);

    /// <summary>
    ///     Get realm-level roles that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmRolesByIdRoleIdCompositesRealmGetWithHttpInfo(string realm,
        string roleId);

    /// <summary>
    ///     Delete the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">id of role</param>
    /// <returns></returns>
    void RealmRolesByIdRoleIdDelete(string realm, string roleId);

    /// <summary>
    ///     Delete the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">id of role</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmRolesByIdRoleIdDeleteWithHttpInfo(string realm, string roleId);

    /// <summary>
    ///     Get a specific role’s representation
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">id of role</param>
    /// <returns>RoleRepresentation</returns>
    RoleRepresentation RealmRolesByIdRoleIdGet(string realm, string roleId);

    /// <summary>
    ///     Get a specific role’s representation
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">id of role</param>
    /// <returns>ApiResponse of RoleRepresentation</returns>
    ApiResponse<RoleRepresentation> RealmRolesByIdRoleIdGetWithHttpInfo(string realm, string roleId);

    /// <summary>
    ///     Return object stating whether role Authoirzation permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <returns>ManagementPermissionReference</returns>
    ManagementPermissionReference RealmRolesByIdRoleIdManagementPermissionsGet(string realm, string roleId);

    /// <summary>
    ///     Return object stating whether role Authoirzation permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <returns>ApiResponse of ManagementPermissionReference</returns>
    ApiResponse<ManagementPermissionReference> RealmRolesByIdRoleIdManagementPermissionsGetWithHttpInfo(string realm,
        string roleId);

    /// <summary>
    ///     Return object stating whether role Authoirzation permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <returns>ManagementPermissionReference</returns>
    ManagementPermissionReference RealmRolesByIdRoleIdManagementPermissionsPut(ManagementPermissionReference body,
        string realm, string roleId);

    /// <summary>
    ///     Return object stating whether role Authoirzation permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <returns>ApiResponse of ManagementPermissionReference</returns>
    ApiResponse<ManagementPermissionReference> RealmRolesByIdRoleIdManagementPermissionsPutWithHttpInfo(
        ManagementPermissionReference body, string realm, string roleId);

    /// <summary>
    ///     Update the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">id of role</param>
    /// <returns></returns>
    void RealmRolesByIdRoleIdPut(RoleRepresentation body, string realm, string roleId);

    /// <summary>
    ///     Update the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">id of role</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmRolesByIdRoleIdPutWithHttpInfo(RoleRepresentation body, string realm, string roleId);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <param name="clientUuid"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmRolesByIdRoleIdCompositesClientsClientUuidGetAsync(string realm,
        string roleId, string clientUuid);

    /// <summary>
    ///     Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <param name="clientUuid"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmRolesByIdRoleIdCompositesClientsClientUuidGetAsyncWithHttpInfo(string realm, string roleId,
            string clientUuid);

    /// <summary>
    ///     Remove a set of roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">A set of roles to be removed</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">Role id</param>
    /// <returns>Task of void</returns>
    Task RealmRolesByIdRoleIdCompositesDeleteAsync(List<RoleRepresentation> body, string realm, string roleId);

    /// <summary>
    ///     Remove a set of roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">A set of roles to be removed</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">Role id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmRolesByIdRoleIdCompositesDeleteAsyncWithHttpInfo(List<RoleRepresentation> body,
        string realm, string roleId);

    /// <summary>
    ///     Get role’s children   Returns a set of role’s children provided the role is a composite.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">Role id</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmRolesByIdRoleIdCompositesGetAsync(string realm, string roleId,
        int? first = null, int? max = null, string search = null);

    /// <summary>
    ///     Get role’s children   Returns a set of role’s children provided the role is a composite.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">Role id</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmRolesByIdRoleIdCompositesGetAsyncWithHttpInfo(string realm,
        string roleId, int? first = null, int? max = null, string search = null);

    /// <summary>
    ///     Make the role a composite role by associating some child roles
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">Role id</param>
    /// <returns>Task of void</returns>
    Task RealmRolesByIdRoleIdCompositesPostAsync(List<RoleRepresentation> body, string realm, string roleId);

    /// <summary>
    ///     Make the role a composite role by associating some child roles
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">Role id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmRolesByIdRoleIdCompositesPostAsyncWithHttpInfo(List<RoleRepresentation> body,
        string realm, string roleId);

    /// <summary>
    ///     Get realm-level roles that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmRolesByIdRoleIdCompositesRealmGetAsync(string realm, string roleId);

    /// <summary>
    ///     Get realm-level roles that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmRolesByIdRoleIdCompositesRealmGetAsyncWithHttpInfo(
        string realm, string roleId);

    /// <summary>
    ///     Delete the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">id of role</param>
    /// <returns>Task of void</returns>
    Task RealmRolesByIdRoleIdDeleteAsync(string realm, string roleId);

    /// <summary>
    ///     Delete the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">id of role</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmRolesByIdRoleIdDeleteAsyncWithHttpInfo(string realm, string roleId);

    /// <summary>
    ///     Get a specific role’s representation
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">id of role</param>
    /// <returns>Task of RoleRepresentation</returns>
    Task<RoleRepresentation> RealmRolesByIdRoleIdGetAsync(string realm, string roleId);

    /// <summary>
    ///     Get a specific role’s representation
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">id of role</param>
    /// <returns>Task of ApiResponse (RoleRepresentation)</returns>
    Task<ApiResponse<RoleRepresentation>> RealmRolesByIdRoleIdGetAsyncWithHttpInfo(string realm, string roleId);

    /// <summary>
    ///     Return object stating whether role Authoirzation permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <returns>Task of ManagementPermissionReference</returns>
    Task<ManagementPermissionReference> RealmRolesByIdRoleIdManagementPermissionsGetAsync(string realm, string roleId);

    /// <summary>
    ///     Return object stating whether role Authoirzation permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <returns>Task of ApiResponse (ManagementPermissionReference)</returns>
    Task<ApiResponse<ManagementPermissionReference>> RealmRolesByIdRoleIdManagementPermissionsGetAsyncWithHttpInfo(
        string realm, string roleId);

    /// <summary>
    ///     Return object stating whether role Authoirzation permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <returns>Task of ManagementPermissionReference</returns>
    Task<ManagementPermissionReference> RealmRolesByIdRoleIdManagementPermissionsPutAsync(
        ManagementPermissionReference body, string realm, string roleId);

    /// <summary>
    ///     Return object stating whether role Authoirzation permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId"></param>
    /// <returns>Task of ApiResponse (ManagementPermissionReference)</returns>
    Task<ApiResponse<ManagementPermissionReference>> RealmRolesByIdRoleIdManagementPermissionsPutAsyncWithHttpInfo(
        ManagementPermissionReference body, string realm, string roleId);

    /// <summary>
    ///     Update the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">id of role</param>
    /// <returns>Task of void</returns>
    Task RealmRolesByIdRoleIdPutAsync(RoleRepresentation body, string realm, string roleId);

    /// <summary>
    ///     Update the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleId">id of role</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmRolesByIdRoleIdPutAsyncWithHttpInfo(RoleRepresentation body, string realm,
        string roleId);

    #endregion Asynchronous Operations
}