using Tiveriad.Keycloak.Models;namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IIdentityProvidersApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Import identity provider from uploaded JSON file
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Dictionary&lt;string, Object&gt;</returns>
    Dictionary<string, object> RealmIdentityProviderImportConfigPost(string realm);

    /// <summary>
    ///     Import identity provider from uploaded JSON file
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
    ApiResponse<Dictionary<string, object>> RealmIdentityProviderImportConfigPostWithHttpInfo(string realm);

    /// <summary>
    ///     Delete the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns></returns>
    void RealmIdentityProviderInstancesAliasDelete(string realm, string alias);

    /// <summary>
    ///     Delete the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmIdentityProviderInstancesAliasDeleteWithHttpInfo(string realm, string alias);

    /// <summary>
    ///     Export public broker configuration for identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="format">Format to use (optional)</param>
    /// <returns></returns>
    void RealmIdentityProviderInstancesAliasExportGet(string realm, string alias, string format = null);

    /// <summary>
    ///     Export public broker configuration for identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="format">Format to use (optional)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmIdentityProviderInstancesAliasExportGetWithHttpInfo(string realm, string alias,
        string format = null);

    /// <summary>
    ///     Get the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>IdentityProviderRepresentation</returns>
    IdentityProviderRepresentation RealmIdentityProviderInstancesAliasGet(string realm, string alias);

    /// <summary>
    ///     Get the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>ApiResponse of IdentityProviderRepresentation</returns>
    ApiResponse<IdentityProviderRepresentation> RealmIdentityProviderInstancesAliasGetWithHttpInfo(string realm,
        string alias);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>ManagementPermissionReference</returns>
    ManagementPermissionReference RealmIdentityProviderInstancesAliasManagementPermissionsGet(string realm,
        string alias);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>ApiResponse of ManagementPermissionReference</returns>
    ApiResponse<ManagementPermissionReference> RealmIdentityProviderInstancesAliasManagementPermissionsGetWithHttpInfo(
        string realm, string alias);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>ManagementPermissionReference</returns>
    ManagementPermissionReference RealmIdentityProviderInstancesAliasManagementPermissionsPut(
        ManagementPermissionReference body, string realm, string alias);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>ApiResponse of ManagementPermissionReference</returns>
    ApiResponse<ManagementPermissionReference> RealmIdentityProviderInstancesAliasManagementPermissionsPutWithHttpInfo(
        ManagementPermissionReference body, string realm, string alias);

    /// <summary>
    ///     Get mapper types for identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns></returns>
    void RealmIdentityProviderInstancesAliasMapperTypesGet(string realm, string alias);

    /// <summary>
    ///     Get mapper types for identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmIdentityProviderInstancesAliasMapperTypesGetWithHttpInfo(string realm, string alias);

    /// <summary>
    ///     Get mappers for identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmIdentityProviderInstancesAliasMappersGet(string realm, string alias);

    /// <summary>
    ///     Get mappers for identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmIdentityProviderInstancesAliasMappersGetWithHttpInfo(
        string realm, string alias);

    /// <summary>
    ///     Delete a mapper for the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="id">Mapper id</param>
    /// <returns></returns>
    void RealmIdentityProviderInstancesAliasMappersIdDelete(string realm, string alias, string id);

    /// <summary>
    ///     Delete a mapper for the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="id">Mapper id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmIdentityProviderInstancesAliasMappersIdDeleteWithHttpInfo(string realm, string alias,
        string id);

    /// <summary>
    ///     Get mapper by id for the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="id">Mapper id</param>
    /// <returns>IdentityProviderMapperRepresentation</returns>
    IdentityProviderMapperRepresentation RealmIdentityProviderInstancesAliasMappersIdGet(string realm, string alias,
        string id);

    /// <summary>
    ///     Get mapper by id for the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="id">Mapper id</param>
    /// <returns>ApiResponse of IdentityProviderMapperRepresentation</returns>
    ApiResponse<IdentityProviderMapperRepresentation> RealmIdentityProviderInstancesAliasMappersIdGetWithHttpInfo(
        string realm, string alias, string id);

    /// <summary>
    ///     Update a mapper for the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="id">Mapper id</param>
    /// <returns></returns>
    void RealmIdentityProviderInstancesAliasMappersIdPut(IdentityProviderMapperRepresentation body, string realm,
        string alias, string id);

    /// <summary>
    ///     Update a mapper for the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="id">Mapper id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmIdentityProviderInstancesAliasMappersIdPutWithHttpInfo(
        IdentityProviderMapperRepresentation body, string realm, string alias, string id);

    /// <summary>
    ///     Add a mapper to identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns></returns>
    void RealmIdentityProviderInstancesAliasMappersPost(IdentityProviderMapperRepresentation body, string realm,
        string alias);

    /// <summary>
    ///     Add a mapper to identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmIdentityProviderInstancesAliasMappersPostWithHttpInfo(
        IdentityProviderMapperRepresentation body, string realm, string alias);

    /// <summary>
    ///     Update the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns></returns>
    void RealmIdentityProviderInstancesAliasPut(IdentityProviderRepresentation body, string realm, string alias);

    /// <summary>
    ///     Update the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmIdentityProviderInstancesAliasPutWithHttpInfo(IdentityProviderRepresentation body,
        string realm, string alias);

    /// <summary>
    ///     Get identity providers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmIdentityProviderInstancesGet(string realm);

    /// <summary>
    ///     Get identity providers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmIdentityProviderInstancesGetWithHttpInfo(string realm);

    /// <summary>
    ///     Create a new identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON body</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmIdentityProviderInstancesPost(IdentityProviderRepresentation body, string realm);

    /// <summary>
    ///     Create a new identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON body</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmIdentityProviderInstancesPostWithHttpInfo(IdentityProviderRepresentation body,
        string realm);

    /// <summary>
    ///     Get identity providers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="providerId">Provider id</param>
    /// <returns></returns>
    void RealmIdentityProviderProvidersProviderIdGet(string realm, string providerId);

    /// <summary>
    ///     Get identity providers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="providerId">Provider id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmIdentityProviderProvidersProviderIdGetWithHttpInfo(string realm, string providerId);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Import identity provider from uploaded JSON file
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
    Task<Dictionary<string, object>> RealmIdentityProviderImportConfigPostAsync(string realm);

    /// <summary>
    ///     Import identity provider from uploaded JSON file
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
    Task<ApiResponse<Dictionary<string, object>>> RealmIdentityProviderImportConfigPostAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Delete the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of void</returns>
    Task RealmIdentityProviderInstancesAliasDeleteAsync(string realm, string alias);

    /// <summary>
    ///     Delete the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmIdentityProviderInstancesAliasDeleteAsyncWithHttpInfo(string realm, string alias);

    /// <summary>
    ///     Export public broker configuration for identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="format">Format to use (optional)</param>
    /// <returns>Task of void</returns>
    Task RealmIdentityProviderInstancesAliasExportGetAsync(string realm, string alias, string format = null);

    /// <summary>
    ///     Export public broker configuration for identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="format">Format to use (optional)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmIdentityProviderInstancesAliasExportGetAsyncWithHttpInfo(string realm, string alias,
        string format = null);

    /// <summary>
    ///     Get the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of IdentityProviderRepresentation</returns>
    Task<IdentityProviderRepresentation> RealmIdentityProviderInstancesAliasGetAsync(string realm, string alias);

    /// <summary>
    ///     Get the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of ApiResponse (IdentityProviderRepresentation)</returns>
    Task<ApiResponse<IdentityProviderRepresentation>> RealmIdentityProviderInstancesAliasGetAsyncWithHttpInfo(
        string realm, string alias);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of ManagementPermissionReference</returns>
    Task<ManagementPermissionReference> RealmIdentityProviderInstancesAliasManagementPermissionsGetAsync(string realm,
        string alias);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of ApiResponse (ManagementPermissionReference)</returns>
    Task<ApiResponse<ManagementPermissionReference>>
        RealmIdentityProviderInstancesAliasManagementPermissionsGetAsyncWithHttpInfo(string realm, string alias);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of ManagementPermissionReference</returns>
    Task<ManagementPermissionReference> RealmIdentityProviderInstancesAliasManagementPermissionsPutAsync(
        ManagementPermissionReference body, string realm, string alias);

    /// <summary>
    ///     Return object stating whether client Authorization permissions have been initialized or not and a reference
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of ApiResponse (ManagementPermissionReference)</returns>
    Task<ApiResponse<ManagementPermissionReference>>
        RealmIdentityProviderInstancesAliasManagementPermissionsPutAsyncWithHttpInfo(ManagementPermissionReference body,
            string realm, string alias);

    /// <summary>
    ///     Get mapper types for identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of void</returns>
    Task RealmIdentityProviderInstancesAliasMapperTypesGetAsync(string realm, string alias);

    /// <summary>
    ///     Get mapper types for identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmIdentityProviderInstancesAliasMapperTypesGetAsyncWithHttpInfo(string realm,
        string alias);

    /// <summary>
    ///     Get mappers for identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmIdentityProviderInstancesAliasMappersGetAsync(string realm,
        string alias);

    /// <summary>
    ///     Get mappers for identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmIdentityProviderInstancesAliasMappersGetAsyncWithHttpInfo(
        string realm, string alias);

    /// <summary>
    ///     Delete a mapper for the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="id">Mapper id</param>
    /// <returns>Task of void</returns>
    Task RealmIdentityProviderInstancesAliasMappersIdDeleteAsync(string realm, string alias, string id);

    /// <summary>
    ///     Delete a mapper for the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="id">Mapper id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmIdentityProviderInstancesAliasMappersIdDeleteAsyncWithHttpInfo(string realm,
        string alias, string id);

    /// <summary>
    ///     Get mapper by id for the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="id">Mapper id</param>
    /// <returns>Task of IdentityProviderMapperRepresentation</returns>
    Task<IdentityProviderMapperRepresentation> RealmIdentityProviderInstancesAliasMappersIdGetAsync(string realm,
        string alias, string id);

    /// <summary>
    ///     Get mapper by id for the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="id">Mapper id</param>
    /// <returns>Task of ApiResponse (IdentityProviderMapperRepresentation)</returns>
    Task<ApiResponse<IdentityProviderMapperRepresentation>>
        RealmIdentityProviderInstancesAliasMappersIdGetAsyncWithHttpInfo(string realm, string alias, string id);

    /// <summary>
    ///     Update a mapper for the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="id">Mapper id</param>
    /// <returns>Task of void</returns>
    Task RealmIdentityProviderInstancesAliasMappersIdPutAsync(IdentityProviderMapperRepresentation body, string realm,
        string alias, string id);

    /// <summary>
    ///     Update a mapper for the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <param name="id">Mapper id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmIdentityProviderInstancesAliasMappersIdPutAsyncWithHttpInfo(
        IdentityProviderMapperRepresentation body, string realm, string alias, string id);

    /// <summary>
    ///     Add a mapper to identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of void</returns>
    Task RealmIdentityProviderInstancesAliasMappersPostAsync(IdentityProviderMapperRepresentation body, string realm,
        string alias);

    /// <summary>
    ///     Add a mapper to identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmIdentityProviderInstancesAliasMappersPostAsyncWithHttpInfo(
        IdentityProviderMapperRepresentation body, string realm, string alias);

    /// <summary>
    ///     Update the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of void</returns>
    Task RealmIdentityProviderInstancesAliasPutAsync(IdentityProviderRepresentation body, string realm, string alias);

    /// <summary>
    ///     Update the identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmIdentityProviderInstancesAliasPutAsyncWithHttpInfo(
        IdentityProviderRepresentation body, string realm, string alias);

    /// <summary>
    ///     Get identity providers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmIdentityProviderInstancesGetAsync(string realm);

    /// <summary>
    ///     Get identity providers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmIdentityProviderInstancesGetAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Create a new identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON body</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmIdentityProviderInstancesPostAsync(IdentityProviderRepresentation body, string realm);

    /// <summary>
    ///     Create a new identity provider
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON body</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmIdentityProviderInstancesPostAsyncWithHttpInfo(IdentityProviderRepresentation body,
        string realm);

    /// <summary>
    ///     Get identity providers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="providerId">Provider id</param>
    /// <returns>Task of void</returns>
    Task RealmIdentityProviderProvidersProviderIdGetAsync(string realm, string providerId);

    /// <summary>
    ///     Get identity providers
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="providerId">Provider id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmIdentityProviderProvidersProviderIdGetAsyncWithHttpInfo(string realm,
        string providerId);

    #endregion Asynchronous Operations
}