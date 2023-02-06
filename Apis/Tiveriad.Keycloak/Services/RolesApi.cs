using Tiveriad.Commons.HttpApis;
using Tiveriad.Keycloak.Apis;
using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Services;

public class RolesApi:BaseApi, IRolesApi
{
    public RolesApi(HttpClient httpClient, IKeycloakSessionFactory keycloakSessionFactory) : base(httpClient, keycloakSessionFactory)
    {
    }

    /// <summary>
    /// Get all roles for the realm or client 
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    public async Task<ApiResponse<List<Dictionary<string, Object>>>>
        RealmRolesGetAsyncWithHttpInfo(string realm, bool? briefRepresentation = null, int? first = null,
            int? max = null, string search = null)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling RolesApi->RealmRolesGet");
                
                
        return await Execute<List<Dictionary<string, Object>>>(async (apiClient, token) =>
        {
            HttpResponseMessage result = null;
            result = await apiClient.GetAsync(builder =>
            {
                builder
                    .Header(h=>h.Authorization("Bearer",token))
                    .AppendPath($"/{realm}/roles");
            });
            return new ApiResponse<List<Dictionary<string, object>>>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<List<Dictionary<string, object>>>().ConfigureAwait(false));
        });
    }
}