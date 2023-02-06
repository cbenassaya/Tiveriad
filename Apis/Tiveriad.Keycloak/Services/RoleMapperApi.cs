using Tiveriad.Commons.HttpApis;
using Tiveriad.Keycloak.Apis;
using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Services;

public class RoleMapperApi:BaseApi, IRoleMapperApi
{
    public RoleMapperApi(HttpClient httpClient, IKeycloakSessionFactory keycloakSessionFactory) : base(httpClient, keycloakSessionFactory)
    {
    }

    /// <summary>
    /// Add realm-level role mappings to the user 
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Roles to add</param>
    /// <param name="realm">realm name (not userId!)</param>
    /// <param name="userId">User userId</param>
    /// <returns>Task of ApiResponse</returns>
    public async Task<ApiResponse<object>> RealmUsersIdRoleMappingsRealmPostAsyncWithHttpInfo(
        List<RoleRepresentation> body, string realm, string userId)
    {
        // verify the required parameter 'body' is set
        if (body == null)
            throw new ApiException(400, "Missing required parameter 'body' when calling RoleMapperApi->RealmUsersIdRoleMappingsRealmPost");
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RoleMapperApi->RealmUsersIdRoleMappingsRealmPost");
        if (userId == null)
            throw new ApiException(400, "Missing required parameter 'userId' when calling RoleMapperApi->RealmUsersIdRoleMappingsRealmPost");

        return await Execute<object>(async (apiClient, token) =>
        {
            HttpResponseMessage result = null;
            result = await apiClient.PostAsync(builder =>
            {
                builder
                    .Header(h=>h.Authorization("Bearer",token))
                    .AppendPath($"/{realm}/users/{userId}/role-mappings/realm")
                    .Content(body);
            });

            return new ApiResponse<object>( (int) result.StatusCode, result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)), null);
        });

    }
    

    /// <summary>
    /// Delete realm-level role mappings 
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not userId!)</param>
    /// <param name="userId">User userId</param>
    /// <returns>Task of ApiResponse</returns>
    public async Task<ApiResponse<object>> RealmUsersIdRoleMappingsRealmDeleteAsyncWithHttpInfo(
        List<RoleRepresentation> body, string realm, string userId)
    {
        // verify the required parameter 'body' is set
        if (body == null)
            throw new ApiException(400,
                "Missing required parameter 'body' when calling RoleMapperApi->RealmUsersIdRoleMappingsRealmDelete");
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling RoleMapperApi->RealmUsersIdRoleMappingsRealmDelete");
        // verify the required parameter 'userId' is set
        if (userId == null)
            throw new ApiException(400,
                "Missing required parameter 'userId' when calling RoleMapperApi->RealmUsersIdRoleMappingsRealmDelete");
        
        
        return await Execute<object>(async (apiClient, token) =>
        {
            HttpResponseMessage result = null;
            result = await apiClient.PostAsync(builder =>
            {
                builder
                    .Header(h=>h.Authorization("Bearer",token))
                    .AppendPath($"/{realm}/users/{userId}/role-mappings/realm")
                    .Content(body);
            });
        
            return new ApiResponse<object>( (int) result.StatusCode, result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)), null);
        });

    }


    /// <summary>
    /// Get role mappings 
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not userId!)</param>
    /// <param name="userId">User userId</param>
    /// <returns>Task of ApiResponse (MappingsRepresentation)</returns>
    public async Task<ApiResponse<MappingsRepresentation>>
        RealmUsersIdRoleMappingsGetAsync(string realm, string userId)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RolesApi->RealmRolesGet");
        
        
        return await Execute<MappingsRepresentation>(async (apiClient, token) =>
        {
            HttpResponseMessage result = null;
            result = await apiClient.GetAsync(builder =>
            {
                builder
                    .Header(h=>h.Authorization("Bearer",token))
                    .AppendPath($"/{realm}/users/{userId}/role-mappings");
            });


            return new ApiResponse<MappingsRepresentation>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<MappingsRepresentation>().ConfigureAwait(false));
        });
    }
}