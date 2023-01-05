using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IRolesApi
{
    #region Synchronous Operations

    /// <summary>
    ///     Get all roles for the realm or client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdRolesGet(string realm, string id, bool? briefRepresentation = null,
        int? first = null, int? max = null, string search = null);

    /// <summary>
    ///     Get all roles for the realm or client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdRolesGetWithHttpInfo(string realm, string id,
        bool? briefRepresentation = null, int? first = null, int? max = null, string search = null);

    /// <summary>
    ///     Create a new role for the realm or client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns></returns>
    void RealmClientsIdRolesPost(RoleRepresentation body, string realm, string id);

    /// <summary>
    ///     Create a new role for the realm or client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdRolesPostWithHttpInfo(RoleRepresentation body, string realm, string id);

    /// <summary>
    ///     Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <param name="clientUuid"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdRolesRoleNameCompositesClientsClientUuidGet(string realm, string id,
        string roleName, string clientUuid);

    /// <summary>
    ///     Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <param name="clientUuid"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdRolesRoleNameCompositesClientsClientUuidGetWithHttpInfo(
        string realm, string id, string roleName, string clientUuid);

    /// <summary>
    ///     Remove roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">roles to remove</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns></returns>
    void RealmClientsIdRolesRoleNameCompositesDelete(List<RoleRepresentation> body, string realm, string id,
        string roleName);

    /// <summary>
    ///     Remove roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">roles to remove</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdRolesRoleNameCompositesDeleteWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id, string roleName);

    /// <summary>
    ///     Get composites of the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdRolesRoleNameCompositesGet(string realm, string id, string roleName);

    /// <summary>
    ///     Get composites of the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdRolesRoleNameCompositesGetWithHttpInfo(string realm,
        string id, string roleName);

    /// <summary>
    ///     Add a composite to the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns></returns>
    void RealmClientsIdRolesRoleNameCompositesPost(List<RoleRepresentation> body, string realm, string id,
        string roleName);

    /// <summary>
    ///     Add a composite to the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdRolesRoleNameCompositesPostWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id, string roleName);

    /// <summary>
    ///     Get realm-level roles of the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdRolesRoleNameCompositesRealmGet(string realm, string id,
        string roleName);

    /// <summary>
    ///     Get realm-level roles of the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdRolesRoleNameCompositesRealmGetWithHttpInfo(
        string realm, string id, string roleName);

    /// <summary>
    ///     Delete a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns></returns>
    void RealmClientsIdRolesRoleNameDelete(string realm, string id, string roleName);

    /// <summary>
    ///     Delete a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdRolesRoleNameDeleteWithHttpInfo(string realm, string id, string roleName);

    /// <summary>
    ///     Get a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>RoleRepresentation</returns>
    RoleRepresentation RealmClientsIdRolesRoleNameGet(string realm, string id, string roleName);

    /// <summary>
    ///     Get a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>ApiResponse of RoleRepresentation</returns>
    ApiResponse<RoleRepresentation>
        RealmClientsIdRolesRoleNameGetWithHttpInfo(string realm, string id, string roleName);

    /// <summary>
    ///     Returns a stream of groups that have the specified role name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="briefRepresentation">
    ///     if false, return a full representation of the {@code GroupRepresentation} objects.
    ///     (optional)
    /// </param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdRolesRoleNameGroupsGet(string realm, string id, string roleName,
        bool? briefRepresentation = null, int? first = null, int? max = null);

    /// <summary>
    ///     Returns a stream of groups that have the specified role name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="briefRepresentation">
    ///     if false, return a full representation of the {@code GroupRepresentation} objects.
    ///     (optional)
    /// </param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdRolesRoleNameGroupsGetWithHttpInfo(string realm,
        string id, string roleName, bool? briefRepresentation = null, int? first = null, int? max = null);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName"></param>
    /// <returns>ManagementPermissionReference</returns>
    ManagementPermissionReference RealmClientsIdRolesRoleNameManagementPermissionsGet(string realm, string id,
        string roleName);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName"></param>
    /// <returns>ApiResponse of ManagementPermissionReference</returns>
    ApiResponse<ManagementPermissionReference> RealmClientsIdRolesRoleNameManagementPermissionsGetWithHttpInfo(
        string realm, string id, string roleName);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName"></param>
    /// <returns>ManagementPermissionReference</returns>
    ManagementPermissionReference RealmClientsIdRolesRoleNameManagementPermissionsPut(
        ManagementPermissionReference body, string realm, string id, string roleName);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName"></param>
    /// <returns>ApiResponse of ManagementPermissionReference</returns>
    ApiResponse<ManagementPermissionReference> RealmClientsIdRolesRoleNameManagementPermissionsPutWithHttpInfo(
        ManagementPermissionReference body, string realm, string id, string roleName);

    /// <summary>
    ///     Update a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns></returns>
    void RealmClientsIdRolesRoleNamePut(RoleRepresentation body, string realm, string id, string roleName);

    /// <summary>
    ///     Update a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdRolesRoleNamePutWithHttpInfo(RoleRepresentation body, string realm, string id,
        string roleName);

    /// <summary>
    ///     Returns a stream of users that have the specified role name.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdRolesRoleNameUsersGet(string realm, string id, string roleName,
        int? first = null, int? max = null);

    /// <summary>
    ///     Returns a stream of users that have the specified role name.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdRolesRoleNameUsersGetWithHttpInfo(string realm,
        string id, string roleName, int? first = null, int? max = null);

    /// <summary>
    ///     Get all roles for the realm or client
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
    List<Dictionary<string, object>> RealmRolesGet(string realm, bool? briefRepresentation = null, int? first = null,
        int? max = null, string search = null);

    /// <summary>
    ///     Get all roles for the realm or client
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
    ApiResponse<List<Dictionary<string, object>>> RealmRolesGetWithHttpInfo(string realm,
        bool? briefRepresentation = null, int? first = null, int? max = null, string search = null);

    /// <summary>
    ///     Create a new role for the realm or client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmRolesPost(RoleRepresentation body, string realm);

    /// <summary>
    ///     Create a new role for the realm or client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmRolesPostWithHttpInfo(RoleRepresentation body, string realm);

    /// <summary>
    ///     Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <param name="clientUuid"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmRolesRoleNameCompositesClientsClientUuidGet(string realm, string roleName,
        string clientUuid);

    /// <summary>
    ///     Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <param name="clientUuid"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmRolesRoleNameCompositesClientsClientUuidGetWithHttpInfo(
        string realm, string roleName, string clientUuid);

    /// <summary>
    ///     Remove roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">roles to remove</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns></returns>
    void RealmRolesRoleNameCompositesDelete(List<RoleRepresentation> body, string realm, string roleName);

    /// <summary>
    ///     Remove roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">roles to remove</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmRolesRoleNameCompositesDeleteWithHttpInfo(List<RoleRepresentation> body, string realm,
        string roleName);

    /// <summary>
    ///     Get composites of the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmRolesRoleNameCompositesGet(string realm, string roleName);

    /// <summary>
    ///     Get composites of the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmRolesRoleNameCompositesGetWithHttpInfo(string realm,
        string roleName);

    /// <summary>
    ///     Add a composite to the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns></returns>
    void RealmRolesRoleNameCompositesPost(List<RoleRepresentation> body, string realm, string roleName);

    /// <summary>
    ///     Add a composite to the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmRolesRoleNameCompositesPostWithHttpInfo(List<RoleRepresentation> body, string realm,
        string roleName);

    /// <summary>
    ///     Get realm-level roles of the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmRolesRoleNameCompositesRealmGet(string realm, string roleName);

    /// <summary>
    ///     Get realm-level roles of the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmRolesRoleNameCompositesRealmGetWithHttpInfo(string realm,
        string roleName);

    /// <summary>
    ///     Delete a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns></returns>
    void RealmRolesRoleNameDelete(string realm, string roleName);

    /// <summary>
    ///     Delete a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmRolesRoleNameDeleteWithHttpInfo(string realm, string roleName);

    /// <summary>
    ///     Get a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>RoleRepresentation</returns>
    RoleRepresentation RealmRolesRoleNameGet(string realm, string roleName);

    /// <summary>
    ///     Get a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>ApiResponse of RoleRepresentation</returns>
    ApiResponse<RoleRepresentation> RealmRolesRoleNameGetWithHttpInfo(string realm, string roleName);

    /// <summary>
    ///     Returns a stream of groups that have the specified role name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="briefRepresentation">
    ///     if false, return a full representation of the {@code GroupRepresentation} objects.
    ///     (optional)
    /// </param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmRolesRoleNameGroupsGet(string realm, string roleName,
        bool? briefRepresentation = null, int? first = null, int? max = null);

    /// <summary>
    ///     Returns a stream of groups that have the specified role name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="briefRepresentation">
    ///     if false, return a full representation of the {@code GroupRepresentation} objects.
    ///     (optional)
    /// </param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmRolesRoleNameGroupsGetWithHttpInfo(string realm, string roleName,
        bool? briefRepresentation = null, int? first = null, int? max = null);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName"></param>
    /// <returns>ManagementPermissionReference</returns>
    ManagementPermissionReference RealmRolesRoleNameManagementPermissionsGet(string realm, string roleName);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName"></param>
    /// <returns>ApiResponse of ManagementPermissionReference</returns>
    ApiResponse<ManagementPermissionReference> RealmRolesRoleNameManagementPermissionsGetWithHttpInfo(string realm,
        string roleName);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName"></param>
    /// <returns>ManagementPermissionReference</returns>
    ManagementPermissionReference RealmRolesRoleNameManagementPermissionsPut(ManagementPermissionReference body,
        string realm, string roleName);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName"></param>
    /// <returns>ApiResponse of ManagementPermissionReference</returns>
    ApiResponse<ManagementPermissionReference> RealmRolesRoleNameManagementPermissionsPutWithHttpInfo(
        ManagementPermissionReference body, string realm, string roleName);

    /// <summary>
    ///     Update a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns></returns>
    void RealmRolesRoleNamePut(RoleRepresentation body, string realm, string roleName);

    /// <summary>
    ///     Update a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmRolesRoleNamePutWithHttpInfo(RoleRepresentation body, string realm, string roleName);

    /// <summary>
    ///     Returns a stream of users that have the specified role name.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmRolesRoleNameUsersGet(string realm, string roleName, int? first = null,
        int? max = null);

    /// <summary>
    ///     Returns a stream of users that have the specified role name.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmRolesRoleNameUsersGetWithHttpInfo(string realm, string roleName,
        int? first = null, int? max = null);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Get all roles for the realm or client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdRolesGetAsync(string realm, string id,
        bool? briefRepresentation = null, int? first = null, int? max = null, string search = null);

    /// <summary>
    ///     Get all roles for the realm or client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsIdRolesGetAsyncWithHttpInfo(string realm, string id,
        bool? briefRepresentation = null, int? first = null, int? max = null, string search = null);

    /// <summary>
    ///     Create a new role for the realm or client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdRolesPostAsync(RoleRepresentation body, string realm, string id);

    /// <summary>
    ///     Create a new role for the realm or client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>>
        RealmClientsIdRolesPostAsyncWithHttpInfo(RoleRepresentation body, string realm, string id);

    /// <summary>
    ///     Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <param name="clientUuid"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdRolesRoleNameCompositesClientsClientUuidGetAsync(string realm,
        string id, string roleName, string clientUuid);

    /// <summary>
    ///     Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <param name="clientUuid"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmClientsIdRolesRoleNameCompositesClientsClientUuidGetAsyncWithHttpInfo(string realm, string id,
            string roleName, string clientUuid);

    /// <summary>
    ///     Remove roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">roles to remove</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdRolesRoleNameCompositesDeleteAsync(List<RoleRepresentation> body, string realm, string id,
        string roleName);

    /// <summary>
    ///     Remove roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">roles to remove</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdRolesRoleNameCompositesDeleteAsyncWithHttpInfo(
        List<RoleRepresentation> body, string realm, string id, string roleName);

    /// <summary>
    ///     Get composites of the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdRolesRoleNameCompositesGetAsync(string realm, string id,
        string roleName);

    /// <summary>
    ///     Get composites of the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsIdRolesRoleNameCompositesGetAsyncWithHttpInfo(
        string realm, string id, string roleName);

    /// <summary>
    ///     Add a composite to the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdRolesRoleNameCompositesPostAsync(List<RoleRepresentation> body, string realm, string id,
        string roleName);

    /// <summary>
    ///     Add a composite to the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdRolesRoleNameCompositesPostAsyncWithHttpInfo(List<RoleRepresentation> body,
        string realm, string id, string roleName);

    /// <summary>
    ///     Get realm-level roles of the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdRolesRoleNameCompositesRealmGetAsync(string realm, string id,
        string roleName);

    /// <summary>
    ///     Get realm-level roles of the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsIdRolesRoleNameCompositesRealmGetAsyncWithHttpInfo(
        string realm, string id, string roleName);

    /// <summary>
    ///     Delete a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdRolesRoleNameDeleteAsync(string realm, string id, string roleName);

    /// <summary>
    ///     Delete a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdRolesRoleNameDeleteAsyncWithHttpInfo(string realm, string id,
        string roleName);

    /// <summary>
    ///     Get a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of RoleRepresentation</returns>
    Task<RoleRepresentation> RealmClientsIdRolesRoleNameGetAsync(string realm, string id, string roleName);

    /// <summary>
    ///     Get a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of ApiResponse (RoleRepresentation)</returns>
    Task<ApiResponse<RoleRepresentation>> RealmClientsIdRolesRoleNameGetAsyncWithHttpInfo(string realm, string id,
        string roleName);

    /// <summary>
    ///     Returns a stream of groups that have the specified role name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="briefRepresentation">
    ///     if false, return a full representation of the {@code GroupRepresentation} objects.
    ///     (optional)
    /// </param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdRolesRoleNameGroupsGetAsync(string realm, string id,
        string roleName, bool? briefRepresentation = null, int? first = null, int? max = null);

    /// <summary>
    ///     Returns a stream of groups that have the specified role name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="briefRepresentation">
    ///     if false, return a full representation of the {@code GroupRepresentation} objects.
    ///     (optional)
    /// </param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsIdRolesRoleNameGroupsGetAsyncWithHttpInfo(
        string realm, string id, string roleName, bool? briefRepresentation = null, int? first = null, int? max = null);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName"></param>
    /// <returns>Task of ManagementPermissionReference</returns>
    Task<ManagementPermissionReference> RealmClientsIdRolesRoleNameManagementPermissionsGetAsync(string realm,
        string id, string roleName);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName"></param>
    /// <returns>Task of ApiResponse (ManagementPermissionReference)</returns>
    Task<ApiResponse<ManagementPermissionReference>>
        RealmClientsIdRolesRoleNameManagementPermissionsGetAsyncWithHttpInfo(string realm, string id, string roleName);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName"></param>
    /// <returns>Task of ManagementPermissionReference</returns>
    Task<ManagementPermissionReference> RealmClientsIdRolesRoleNameManagementPermissionsPutAsync(
        ManagementPermissionReference body, string realm, string id, string roleName);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName"></param>
    /// <returns>Task of ApiResponse (ManagementPermissionReference)</returns>
    Task<ApiResponse<ManagementPermissionReference>>
        RealmClientsIdRolesRoleNameManagementPermissionsPutAsyncWithHttpInfo(ManagementPermissionReference body,
            string realm, string id, string roleName);

    /// <summary>
    ///     Update a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdRolesRoleNamePutAsync(RoleRepresentation body, string realm, string id, string roleName);

    /// <summary>
    ///     Update a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdRolesRoleNamePutAsyncWithHttpInfo(RoleRepresentation body, string realm,
        string id, string roleName);

    /// <summary>
    ///     Returns a stream of users that have the specified role name.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdRolesRoleNameUsersGetAsync(string realm, string id,
        string roleName, int? first = null, int? max = null);

    /// <summary>
    ///     Returns a stream of users that have the specified role name.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsIdRolesRoleNameUsersGetAsyncWithHttpInfo(
        string realm, string id, string roleName, int? first = null, int? max = null);

    /// <summary>
    ///     Get all roles for the realm or client
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
    Task<List<Dictionary<string, object>>> RealmRolesGetAsync(string realm, bool? briefRepresentation = null,
        int? first = null, int? max = null, string search = null);

    /// <summary>
    ///     Get all roles for the realm or client
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
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmRolesGetAsyncWithHttpInfo(string realm,
        bool? briefRepresentation = null, int? first = null, int? max = null, string search = null);

    /// <summary>
    ///     Create a new role for the realm or client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmRolesPostAsync(RoleRepresentation body, string realm);

    /// <summary>
    ///     Create a new role for the realm or client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmRolesPostAsyncWithHttpInfo(RoleRepresentation body, string realm);

    /// <summary>
    ///     Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <param name="clientUuid"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmRolesRoleNameCompositesClientsClientUuidGetAsync(string realm,
        string roleName, string clientUuid);

    /// <summary>
    ///     Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <param name="clientUuid"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmRolesRoleNameCompositesClientsClientUuidGetAsyncWithHttpInfo(string realm, string roleName,
            string clientUuid);

    /// <summary>
    ///     Remove roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">roles to remove</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmRolesRoleNameCompositesDeleteAsync(List<RoleRepresentation> body, string realm, string roleName);

    /// <summary>
    ///     Remove roles from the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">roles to remove</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmRolesRoleNameCompositesDeleteAsyncWithHttpInfo(List<RoleRepresentation> body,
        string realm, string roleName);

    /// <summary>
    ///     Get composites of the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmRolesRoleNameCompositesGetAsync(string realm, string roleName);

    /// <summary>
    ///     Get composites of the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmRolesRoleNameCompositesGetAsyncWithHttpInfo(string realm,
        string roleName);

    /// <summary>
    ///     Add a composite to the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmRolesRoleNameCompositesPostAsync(List<RoleRepresentation> body, string realm, string roleName);

    /// <summary>
    ///     Add a composite to the role
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmRolesRoleNameCompositesPostAsyncWithHttpInfo(List<RoleRepresentation> body,
        string realm, string roleName);

    /// <summary>
    ///     Get realm-level roles of the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmRolesRoleNameCompositesRealmGetAsync(string realm, string roleName);

    /// <summary>
    ///     Get realm-level roles of the role’s composite
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmRolesRoleNameCompositesRealmGetAsyncWithHttpInfo(
        string realm, string roleName);

    /// <summary>
    ///     Delete a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmRolesRoleNameDeleteAsync(string realm, string roleName);

    /// <summary>
    ///     Delete a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmRolesRoleNameDeleteAsyncWithHttpInfo(string realm, string roleName);

    /// <summary>
    ///     Get a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of RoleRepresentation</returns>
    Task<RoleRepresentation> RealmRolesRoleNameGetAsync(string realm, string roleName);

    /// <summary>
    ///     Get a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of ApiResponse (RoleRepresentation)</returns>
    Task<ApiResponse<RoleRepresentation>> RealmRolesRoleNameGetAsyncWithHttpInfo(string realm, string roleName);

    /// <summary>
    ///     Returns a stream of groups that have the specified role name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="briefRepresentation">
    ///     if false, return a full representation of the {@code GroupRepresentation} objects.
    ///     (optional)
    /// </param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmRolesRoleNameGroupsGetAsync(string realm, string roleName,
        bool? briefRepresentation = null, int? first = null, int? max = null);

    /// <summary>
    ///     Returns a stream of groups that have the specified role name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="briefRepresentation">
    ///     if false, return a full representation of the {@code GroupRepresentation} objects.
    ///     (optional)
    /// </param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmRolesRoleNameGroupsGetAsyncWithHttpInfo(string realm,
        string roleName, bool? briefRepresentation = null, int? first = null, int? max = null);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName"></param>
    /// <returns>Task of ManagementPermissionReference</returns>
    Task<ManagementPermissionReference> RealmRolesRoleNameManagementPermissionsGetAsync(string realm, string roleName);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName"></param>
    /// <returns>Task of ApiResponse (ManagementPermissionReference)</returns>
    Task<ApiResponse<ManagementPermissionReference>> RealmRolesRoleNameManagementPermissionsGetAsyncWithHttpInfo(
        string realm, string roleName);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName"></param>
    /// <returns>Task of ManagementPermissionReference</returns>
    Task<ManagementPermissionReference> RealmRolesRoleNameManagementPermissionsPutAsync(
        ManagementPermissionReference body, string realm, string roleName);

    /// <summary>
    ///     Return object stating whether role Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName"></param>
    /// <returns>Task of ApiResponse (ManagementPermissionReference)</returns>
    Task<ApiResponse<ManagementPermissionReference>> RealmRolesRoleNameManagementPermissionsPutAsyncWithHttpInfo(
        ManagementPermissionReference body, string realm, string roleName);

    /// <summary>
    ///     Update a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmRolesRoleNamePutAsync(RoleRepresentation body, string realm, string roleName);

    /// <summary>
    ///     Update a role by name
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role’s name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmRolesRoleNamePutAsyncWithHttpInfo(RoleRepresentation body, string realm,
        string roleName);

    /// <summary>
    ///     Returns a stream of users that have the specified role name.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmRolesRoleNameUsersGetAsync(string realm, string roleName,
        int? first = null, int? max = null);

    /// <summary>
    ///     Returns a stream of users that have the specified role name.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">the role name.</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmRolesRoleNameUsersGetAsyncWithHttpInfo(string realm,
        string roleName, int? first = null, int? max = null);

    #endregion Asynchronous Operations
}