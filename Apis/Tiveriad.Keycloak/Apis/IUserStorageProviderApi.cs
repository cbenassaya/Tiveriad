using Tiveriad.Keycloak.Models;namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IUserStorageProviderApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Need this for admin console to display simple name of provider when displaying client detail   KEYCLOAK-4328
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="id"></param>
    /// <returns>Dictionary&lt;string, Object&gt;</returns>
    Dictionary<string, object> IdNameGet(string id);

    /// <summary>
    ///     Need this for admin console to display simple name of provider when displaying client detail   KEYCLOAK-4328
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
    ApiResponse<Dictionary<string, object>> IdNameGetWithHttpInfo(string id);

    /// <summary>
    ///     Need this for admin console to display simple name of provider when displaying user detail   KEYCLOAK-4328
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Dictionary&lt;string, Object&gt;</returns>
    Dictionary<string, object> RealmUserStorageIdNameGet(string realm, string id);

    /// <summary>
    ///     Need this for admin console to display simple name of provider when displaying user detail   KEYCLOAK-4328
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
    ApiResponse<Dictionary<string, object>> RealmUserStorageIdNameGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Remove imported users
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns></returns>
    void RealmUserStorageIdRemoveImportedUsersPost(string realm, string id);

    /// <summary>
    ///     Remove imported users
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUserStorageIdRemoveImportedUsersPostWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Trigger sync of users   Action can be \&quot;triggerFullSync\&quot; or \&quot;triggerChangedUsersSync\&quot;
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="action"> (optional)</param>
    /// <returns>SynchronizationResult</returns>
    SynchronizationResult RealmUserStorageIdSyncPost(string realm, string id, string action = null);

    /// <summary>
    ///     Trigger sync of users   Action can be \&quot;triggerFullSync\&quot; or \&quot;triggerChangedUsersSync\&quot;
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="action"> (optional)</param>
    /// <returns>ApiResponse of SynchronizationResult</returns>
    ApiResponse<SynchronizationResult> RealmUserStorageIdSyncPostWithHttpInfo(string realm, string id,
        string action = null);

    /// <summary>
    ///     Unlink imported users from a storage provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns></returns>
    void RealmUserStorageIdUnlinkUsersPost(string realm, string id);

    /// <summary>
    ///     Unlink imported users from a storage provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUserStorageIdUnlinkUsersPostWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Trigger sync of mapper data related to ldap mapper (roles, groups, …​)   direction is \&quot;fedToKeycloak\&quot;
    ///     or \&quot;keycloakToFed\&quot;
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="direction"> (optional)</param>
    /// <returns>SynchronizationResult</returns>
    SynchronizationResult RealmUserStorageParentIdMappersIdSyncPost(string realm, string parentId, string id,
        string direction = null);

    /// <summary>
    ///     Trigger sync of mapper data related to ldap mapper (roles, groups, …​)   direction is \&quot;fedToKeycloak\&quot;
    ///     or \&quot;keycloakToFed\&quot;
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="direction"> (optional)</param>
    /// <returns>ApiResponse of SynchronizationResult</returns>
    ApiResponse<SynchronizationResult> RealmUserStorageParentIdMappersIdSyncPostWithHttpInfo(string realm,
        string parentId, string id, string direction = null);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Need this for admin console to display simple name of provider when displaying client detail   KEYCLOAK-4328
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="id"></param>
    /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
    Task<Dictionary<string, object>> IdNameGetAsync(string id);

    /// <summary>
    ///     Need this for admin console to display simple name of provider when displaying client detail   KEYCLOAK-4328
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
    Task<ApiResponse<Dictionary<string, object>>> IdNameGetAsyncWithHttpInfo(string id);

    /// <summary>
    ///     Need this for admin console to display simple name of provider when displaying user detail   KEYCLOAK-4328
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
    Task<Dictionary<string, object>> RealmUserStorageIdNameGetAsync(string realm, string id);

    /// <summary>
    ///     Need this for admin console to display simple name of provider when displaying user detail   KEYCLOAK-4328
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
    Task<ApiResponse<Dictionary<string, object>>> RealmUserStorageIdNameGetAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Remove imported users
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of void</returns>
    Task RealmUserStorageIdRemoveImportedUsersPostAsync(string realm, string id);

    /// <summary>
    ///     Remove imported users
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUserStorageIdRemoveImportedUsersPostAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Trigger sync of users   Action can be \&quot;triggerFullSync\&quot; or \&quot;triggerChangedUsersSync\&quot;
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="action"> (optional)</param>
    /// <returns>Task of SynchronizationResult</returns>
    Task<SynchronizationResult> RealmUserStorageIdSyncPostAsync(string realm, string id, string action = null);

    /// <summary>
    ///     Trigger sync of users   Action can be \&quot;triggerFullSync\&quot; or \&quot;triggerChangedUsersSync\&quot;
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="action"> (optional)</param>
    /// <returns>Task of ApiResponse (SynchronizationResult)</returns>
    Task<ApiResponse<SynchronizationResult>> RealmUserStorageIdSyncPostAsyncWithHttpInfo(string realm, string id,
        string action = null);

    /// <summary>
    ///     Unlink imported users from a storage provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of void</returns>
    Task RealmUserStorageIdUnlinkUsersPostAsync(string realm, string id);

    /// <summary>
    ///     Unlink imported users from a storage provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUserStorageIdUnlinkUsersPostAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Trigger sync of mapper data related to ldap mapper (roles, groups, …​)   direction is \&quot;fedToKeycloak\&quot;
    ///     or \&quot;keycloakToFed\&quot;
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="direction"> (optional)</param>
    /// <returns>Task of SynchronizationResult</returns>
    Task<SynchronizationResult> RealmUserStorageParentIdMappersIdSyncPostAsync(string realm, string parentId, string id,
        string direction = null);

    /// <summary>
    ///     Trigger sync of mapper data related to ldap mapper (roles, groups, …​)   direction is \&quot;fedToKeycloak\&quot;
    ///     or \&quot;keycloakToFed\&quot;
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="direction"> (optional)</param>
    /// <returns>Task of ApiResponse (SynchronizationResult)</returns>
    Task<ApiResponse<SynchronizationResult>> RealmUserStorageParentIdMappersIdSyncPostAsyncWithHttpInfo(string realm,
        string parentId, string id, string direction = null);

    #endregion Asynchronous Operations
}