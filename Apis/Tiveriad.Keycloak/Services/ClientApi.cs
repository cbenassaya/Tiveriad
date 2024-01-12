#region

using Tiveriad.Commons.HttpApis;
using Tiveriad.Keycloak.Apis;
using Tiveriad.Keycloak.Models;

#endregion

namespace Tiveriad.Keycloak.Services;

public class ClientApi : BaseApi, IClientApi
{
    public ClientApi(HttpClient httpClient, IKeycloakSessionFactory keycloakSessionFactory) : base(httpClient,
        keycloakSessionFactory)
    {
    }


    /// <summary>
    ///     Get representation of the client
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse (ClientRepresentation)</returns>
    public Task<ApiResponse<ClientRepresentation>> GetClientByRealmById(string realm, string id)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling ClientApi->GetClientByRealmById");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400,
                "Missing required parameter 'id' when calling ClientApi->GetClientByRealmById");

        return Execute(async (apiClient, token) =>
        {
            var result = await apiClient.GetAsync(builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/clients/{id}");
            });
            return new ApiResponse<ClientRepresentation>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<ClientRepresentation>().ConfigureAwait(false));
        });
    }

    /// <summary>
    ///     Get clients belonging to the realm.
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="clientId">filter by clientId (optional)</param>
    /// <param name="first">the first result (optional)</param>
    /// <param name="max">the max results to return (optional)</param>
    /// <param name="q"> (optional)</param>
    /// <param name="search">whether this is a search query or a getClientById query (optional)</param>
    /// <param name="viewableOnly">filter clients that cannot be viewed in full by admin (optional)</param>
    /// <returns>Task of ApiResponse (Object)</returns>
    public Task<ApiResponse<List<ClientRepresentation>>> GetClients(string realm,
        string? clientId = null, int? first = null, int? max = null, string? q = null, string? search = null,
        bool? viewableOnly = null)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400, "Missing required parameter 'realm' when calling ClientApi->GetClients");

        return Execute(async (apiClient, token) =>
        {
            var result = await apiClient.GetAsync(builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .QueryStringIf(() => first != null, "first", first)
                    .QueryStringIf(() => max != null, "max", max)
                    .QueryStringIf(() => viewableOnly != null, "viewableOnly", viewableOnly)
                    .QueryStringIf(() => !string.IsNullOrEmpty(search), "search", search)
                    .QueryStringIf(() => !string.IsNullOrEmpty(q), "q", q)
                    .QueryStringIf(() => !string.IsNullOrEmpty(clientId), "clientId", clientId)
                    .AppendPath($"/{realm}/clients");
            });
            return new ApiResponse<List<ClientRepresentation>>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<List<ClientRepresentation>>().ConfigureAwait(false));
        });
    }

    /// <summary>
    ///     Get the client secret
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse (CredentialRepresentation)</returns>
    public Task<ApiResponse<CredentialRepresentation>> GetClientSecret(string realm, string id)
    {
        // verify the required parameter 'realm' is set
        if (realm == null)
            throw new ApiException(400,
                "Missing required parameter 'realm' when calling ClientApi->GetClientSecret");
        // verify the required parameter 'id' is set
        if (id == null)
            throw new ApiException(400, "Missing required parameter 'id' when calling ClientApi->GetClientSecret");


        return Execute(async (apiClient, token) =>
        {
            var result = await apiClient.GetAsync(builder =>
            {
                builder
                    .Header(h => h.Authorization("Bearer", token))
                    .AppendPath($"/{realm}/clients/{id}/client-secret");
            });
            return new ApiResponse<CredentialRepresentation>((int)result.StatusCode,
                result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                await result.DeserializeAsync<CredentialRepresentation>().ConfigureAwait(false));
        });
    }
}