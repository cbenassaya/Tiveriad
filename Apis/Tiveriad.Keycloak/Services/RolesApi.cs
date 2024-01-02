#region

using System.Net;
using Tiveriad.Commons.HttpApis;
using Tiveriad.Keycloak.Apis;
using Tiveriad.Keycloak.Models;

#endregion

namespace Tiveriad.Keycloak.Services;

public class RolesApi : BaseApi, IRolesApi
{
    public RolesApi(HttpClient httpClient, IKeycloakSessionFactory keycloakSessionFactory) : base(httpClient,
        keycloakSessionFactory)
    {
    }

    /// <summary>
    ///  Delete a role by name
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    public Task<ApiResponse<bool>> DeleteClientRole(string realm, string id, string roleName)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RolesApi->DeleteClientRole");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400, "Missing required parameter 'id' when calling RolesApi->DeleteClientRole");
        // verify the required parameter 'roleName' is set
        if (roleName == null)
            throw new ApiException(400, "Missing required parameter 'roleName' when calling RolesApi->DeleteClientRole");
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.DeleteAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/clients/{id}/roles/{roleName}");
            });
            return new ApiResponse<bool>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                result.IsSuccessStatusCode &&  result.StatusCode == HttpStatusCode.NoContent);
        });
    }



    /// <summary>
    ///  Remove roles from the role’s composite
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <param name="body">RoleRepresentation (optional)</param>
    /// <returns></returns>
    public Task<ApiResponse<bool>> DeleteClientRoleComposites(string realm, string id, string roleName, RoleRepresentation? body = null)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RolesApi->DeleteClientRoleComposites");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400, "Missing required parameter 'id' when calling RolesApi->DeleteClientRoleComposites");
        // verify the required parameter 'roleName' is set
        if (roleName == null)
            throw new ApiException(400, "Missing required parameter 'roleName' when calling RolesApi->DeleteClientRoleComposites");
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.DeleteAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .Content(body)
                    .AppendPath($"/{realm}/clients/{id}/roles/{roleName}/composites");
            });
            return new ApiResponse<bool>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                result.IsSuccessStatusCode &&  result.StatusCode == HttpStatusCode.NoContent);
        });
    }
    
    
    /// <summary>
    ///  Delete a role by name
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <returns></returns>
    public Task<ApiResponse<bool>> DeleteRoleByRealmByRoleName(string realm, string roleName)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RolesApi->DeleteRoleByRealmByRoleName");
        // verify the required parameter 'roleName' is set
        if (roleName == null)
            throw new ApiException(400, "Missing required parameter 'roleName' when calling RolesApi->DeleteRoleByRealmByRoleName");

        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.DeleteAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/roles/{roleName}");
            });
            return new ApiResponse<bool>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                result.IsSuccessStatusCode &&  result.StatusCode == HttpStatusCode.NoContent);
        });
    }
    
    /// <summary>
    ///  Remove roles from the role’s composite
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <param name="body">RoleRepresentation (optional)</param>
    /// <returns></returns>
    public Task<ApiResponse<bool>> DeleteRoleCompositesByRealmByRoleName (string realm, string roleName, RoleRepresentation? body = null)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RolesApi->DeleteRoleCompositesByRealmByRoleName");
        // verify the required parameter 'roleName' is set
        if (roleName == null)
            throw new ApiException(400, "Missing required parameter 'roleName' when calling RolesApi->DeleteRoleCompositesByRealmByRoleName");
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.DeleteAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .Content(body)
                    .AppendPath($"/{realm}/roles/{roleName}/composites");
            });
            return new ApiResponse<bool>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                result.IsSuccessStatusCode &&  result.StatusCode == HttpStatusCode.NoContent);
        });
    }

    /// <summary>
    ///  Get a role by name
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <returns>ApiResponse of RoleRepresentation</returns>
    public Task<ApiResponse<RoleRepresentation>> GetClientRole(string realm, string id, string roleName)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RolesApi->GetClientRole");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400, "Missing required parameter 'id' when calling RolesApi->GetClientRole");
        // verify the required parameter 'roleName' is set
        if (roleName == null)
            throw new ApiException(400, "Missing required parameter 'roleName' when calling RolesApi->GetClientRole");
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.GetAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/clients/{id}/roles/{roleName}");
            });
            return new ApiResponse<RoleRepresentation>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<RoleRepresentation>().ConfigureAwait(false));
        });
    }
    
    
    /// <summary>
    ///  Get composites of the role
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <returns>Object</returns>
    public Object GetClientRoleComposites (string realm, string id, string roleName)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RolesApi->GetClientRole");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400, "Missing required parameter 'id' when calling RolesApi->GetClientRole");
        // verify the required parameter 'roleName' is set
        if (roleName == null)
            throw new ApiException(400, "Missing required parameter 'roleName' when calling RolesApi->GetClientRole");
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.GetAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/clients/{id}/roles/{roleName}/composites");
            });
            return new ApiResponse<RoleRepresentation>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<RoleRepresentation>().ConfigureAwait(false));
        });
    }

    /// <summary>
    ///  Get client-level roles for the client that are in the role’s composite
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <param name="clientUuid"></param>
    /// <returns>ApiResponse of Object</returns>
    public Task<ApiResponse<RoleRepresentation>> GetClientRoleCompositesClient(string realm, string id, string roleName,
        string clientUuid)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling RolesApi->GetClientRoleCompositesClient");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400,
                "Missing required parameter 'id' when calling RolesApi->GetClientRoleCompositesClient");
        // verify the required parameter 'roleName' is set
        if (roleName == null)
            throw new ApiException(400,
                "Missing required parameter 'roleName' when calling RolesApi->GetClientRoleCompositesClient");
        // verify the required parameter 'clientUuid' is set
        if (clientUuid == null)
            throw new ApiException(400,
                "Missing required parameter 'clientUuid' when calling RolesApi->GetClientRoleCompositesClient");
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.GetAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/clients/{id}/roles/{roleName}/composites/clients/{clientUuid}");
            });
            return new ApiResponse<RoleRepresentation>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<RoleRepresentation>().ConfigureAwait(false));
        });
    }

    /// <summary>
    ///  Get realm-level roles of the role’s composite
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <returns>ApiResponse of Object</returns>
    public Task<ApiResponse<RoleRepresentation>> GetClientRoleCompositesRealm(string realm, string id, string roleName)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RolesApi->GetClientRoleCompositesRealm");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400, "Missing required parameter 'id' when calling RolesApi->GetClientRoleCompositesRealm");
        // verify the required parameter 'roleName' is set
        if (roleName == null)
            throw new ApiException(400, "Missing required parameter 'roleName' when calling RolesApi->GetClientRoleCompositesRealm");
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.GetAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/clients/{id}/roles/{roleName}/composites/clients");
            });
            return new ApiResponse<RoleRepresentation>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<RoleRepresentation>().ConfigureAwait(false));
        });
    }

    /// <summary>
    ///  Returns a stream of groups that have the specified role name
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">the role name.</param>
    /// <param name="briefRepresentation">if false, return a full representation of the {@code GroupRepresentation} objects. (optional)</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>ApiResponse of Object</returns>
    public Task<ApiResponse<List<GroupRepresentation>>> GetClientRoleGroups(string realm, string id, string roleName,
        bool briefRepresentation = true,  int? first = null,  int? max =  null)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling RolesApi->GetClientRoleGroups");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400, "Missing required parameter 'id' when calling RolesApi->GetClientRoleGroups");
        // verify the required parameter 'roleName' is set
        if (roleName == null)
            throw new ApiException(400,
                "Missing required parameter 'roleName' when calling RolesApi->GetClientRoleGroups");
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.GetAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .QueryString("briefRepresentation", briefRepresentation)
                    .QueryString( "first", first)
                    .QueryString( "max", max)
                    .AppendPath($"/{realm}/clients/{id}/roles/{roleName}/groups");
            });
            return new ApiResponse<List<GroupRepresentation>>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<List<GroupRepresentation>>().ConfigureAwait(false));
        });
    }


    /// <summary>
    ///  Returns a stream of users that have the specified role name.
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">the role name.</param>
    /// <param name="first">first result to return. Ignored if negative or {@code null}. (optional)</param>
    /// <param name="max">maximum number of results to return. Ignored if negative or {@code null}. (optional)</param>
    /// <returns>ApiResponse of Object</returns>
    public Task<ApiResponse<List<UserRepresentation>>> GetClientRoleUsers(string realm, string id, string roleName,  int? first = null, int? max = null)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RolesApi->GetClientRoleUsers");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400, "Missing required parameter 'id' when calling RolesApi->GetClientRoleUsers");
        // verify the required parameter 'roleName' is set
        if (roleName == null)
            throw new ApiException(400,
                "Missing required parameter 'roleName' when calling RolesApi->GetClientRoleUsers");
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.GetAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .QueryString( "first", first)
                    .QueryString( "max", max)
                    .AppendPath($"/{realm}/clients/{id}/roles/{roleName}/users");
            });
            return new ApiResponse<List<UserRepresentation>>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<List<UserRepresentation>>().ConfigureAwait(false));
        });
    }
    
    /// <summary>
    ///  Get all roles for the realm or client
    /// </summary>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>ApiResponse of Object</returns>
    public Task<ApiResponse<List<RoleRepresentation>>> GetClientRoles (string realm, string id, bool briefRepresentation = true, int? first = null, int? max = null, string search = "")
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RolesApi->GetClientRoleUsers");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400, "Missing required parameter 'id' when calling RolesApi->GetClientRoleUsers");

        
        return  Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result =  await apiClient.GetAsync(builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .QueryString( "first", first)
                    .QueryString( "max", max)
                    .QueryStringIf(()=>!string.IsNullOrEmpty(search), "search", search)
                    .QueryString( "briefRepresentation", briefRepresentation)
                    .AppendPath($"/{realm}/clients/{id}/roles");
            });
            return new ApiResponse<List<RoleRepresentation>>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<List<RoleRepresentation>>().ConfigureAwait(false));
        });
    }

    /// <summary>
    ///  Add a composite to the role
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <param name="body">RoleRepresentation</param>
    /// <returns>ApiResponse of Object(void)</returns>
    public Task<ApiResponse<bool>> PostClientRoleComposites(string realm, string id, string roleName,
        RoleRepresentation body)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling RolesApi->PostClientRoleComposites");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400,
                "Missing required parameter 'id' when calling RolesApi->PostClientRoleComposites");
        // verify the required parameter 'roleName' is set
        if (roleName == null)
            throw new ApiException(400,
                "Missing required parameter 'roleName' when calling RolesApi->PostClientRoleComposites");
        if (body == null)
            throw new ApiException(400,
                "Missing required parameter 'body' when calling RolesApi->PostClientRoleComposites");
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.PostAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .Content(body)
                    .AppendPath($"/{realm}/clients/{id}/roles/{roleName}/composites");
            });
            return new ApiResponse<bool>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                result.IsSuccessStatusCode &&  result.StatusCode == HttpStatusCode.Created);
        });
    }

    /// <summary>
    ///  Create a new role for the realm or client
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="body">RoleRepresentation</param>
    /// <returns>ApiResponse of Object(void)</returns>
    public Task<ApiResponse<bool>> PostClientRole(string realm, string id, RoleRepresentation body )
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RolesApi->PostClientRoles");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400, "Missing required parameter 'id' when calling RolesApi->PostClientRoles");
        if (body == null)
            throw new ApiException(400,
                "Missing required parameter 'body' when calling RolesApi->PostClientRoles");
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.PostAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .Content(body)
                    .AppendPath($"/{realm}/clients/{id}/roles");
            });
            return new ApiResponse<bool>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                result.IsSuccessStatusCode &&  result.StatusCode == HttpStatusCode.Created);
        });
    }
    
    
    /// <summary>
    ///  Add a composite to the role
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <param name="body">RoleRepresentation</param>
    /// <returns></returns>
    public Task<ApiResponse<bool>> PostRoleCompositeByRealmByRoleName (string realm, string roleName, RoleRepresentation body)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RolesApi->PostRoleCompositesByRealmByRoleName");
        // verify the required parameter 'roleName' is set
        if (roleName == null)
            throw new ApiException(400, "Missing required parameter 'roleName' when calling RolesApi->PostRoleCompositesByRealmByRoleName");
        if (body == null)
            throw new ApiException(400,
                "Missing required parameter 'body' when calling RolesApi->PostRoleCompositesByRealmByRoleName");
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.PostAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .Content(body)
                    .AppendPath($"/{realm}/roles/{roleName}/composites");
            });
            return new ApiResponse<bool>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                result.IsSuccessStatusCode &&  result.StatusCode == HttpStatusCode.Created);
        });
    }
    
    
    
    /// <summary>
    ///  Create a new role for the realm or client
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="body">RoleRepresentation (optional)</param>
    /// <returns></returns>
    public Task<ApiResponse<bool>> PostRoleByRealm (string realm, RoleRepresentation body )
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RolesApi->PostRolesByRealm");
        // verify the required parameter 'body' is set
        if (body == null)
            throw new ApiException(400, "Missing required parameter 'body' when calling RolesApi->PostRolesByRealm");
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.PostAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .Content(body)
                    .AppendPath($"/{realm}/roles");
            });
            return new ApiResponse<bool>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                result.IsSuccessStatusCode &&  result.StatusCode == HttpStatusCode.Created);
        });
        
    }
    
    
    /// <summary>
    ///  Update a role by name
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <param name="body">RoleRepresentation (optional)</param>
    /// <returns></returns>
    public Task<ApiResponse<bool>>  PutClientRole (string realm, string id, string roleName, RoleRepresentation body)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RolesApi->PutClientRole");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400, "Missing required parameter 'id' when calling RolesApi->PutClientRole");
        // verify the required parameter 'roleName' is set
        if (roleName == null)
            throw new ApiException(400, "Missing required parameter 'roleName' when calling RolesApi->PutClientRole");
        // verify the required parameter 'body' is set
        if (body == null)
            throw new ApiException(400, "Missing required parameter 'body' when calling RolesApi->PutClientRole");
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.PutAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .Content(body)
                    .AppendPath($"/{realm}/clients/{id}/roles/{roleName}");
            });
            return new ApiResponse<bool>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                result.IsSuccessStatusCode &&  result.StatusCode == HttpStatusCode.Created);
        });
    }


    /// <summary>
    ///  Update a role by name
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="roleName">role&#x27;s name (not id!)</param>
    /// <param name="body">RoleRepresentation (optional)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    public Task<ApiResponse<bool>>  PutRoleByRealmByRoleName(string realm, string roleName,
        RoleRepresentation body)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling RolesApi->PutRoleByRealmByRoleName");
        // verify the required parameter 'roleName' is set
        if (roleName == null)
            throw new ApiException(400,
                "Missing required parameter 'roleName' when calling RolesApi->PutRoleByRealmByRoleName");
        // verify the required parameter 'body' is set
        if (body == null)
            throw new ApiException(400,
                "Missing required parameter 'body' when calling RolesApi->PutRoleByRealmByRoleName");
        
        return   Execute(async (apiClient, token) =>
        {
            HttpResponseMessage result = await apiClient.PutAsync( builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .Content(body)
                    .AppendPath($"/{realm}/roles/{roleName}");
            });
            return new ApiResponse<bool>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                result.IsSuccessStatusCode &&  result.StatusCode == HttpStatusCode.Created);
        });
    }
}