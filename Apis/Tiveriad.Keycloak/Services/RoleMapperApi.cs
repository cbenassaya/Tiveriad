#region

using System.Net;
using Tiveriad.Commons.HttpApis;
using Tiveriad.Keycloak.Apis;
using Tiveriad.Keycloak.Models;

#endregion

namespace Tiveriad.Keycloak.Services;

public class RoleMapperApi : BaseApi, IRoleMapperApi
{
    public RoleMapperApi(HttpClient httpClient, IKeycloakSessionFactory keycloakSessionFactory) : base(httpClient,
        keycloakSessionFactory)
    {
    }


    /// <summary>
    ///  Delete realm-level role mappings
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="body">RoleRepresentation (optional)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    public Task<ApiResponse<bool>> DeleteGroupRoleMappingsRealm(string realm, string id, RoleRepresentation? body = null)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling RoleMapperApi->DeleteGroupRoleMappingsRealm");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400,
                "Missing required parameter 'id' when calling RoleMapperApi->DeleteGroupRoleMappingsRealm");
        
        return  Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.PostAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .Content(body)
                    .AppendPath($"/{realm}/groups/{id}/role-mappings/realm");
            });
            return new ApiResponse<bool>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                result.IsSuccessStatusCode &&  result.StatusCode == HttpStatusCode.Created);
        });
    }

    /// <summary>
    ///  Delete realm-level role mappings
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="body">RoleRepresentation (optional)</param>
    /// <returns>Task of ApiResponse</returns>
    public Task<ApiResponse<bool>> DeleteUserRoleMappings(
        string realm, string id, RoleRepresentation body = null)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling RoleMapperApi->DeleteUserRoleMappingsRealm");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400,
                "Missing required parameter 'id' when calling RoleMapperApi->DeleteUserRoleMappingsRealm");
        
        return  Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.PostAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .Content(body)
                    .AppendPath($"/{realm}/users/{id}/role-mappings/realm");
            });
            return new ApiResponse<bool>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                result.IsSuccessStatusCode &&  result.StatusCode == HttpStatusCode.Created);
        });
    }

    /// <summary>
    ///  Get role mappings
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse (MappingsRepresentation)</returns>
    public Task<ApiResponse<MappingsRepresentation>> GetGroupRoleMappings(string realm, string id)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling RoleMapperApi->GetGroupRoleMappings");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400,
                "Missing required parameter 'id' when calling RoleMapperApi->GetGroupRoleMappings");
        
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.GetAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/groups/{id}/role-mappings");
            });
            return new ApiResponse<MappingsRepresentation>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<MappingsRepresentation>().ConfigureAwait(false));
        });
    }
    
    
    /// <summary>
    ///  Get realm-level role mappings
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of Object</returns>
    public Task<ApiResponse<List<object>>> GetGroupRoleMappingsRealm (string realm, string id)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling RoleMapperApi->GetGroupRoleMappings");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400,
                "Missing required parameter 'id' when calling RoleMapperApi->GetGroupRoleMappings");
        
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.GetAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/groups/{id}/role-mappings/realm");
            });
            return new ApiResponse<List<object>>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<List<object>>().ConfigureAwait(false));
        });

    }

    /// <summary>
    ///  Get realm-level roles that can be mapped
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Object</returns>
    public Task<ApiResponse<List<object>>> GetGroupRoleMappingsRealmAvailable(string realm, string id)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling RoleMapperApi->GetGroupRoleMappings");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400,
                "Missing required parameter 'id' when calling RoleMapperApi->GetGroupRoleMappings");
        
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.GetAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/groups/{id}/role-mappings/realm/available");
            });
            return new ApiResponse<List<object>>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<List<object>>().ConfigureAwait(false));
        });
    }

    /// <summary>
    ///  Get effective realm-level role mappings This will recurse all composite roles to get the result.
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>ApiResponse of Object</returns>
    public Task<ApiResponse<List<object>>>  GetGroupRoleMappingsRealmComposite(string realm, string id,
        bool briefRepresentation = true)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling RoleMapperApi->GetGroupRoleMappings");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400,
                "Missing required parameter 'id' when calling RoleMapperApi->GetGroupRoleMappings");
        
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.GetAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/groups/{id}/role-mappings/realm/composite")
                    .QueryString("briefRepresentation", briefRepresentation);
            });
            return new ApiResponse<List<object>>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<List<object>>().ConfigureAwait(false));
        });
    }

    /// <summary>
    ///  Get role mappings
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of MappingsRepresentation</returns>
    public Task<ApiResponse<MappingsRepresentation>> GetUserRoleMappings(string realm, string id)
    {
        
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RoleMapperApi->GetUserRoleMappings");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400, "Missing required parameter 'id' when calling RoleMapperApi->GetUserRoleMappings");

        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.GetAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/users/{id}/role-mappings");
            });
            return new ApiResponse<MappingsRepresentation>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<MappingsRepresentation>().ConfigureAwait(false));
        });
    }
    
    
        /// <summary>
    ///  Get realm-level role mappings
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of Object</returns>
    public Task<ApiResponse<List<object>>> GetUserRoleMappingsRealm (string realm, string id)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling RoleMapperApi->GetUserRoleMappings");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400,
                "Missing required parameter 'id' when calling RoleMapperApi->GetUserRoleMappings");
        
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.GetAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/users/{id}/role-mappings/realm");
            });
            return new ApiResponse<List<object>>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<List<object>>().ConfigureAwait(false));
        });

    }

    /// <summary>
    ///  Get realm-level roles that can be mapped
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Object</returns>
    public Task<ApiResponse<List<object>>> GetUserRoleMappingsRealmAvailable(string realm, string id)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling RoleMapperApi->GetUserRoleMappings");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400,
                "Missing required parameter 'id' when calling RoleMapperApi->GetUserRoleMappings");
        
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.GetAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/users/{id}/role-mappings/realm/available");
            });
            return new ApiResponse<List<object>>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<List<object>>().ConfigureAwait(false));
        });
    }

    /// <summary>
    ///  Get effective realm-level role mappings This will recurse all composite roles to get the result.
    /// </summary>
    /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="briefRepresentation">if false, return roles with their attributes (optional)</param>
    /// <returns>ApiResponse of Object</returns>
    public Task<ApiResponse<List<object>>>  GetUserRoleMappingsRealmComposite(string realm, string id,
        bool briefRepresentation = true)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling RoleMapperApi->GetUserRoleMappings");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400,
                "Missing required parameter 'id' when calling RoleMapperApi->GetUserRoleMappings");
        
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.GetAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/users/{id}/role-mappings/realm/composite")
                    .QueryString("briefRepresentation", briefRepresentation);
            });
            return new ApiResponse<List<object>>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<List<object>>().ConfigureAwait(false));
        });
    }


}