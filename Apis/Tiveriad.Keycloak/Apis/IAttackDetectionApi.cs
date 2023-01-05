using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IAttackDetectionApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Clear any user login failures for all users   This can release temporary disabled users
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmAttackDetectionBruteForceUsersDelete(string realm);

    /// <summary>
    ///     Clear any user login failures for all users   This can release temporary disabled users
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAttackDetectionBruteForceUsersDeleteWithHttpInfo(string realm);

    /// <summary>
    ///     Clear any user login failures for the user   This can release temporary disabled user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="userId"></param>
    /// <returns></returns>
    void RealmAttackDetectionBruteForceUsersUserIdDelete(string realm, string userId);

    /// <summary>
    ///     Clear any user login failures for the user   This can release temporary disabled user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="userId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAttackDetectionBruteForceUsersUserIdDeleteWithHttpInfo(string realm, string userId);

    /// <summary>
    ///     Get status of a username in brute force detection
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="userId"></param>
    /// <returns>Dictionary&lt;string, Object&gt;</returns>
    Dictionary<string, object> RealmAttackDetectionBruteForceUsersUserIdGet(string realm, string userId);

    /// <summary>
    ///     Get status of a username in brute force detection
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="userId"></param>
    /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
    ApiResponse<Dictionary<string, object>> RealmAttackDetectionBruteForceUsersUserIdGetWithHttpInfo(string realm,
        string userId);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Clear any user login failures for all users   This can release temporary disabled users
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmAttackDetectionBruteForceUsersDeleteAsync(string realm);

    /// <summary>
    ///     Clear any user login failures for all users   This can release temporary disabled users
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAttackDetectionBruteForceUsersDeleteAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Clear any user login failures for the user   This can release temporary disabled user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="userId"></param>
    /// <returns>Task of void</returns>
    Task RealmAttackDetectionBruteForceUsersUserIdDeleteAsync(string realm, string userId);

    /// <summary>
    ///     Clear any user login failures for the user   This can release temporary disabled user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="userId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAttackDetectionBruteForceUsersUserIdDeleteAsyncWithHttpInfo(string realm,
        string userId);

    /// <summary>
    ///     Get status of a username in brute force detection
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="userId"></param>
    /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
    Task<Dictionary<string, object>> RealmAttackDetectionBruteForceUsersUserIdGetAsync(string realm, string userId);

    /// <summary>
    ///     Get status of a username in brute force detection
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="userId"></param>
    /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
    Task<ApiResponse<Dictionary<string, object>>> RealmAttackDetectionBruteForceUsersUserIdGetAsyncWithHttpInfo(
        string realm, string userId);

    #endregion Asynchronous Operations
}