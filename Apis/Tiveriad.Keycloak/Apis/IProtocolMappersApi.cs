using Tiveriad.Keycloak.Models;namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IProtocolMappersApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Delete the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns></returns>
    void RealmClientScopesId1ProtocolMappersModelsId2Delete(string realm, string id1, string id2);

    /// <summary>
    ///     Delete the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientScopesId1ProtocolMappersModelsId2DeleteWithHttpInfo(string realm, string id1,
        string id2);

    /// <summary>
    ///     Get mapper by id
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>ProtocolMapperRepresentation</returns>
    ProtocolMapperRepresentation RealmClientScopesId1ProtocolMappersModelsId2Get(string realm, string id1, string id2);

    /// <summary>
    ///     Get mapper by id
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>ApiResponse of ProtocolMapperRepresentation</returns>
    ApiResponse<ProtocolMapperRepresentation> RealmClientScopesId1ProtocolMappersModelsId2GetWithHttpInfo(string realm,
        string id1, string id2);

    /// <summary>
    ///     Update the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns></returns>
    void RealmClientScopesId1ProtocolMappersModelsId2Put(ProtocolMapperRepresentation body, string realm, string id1,
        string id2);

    /// <summary>
    ///     Update the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientScopesId1ProtocolMappersModelsId2PutWithHttpInfo(ProtocolMapperRepresentation body,
        string realm, string id1, string id2);

    /// <summary>
    ///     Create multiple mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns></returns>
    void RealmClientScopesIdProtocolMappersAddModelsPost(List<ProtocolMapperRepresentation> body, string realm,
        string id);

    /// <summary>
    ///     Create multiple mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientScopesIdProtocolMappersAddModelsPostWithHttpInfo(
        List<ProtocolMapperRepresentation> body, string realm, string id);

    /// <summary>
    ///     Get mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientScopesIdProtocolMappersModelsGet(string realm, string id);

    /// <summary>
    ///     Get mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientScopesIdProtocolMappersModelsGetWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Create a mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns></returns>
    void RealmClientScopesIdProtocolMappersModelsPost(ProtocolMapperRepresentation body, string realm, string id);

    /// <summary>
    ///     Create a mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientScopesIdProtocolMappersModelsPostWithHttpInfo(ProtocolMapperRepresentation body,
        string realm, string id);

    /// <summary>
    ///     Get mappers by name for a specific protocol
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="protocol"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientScopesIdProtocolMappersProtocolProtocolGet(string realm, string id,
        string protocol);

    /// <summary>
    ///     Get mappers by name for a specific protocol
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="protocol"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientScopesIdProtocolMappersProtocolProtocolGetWithHttpInfo(
        string realm, string id, string protocol);

    /// <summary>
    ///     Delete the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns></returns>
    void RealmClientsId1ProtocolMappersModelsId2Delete(string realm, string id1, string id2);

    /// <summary>
    ///     Delete the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsId1ProtocolMappersModelsId2DeleteWithHttpInfo(string realm, string id1, string id2);

    /// <summary>
    ///     Get mapper by id
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>ProtocolMapperRepresentation</returns>
    ProtocolMapperRepresentation RealmClientsId1ProtocolMappersModelsId2Get(string realm, string id1, string id2);

    /// <summary>
    ///     Get mapper by id
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>ApiResponse of ProtocolMapperRepresentation</returns>
    ApiResponse<ProtocolMapperRepresentation> RealmClientsId1ProtocolMappersModelsId2GetWithHttpInfo(string realm,
        string id1, string id2);

    /// <summary>
    ///     Update the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns></returns>
    void RealmClientsId1ProtocolMappersModelsId2Put(ProtocolMapperRepresentation body, string realm, string id1,
        string id2);

    /// <summary>
    ///     Update the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsId1ProtocolMappersModelsId2PutWithHttpInfo(ProtocolMapperRepresentation body,
        string realm, string id1, string id2);

    /// <summary>
    ///     Create multiple mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns></returns>
    void RealmClientsIdProtocolMappersAddModelsPost(List<ProtocolMapperRepresentation> body, string realm, string id);

    /// <summary>
    ///     Create multiple mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdProtocolMappersAddModelsPostWithHttpInfo(List<ProtocolMapperRepresentation> body,
        string realm, string id);

    /// <summary>
    ///     Get mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdProtocolMappersModelsGet(string realm, string id);

    /// <summary>
    ///     Get mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdProtocolMappersModelsGetWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Create a mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns></returns>
    void RealmClientsIdProtocolMappersModelsPost(ProtocolMapperRepresentation body, string realm, string id);

    /// <summary>
    ///     Create a mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmClientsIdProtocolMappersModelsPostWithHttpInfo(ProtocolMapperRepresentation body,
        string realm, string id);

    /// <summary>
    ///     Get mappers by name for a specific protocol
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="protocol"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmClientsIdProtocolMappersProtocolProtocolGet(string realm, string id,
        string protocol);

    /// <summary>
    ///     Get mappers by name for a specific protocol
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="protocol"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmClientsIdProtocolMappersProtocolProtocolGetWithHttpInfo(
        string realm, string id, string protocol);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Delete the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>Task of void</returns>
    Task RealmClientScopesId1ProtocolMappersModelsId2DeleteAsync(string realm, string id1, string id2);

    /// <summary>
    ///     Delete the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientScopesId1ProtocolMappersModelsId2DeleteAsyncWithHttpInfo(string realm,
        string id1, string id2);

    /// <summary>
    ///     Get mapper by id
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>Task of ProtocolMapperRepresentation</returns>
    Task<ProtocolMapperRepresentation> RealmClientScopesId1ProtocolMappersModelsId2GetAsync(string realm, string id1,
        string id2);

    /// <summary>
    ///     Get mapper by id
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>Task of ApiResponse (ProtocolMapperRepresentation)</returns>
    Task<ApiResponse<ProtocolMapperRepresentation>> RealmClientScopesId1ProtocolMappersModelsId2GetAsyncWithHttpInfo(
        string realm, string id1, string id2);

    /// <summary>
    ///     Update the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>Task of void</returns>
    Task RealmClientScopesId1ProtocolMappersModelsId2PutAsync(ProtocolMapperRepresentation body, string realm,
        string id1, string id2);

    /// <summary>
    ///     Update the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientScopesId1ProtocolMappersModelsId2PutAsyncWithHttpInfo(
        ProtocolMapperRepresentation body, string realm, string id1, string id2);

    /// <summary>
    ///     Create multiple mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of void</returns>
    Task RealmClientScopesIdProtocolMappersAddModelsPostAsync(List<ProtocolMapperRepresentation> body, string realm,
        string id);

    /// <summary>
    ///     Create multiple mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientScopesIdProtocolMappersAddModelsPostAsyncWithHttpInfo(
        List<ProtocolMapperRepresentation> body, string realm, string id);

    /// <summary>
    ///     Get mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientScopesIdProtocolMappersModelsGetAsync(string realm, string id);

    /// <summary>
    ///     Get mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientScopesIdProtocolMappersModelsGetAsyncWithHttpInfo(
        string realm, string id);

    /// <summary>
    ///     Create a mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of void</returns>
    Task RealmClientScopesIdProtocolMappersModelsPostAsync(ProtocolMapperRepresentation body, string realm, string id);

    /// <summary>
    ///     Create a mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientScopesIdProtocolMappersModelsPostAsyncWithHttpInfo(
        ProtocolMapperRepresentation body, string realm, string id);

    /// <summary>
    ///     Get mappers by name for a specific protocol
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="protocol"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientScopesIdProtocolMappersProtocolProtocolGetAsync(string realm,
        string id, string protocol);

    /// <summary>
    ///     Get mappers by name for a specific protocol
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client scope (not name)</param>
    /// <param name="protocol"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmClientScopesIdProtocolMappersProtocolProtocolGetAsyncWithHttpInfo(string realm, string id,
            string protocol);

    /// <summary>
    ///     Delete the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>Task of void</returns>
    Task RealmClientsId1ProtocolMappersModelsId2DeleteAsync(string realm, string id1, string id2);

    /// <summary>
    ///     Delete the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsId1ProtocolMappersModelsId2DeleteAsyncWithHttpInfo(string realm, string id1,
        string id2);

    /// <summary>
    ///     Get mapper by id
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>Task of ProtocolMapperRepresentation</returns>
    Task<ProtocolMapperRepresentation> RealmClientsId1ProtocolMappersModelsId2GetAsync(string realm, string id1,
        string id2);

    /// <summary>
    ///     Get mapper by id
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>Task of ApiResponse (ProtocolMapperRepresentation)</returns>
    Task<ApiResponse<ProtocolMapperRepresentation>> RealmClientsId1ProtocolMappersModelsId2GetAsyncWithHttpInfo(
        string realm, string id1, string id2);

    /// <summary>
    ///     Update the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>Task of void</returns>
    Task RealmClientsId1ProtocolMappersModelsId2PutAsync(ProtocolMapperRepresentation body, string realm, string id1,
        string id2);

    /// <summary>
    ///     Update the mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id1"></param>
    /// <param name="id2"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsId1ProtocolMappersModelsId2PutAsyncWithHttpInfo(
        ProtocolMapperRepresentation body, string realm, string id1, string id2);

    /// <summary>
    ///     Create multiple mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdProtocolMappersAddModelsPostAsync(List<ProtocolMapperRepresentation> body, string realm,
        string id);

    /// <summary>
    ///     Create multiple mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdProtocolMappersAddModelsPostAsyncWithHttpInfo(
        List<ProtocolMapperRepresentation> body, string realm, string id);

    /// <summary>
    ///     Get mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdProtocolMappersModelsGetAsync(string realm, string id);

    /// <summary>
    ///     Get mappers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmClientsIdProtocolMappersModelsGetAsyncWithHttpInfo(
        string realm, string id);

    /// <summary>
    ///     Create a mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of void</returns>
    Task RealmClientsIdProtocolMappersModelsPostAsync(ProtocolMapperRepresentation body, string realm, string id);

    /// <summary>
    ///     Create a mapper
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmClientsIdProtocolMappersModelsPostAsyncWithHttpInfo(
        ProtocolMapperRepresentation body, string realm, string id);

    /// <summary>
    ///     Get mappers by name for a specific protocol
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="protocol"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmClientsIdProtocolMappersProtocolProtocolGetAsync(string realm,
        string id, string protocol);

    /// <summary>
    ///     Get mappers by name for a specific protocol
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">id of client (not client-id)</param>
    /// <param name="protocol"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmClientsIdProtocolMappersProtocolProtocolGetAsyncWithHttpInfo(string realm, string id, string protocol);

    #endregion Asynchronous Operations
}