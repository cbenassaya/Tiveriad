#region

using Tiveriad.Keycloak.Models;

#endregion

namespace Tiveriad.Keycloak.Apis;

public interface IRoleApi
{
    /// <summary>
    ///     Delete a role by name
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    Task<ApiResponse<bool>> DeleteClientRole(string realm, string id, string roleName);

    /// <summary>
    ///     Remove roles from the role’s composite
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <param name="body">RoleRepresentation (optional)</param>
    /// <returns></returns>
    Task<ApiResponse<bool>> DeleteClientRoleComposites(string realm, string id, string roleName,
        RoleRepresentation? body = null);

    /// <summary>
    ///     Delete a role by name
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <returns></returns>
    Task<ApiResponse<bool>> DeleteRoleByRealmByRoleName(string realm, string roleName);

    /// <summary>
    ///     Remove roles from the role’s composite
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <param name="body">RoleRepresentation (optional)</param>
    /// <returns></returns>
    Task<ApiResponse<bool>> DeleteRoleCompositesByRealmByRoleName(string realm, string roleName,
        RoleRepresentation? body = null);

    /// <summary>
    ///     Get a role by name
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <returns>ApiResponse of RoleRepresentation</returns>
    Task<ApiResponse<RoleRepresentation>> GetClientRole(string realm, string id, string roleName);

    /// <summary>
    ///     Get composites of the role
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <returns>Object</returns>
    object GetClientRoleComposites(string realm, string id, string roleName);

    /// <summary>
    ///     Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <param name="clientUuid"></param>
    /// <returns>ApiResponse of Object</returns>
    Task<ApiResponse<RoleRepresentation>> GetClientRoleCompositesClient(string realm, string id, string roleName,
        string clientUuid);

    /// <summary>
    ///     Get realm-level roles of the role’s composite
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <returns>ApiResponse of Object</returns>
    Task<ApiResponse<RoleRepresentation>> GetClientRoleCompositesRealm(string realm, string id, string roleName);

    /// <summary>
    ///     Returns a stream of groups that have the specified role name
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">the role name.</param>
    /// <param name="briefRepresentation">
    ///     if false, return a full representation of the {@code GroupRepresentation} objects.
    ///     (optional)
    /// </param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>ApiResponse of Object</returns>
    Task<ApiResponse<List<GroupRepresentation>>> GetClientRoleGroups(string realm, string id, string roleName,
        bool briefRepresentation = true, int? first = null, int? max = null);

    /// <summary>
    ///     Returns a stream of users that have the specified role name.
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">the role name.</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>ApiResponse of Object</returns>
    Task<ApiResponse<List<UserRepresentation>>> GetClientRoleUsers(string realm, string id, string roleName,
        int? first = null, int? max = null);

    /// <summary>
    ///     Get all roles for the realm or client
    /// </summary>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>ApiResponse of Object</returns>
    Task<ApiResponse<List<RoleRepresentation>>> GetClientRoles(string realm, string id, bool briefRepresentation = true,
        int? first = null, int? max = null, string search = "");

    /// <summary>
    ///     Add a composite to the role
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <param name="body">RoleRepresentation</param>
    /// <returns>ApiResponse of Object(void)</returns>
    Task<ApiResponse<bool>> PostClientRoleComposites(string realm, string id, string roleName,
        RoleRepresentation body);

    /// <summary>
    ///     Create a new role for the realm or client
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="body">RoleRepresentation</param>
    /// <returns>ApiResponse of Object(void)</returns>
    Task<ApiResponse<bool>> PostClientRole(string realm, string id, RoleRepresentation body);

    /// <summary>
    ///     Add a composite to the role
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <param name="body">RoleRepresentation</param>
    /// <returns></returns>
    Task<ApiResponse<bool>> PostRoleCompositeByRealmByRoleName(string realm, string roleName, RoleRepresentation body);

    /// <summary>
    ///     Create a new role for the realm or client
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="body">RoleRepresentation (optional)</param>
    /// <returns></returns>
    Task<ApiResponse<bool>> PostRoleByRealm(string realm, RoleRepresentation body);

    /// <summary>
    ///     Update a role by name
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <param name="body">RoleRepresentation (optional)</param>
    /// <returns></returns>
    Task<ApiResponse<bool>> PutClientRole(string realm, string id, string roleName, RoleRepresentation body);

    /// <summary>
    ///     Update a role by name
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <param name="body">RoleRepresentation (optional)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    Task<ApiResponse<bool>> PutRoleByRealmByRoleName(string realm, string roleName,
        RoleRepresentation body);
}