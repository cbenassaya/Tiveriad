using Tiveriad.Keycloak.Models;namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IComponentApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="name"> (optional)</param>
    /// <param name="parent"> (optional)</param>
    /// <param name="type"> (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmComponentsGet(string realm, string name = null, string parent = null,
        string type = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="name"> (optional)</param>
    /// <param name="parent"> (optional)</param>
    /// <param name="type"> (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmComponentsGetWithHttpInfo(string realm, string name = null,
        string parent = null, string type = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns></returns>
    void RealmComponentsIdDelete(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmComponentsIdDeleteWithHttpInfo(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ComponentRepresentation</returns>
    ComponentRepresentation RealmComponentsIdGet(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of ComponentRepresentation</returns>
    ApiResponse<ComponentRepresentation> RealmComponentsIdGetWithHttpInfo(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns></returns>
    void RealmComponentsIdPut(ComponentRepresentation body, string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmComponentsIdPutWithHttpInfo(ComponentRepresentation body, string realm, string id);

    /// <summary>
    ///     List of subcomponent types that are available to configure for a particular parent component.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="type"> (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmComponentsIdSubComponentTypesGet(string realm, string id, string type = null);

    /// <summary>
    ///     List of subcomponent types that are available to configure for a particular parent component.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="type"> (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmComponentsIdSubComponentTypesGetWithHttpInfo(string realm,
        string id, string type = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmComponentsPost(ComponentRepresentation body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmComponentsPostWithHttpInfo(ComponentRepresentation body, string realm);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="name"> (optional)</param>
    /// <param name="parent"> (optional)</param>
    /// <param name="type"> (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmComponentsGetAsync(string realm, string name = null,
        string parent = null, string type = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="name"> (optional)</param>
    /// <param name="parent"> (optional)</param>
    /// <param name="type"> (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmComponentsGetAsyncWithHttpInfo(string realm,
        string name = null, string parent = null, string type = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of void</returns>
    Task RealmComponentsIdDeleteAsync(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmComponentsIdDeleteAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ComponentRepresentation</returns>
    Task<ComponentRepresentation> RealmComponentsIdGetAsync(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse (ComponentRepresentation)</returns>
    Task<ApiResponse<ComponentRepresentation>> RealmComponentsIdGetAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of void</returns>
    Task RealmComponentsIdPutAsync(ComponentRepresentation body, string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmComponentsIdPutAsyncWithHttpInfo(ComponentRepresentation body, string realm,
        string id);

    /// <summary>
    ///     List of subcomponent types that are available to configure for a particular parent component.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="type"> (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmComponentsIdSubComponentTypesGetAsync(string realm, string id,
        string type = null);

    /// <summary>
    ///     List of subcomponent types that are available to configure for a particular parent component.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="type"> (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmComponentsIdSubComponentTypesGetAsyncWithHttpInfo(
        string realm, string id, string type = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmComponentsPostAsync(ComponentRepresentation body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmComponentsPostAsyncWithHttpInfo(ComponentRepresentation body, string realm);

    #endregion Asynchronous Operations
}