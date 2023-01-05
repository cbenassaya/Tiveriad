using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IClientRegistrationPolicyApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Base path for retrieve providers with the configProperties properly filled
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientRegistrationPolicyProvidersGet(string realm);

    /// <summary>
    ///     Base path for retrieve providers with the configProperties properly filled
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientRegistrationPolicyProvidersGetWithHttpInfo(string realm);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Base path for retrieve providers with the configProperties properly filled
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientRegistrationPolicyProvidersGetAsync(string realm);

    /// <summary>
    ///     Base path for retrieve providers with the configProperties properly filled
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmClientRegistrationPolicyProvidersGetAsyncWithHttpInfo(string realm);

    #endregion Asynchronous Operations
}