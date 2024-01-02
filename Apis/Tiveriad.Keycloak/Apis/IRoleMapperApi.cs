using Tiveriad.Commons.HttpApis;
using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Apis;

public interface IRoleMapperApi
{
    /// <summary>
    ///  Delete realm-level role mappings
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="body">RoleRepresentation (optional)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    Task<ApiResponse<bool>> DeleteGroupRoleMappingsRealm(string realm, string id, RoleRepresentation? body = null);

    /// <summary>
    ///  Delete realm-level role mappings
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="body">RoleRepresentation (optional)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<bool>> DeleteUserRoleMappings(
        string realm, string id, RoleRepresentation body = null);

    /// <summary>
    ///  Get role mappings
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse (MappingsRepresentation)</returns>
    Task<ApiResponse<MappingsRepresentation>> GetGroupRoleMappings(string realm, string id);

    /// <summary>
    ///  Get realm-level role mappings
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of Object</returns>
    Task<ApiResponse<List<object>>> GetGroupRoleMappingsRealm (string realm, string id);

    /// <summary>
    ///  Get realm-level roles that can be mapped
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Object</returns>
    Task<ApiResponse<List<object>>> GetGroupRoleMappingsRealmAvailable(string realm, string id);

    /// <summary>
    ///  Get effective realm-level role mappings This will recurse all composite roles to get the result.
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>ApiResponse of Object</returns>
    Task<ApiResponse<List<object>>>  GetGroupRoleMappingsRealmComposite(string realm, string id,
        bool briefRepresentation = true);

    /// <summary>
    ///  Get role mappings
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of MappingsRepresentation</returns>
    Task<ApiResponse<MappingsRepresentation>> GetUserRoleMappings(string realm, string id);

    /// <summary>
    ///  Get realm-level role mappings
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of Object</returns>
    Task<ApiResponse<List<object>>> GetUserRoleMappingsRealm (string realm, string id);

    /// <summary>
    ///  Get realm-level roles that can be mapped
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Object</returns>
    Task<ApiResponse<List<object>>> GetUserRoleMappingsRealmAvailable(string realm, string id);

    /// <summary>
    ///  Get effective realm-level role mappings This will recurse all composite roles to get the result.
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>ApiResponse of Object</returns>
    Task<ApiResponse<List<object>>>  GetUserRoleMappingsRealmComposite(string realm, string id,
        bool briefRepresentation = true);

}