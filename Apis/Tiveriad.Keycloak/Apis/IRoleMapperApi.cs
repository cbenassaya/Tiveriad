using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Apis;

public interface IRoleMapperApi
{
    /// <summary>
    /// Add realm-level role mappings to the user 
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Roles to add</param>
    /// <param name="realm">realm name (not userId!)</param>
    /// <param name="userId">User userId</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdRoleMappingsRealmPostAsyncWithHttpInfo(
        List<RoleRepresentation> body, string realm, string userId);

    /// <summary>
    /// Delete realm-level role mappings 
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not userId!)</param>
    /// <param name="userId">User userId</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdRoleMappingsRealmDeleteAsyncWithHttpInfo(
        List<RoleRepresentation> body, string realm, string userId);

    /// <summary>
    /// Get role mappings 
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not userId!)</param>
    /// <param name="userId">User userId</param>
    /// <returns>Task of ApiResponse (MappingsRepresentation)</returns>
    Task<ApiResponse<MappingsRepresentation>>
        RealmUsersIdRoleMappingsGetAsync(string realm, string userId);
}