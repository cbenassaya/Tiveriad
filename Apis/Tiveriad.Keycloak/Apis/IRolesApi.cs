#region

using Tiveriad.Keycloak.Models;

#endregion

namespace Tiveriad.Keycloak.Apis;

public interface IRolesApi
{
    /// <summary>
    ///     Get all roles for the realm or client
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmRolesGetAsyncWithHttpInfo(string realm, bool? briefRepresentation = null, int? first = null,
            int? max = null, string search = null);
}