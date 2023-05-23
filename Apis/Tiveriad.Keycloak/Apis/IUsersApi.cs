#region

using Tiveriad.Keycloak.Models;

#endregion

namespace Tiveriad.Keycloak.Apis;

public interface IUsersApi
{
    /// <summary>
    ///     Get representation of the user
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not userId!)</param>
    /// <param name="userId">User userId</param>
    /// <returns>Task of ApiResponse (UserRepresentation)</returns>
    Task<ApiResponse<UserRepresentation>> RealmUsersIdGetAsyncWithHttpInfo(string realm, string userId);

    /// <summary>
    ///     Update the user
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not userId!)</param>
    /// <param name="userId">User userId</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdPutAsyncWithHttpInfo(
        UserRepresentation body, string realm, string userId);
}