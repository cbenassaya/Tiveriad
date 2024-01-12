#region

using Tiveriad.Keycloak.Models;

#endregion

namespace Tiveriad.Keycloak.Apis;

public interface IClientApi
{
    /// <summary>
    ///     Get representation of the client
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse (ClientRepresentation)</returns>
    Task<ApiResponse<ClientRepresentation>> GetClientByRealmById(string realm, string id);

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
    Task<ApiResponse<List<ClientRepresentation>>> GetClients(string realm,
        string? clientId = null, int? first = null, int? max = null, string? q = null, string? search = null,
        bool? viewableOnly = null);
}