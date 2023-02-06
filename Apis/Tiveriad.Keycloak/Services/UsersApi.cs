using Tiveriad.Commons.HttpApis;
using Tiveriad.Keycloak.Apis;
using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Services;

public class UsersApi:BaseApi, IUsersApi
{
    
    public UsersApi(HttpClient httpClient, IKeycloakSessionFactory keycloakSessionFactory) : base(httpClient, keycloakSessionFactory)
    {
    }

    /// <summary>
    /// Get representation of the user 
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not userId!)</param>
    /// <param name="userId">User userId</param>
    /// <returns>Task of ApiResponse (UserRepresentation)</returns>
    public async Task<ApiResponse<UserRepresentation>> RealmUsersIdGetAsyncWithHttpInfo(string realm, string userId)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling UsersApi->RealmUsersIdGet");
        // verify the required parameter 'userId' is set
        if (userId == null)
            throw new ApiException(400, "Missing required parameter 'userId' when calling UsersApi->RealmUsersIdGet");


        return await Execute<UserRepresentation>(async (apiClient, token) =>
        {
            HttpResponseMessage result = null;
            result = await apiClient.GetAsync(builder =>
            {
                builder
                    .Header(h=>h.Authorization("Bearer",token))
                    .AppendPath($"/{realm}/users/{userId}");
            });


            return new ApiResponse<UserRepresentation>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<UserRepresentation>().ConfigureAwait(false));
        });




    }

    /// <summary>
    /// Update the user 
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not userId!)</param>
    /// <param name="userId">User userId</param>
    /// <returns>Task of ApiResponse</returns>
    public async Task<ApiResponse<object>> RealmUsersIdPutAsyncWithHttpInfo(
        UserRepresentation body, string realm, string userId)
    {
        // verify the required parameter 'body' is set
        if (body == null)
            throw new ApiException(400, "Missing required parameter 'body' when calling UsersApi->RealmUsersIdPut");
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling UsersApi->RealmUsersIdPut");
        // verify the required parameter 'userId' is set
        if (userId == null)
            throw new ApiException(400, "Missing required parameter 'userId' when calling UsersApi->RealmUsersIdPut");
        
        
        return await Execute<object>(async (apiClient, token) =>
        {
            HttpResponseMessage result = null;
            result = await apiClient.PutAsync(builder =>
            {
                builder
                    .Header(h=>h.Authorization("Bearer",token))
                    .AppendPath($"/{realm}/users/{userId}")
                    .Content(body);
            });
            return new ApiResponse<object>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                null);
        });
        

    }


}