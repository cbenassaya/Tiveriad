using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IAuthenticationManagementApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Get authenticator providers   Returns a stream of authenticator providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmAuthenticationAuthenticatorProvidersGet(string realm);

    /// <summary>
    ///     Get authenticator providers   Returns a stream of authenticator providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>>
        RealmAuthenticationAuthenticatorProvidersGetWithHttpInfo(string realm);

    /// <summary>
    ///     Get client authenticator providers   Returns a stream of client authenticator providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmAuthenticationClientAuthenticatorProvidersGet(string realm);

    /// <summary>
    ///     Get client authenticator providers   Returns a stream of client authenticator providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>>
        RealmAuthenticationClientAuthenticatorProvidersGetWithHttpInfo(string realm);

    /// <summary>
    ///     Get authenticator provider’s configuration description
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="providerId"></param>
    /// <returns>AuthenticatorConfigInfoRepresentation</returns>
    AuthenticatorConfigInfoRepresentation RealmAuthenticationConfigDescriptionProviderIdGet(string realm,
        string providerId);

    /// <summary>
    ///     Get authenticator provider’s configuration description
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="providerId"></param>
    /// <returns>ApiResponse of AuthenticatorConfigInfoRepresentation</returns>
    ApiResponse<AuthenticatorConfigInfoRepresentation> RealmAuthenticationConfigDescriptionProviderIdGetWithHttpInfo(
        string realm, string providerId);

    /// <summary>
    ///     Delete authenticator configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Configuration id</param>
    /// <returns></returns>
    void RealmAuthenticationConfigIdDelete(string realm, string id);

    /// <summary>
    ///     Delete authenticator configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Configuration id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationConfigIdDeleteWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get authenticator configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Configuration id</param>
    /// <returns>AuthenticatorConfigRepresentation</returns>
    AuthenticatorConfigRepresentation RealmAuthenticationConfigIdGet(string realm, string id);

    /// <summary>
    ///     Get authenticator configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Configuration id</param>
    /// <returns>ApiResponse of AuthenticatorConfigRepresentation</returns>
    ApiResponse<AuthenticatorConfigRepresentation> RealmAuthenticationConfigIdGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Update authenticator configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON describing new state of authenticator configuration</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Configuration id</param>
    /// <returns></returns>
    void RealmAuthenticationConfigIdPut(AuthenticatorConfigRepresentation body, string realm, string id);

    /// <summary>
    ///     Update authenticator configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON describing new state of authenticator configuration</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Configuration id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationConfigIdPutWithHttpInfo(AuthenticatorConfigRepresentation body, string realm,
        string id);

    /// <summary>
    ///     Update execution with new configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON with new configuration</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns></returns>
    void RealmAuthenticationExecutionsExecutionIdConfigPost(AuthenticatorConfigRepresentation body, string realm,
        string executionId);

    /// <summary>
    ///     Update execution with new configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON with new configuration</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationExecutionsExecutionIdConfigPostWithHttpInfo(
        AuthenticatorConfigRepresentation body, string realm, string executionId);

    /// <summary>
    ///     Delete execution
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns></returns>
    void RealmAuthenticationExecutionsExecutionIdDelete(string realm, string executionId);

    /// <summary>
    ///     Delete execution
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationExecutionsExecutionIdDeleteWithHttpInfo(string realm, string executionId);

    /// <summary>
    ///     Get Single Execution
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns></returns>
    void RealmAuthenticationExecutionsExecutionIdGet(string realm, string executionId);

    /// <summary>
    ///     Get Single Execution
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationExecutionsExecutionIdGetWithHttpInfo(string realm, string executionId);

    /// <summary>
    ///     Lower execution’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns></returns>
    void RealmAuthenticationExecutionsExecutionIdLowerPriorityPost(string realm, string executionId);

    /// <summary>
    ///     Lower execution’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationExecutionsExecutionIdLowerPriorityPostWithHttpInfo(string realm,
        string executionId);

    /// <summary>
    ///     Raise execution’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns></returns>
    void RealmAuthenticationExecutionsExecutionIdRaisePriorityPost(string realm, string executionId);

    /// <summary>
    ///     Raise execution’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationExecutionsExecutionIdRaisePriorityPostWithHttpInfo(string realm,
        string executionId);

    /// <summary>
    ///     Add new authentication execution
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON model describing authentication execution</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmAuthenticationExecutionsPost(AuthenticationExecutionRepresentation body, string realm);

    /// <summary>
    ///     Add new authentication execution
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON model describing authentication execution</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationExecutionsPostWithHttpInfo(AuthenticationExecutionRepresentation body,
        string realm);

    /// <summary>
    ///     Copy existing authentication flow under a new name   The new name is given as &#x27;newName&#x27; attribute of the
    ///     passed JSON object
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON containing &#x27;newName&#x27; attribute</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Name of the existing authentication flow</param>
    /// <returns></returns>
    void RealmAuthenticationFlowsFlowAliasCopyPost(Dictionary<string, object> body, string realm, string flowAlias);

    /// <summary>
    ///     Copy existing authentication flow under a new name   The new name is given as &#x27;newName&#x27; attribute of the
    ///     passed JSON object
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON containing &#x27;newName&#x27; attribute</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Name of the existing authentication flow</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationFlowsFlowAliasCopyPostWithHttpInfo(Dictionary<string, object> body,
        string realm, string flowAlias);

    /// <summary>
    ///     Add new authentication execution to a flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">New execution JSON data containing &#x27;provider&#x27; attribute</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Alias of parent flow</param>
    /// <returns></returns>
    void RealmAuthenticationFlowsFlowAliasExecutionsExecutionPost(Dictionary<string, object> body, string realm,
        string flowAlias);

    /// <summary>
    ///     Add new authentication execution to a flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">New execution JSON data containing &#x27;provider&#x27; attribute</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Alias of parent flow</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationFlowsFlowAliasExecutionsExecutionPostWithHttpInfo(
        Dictionary<string, object> body, string realm, string flowAlias);

    /// <summary>
    ///     Add new flow with new execution to existing flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">
    ///     New authentication flow / execution JSON data containing &#x27;alias&#x27;, &#x27;type&#x27;, &#x27;
    ///     provider&#x27;, and &#x27;description&#x27; attributes
    /// </param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Alias of parent authentication flow</param>
    /// <returns></returns>
    void RealmAuthenticationFlowsFlowAliasExecutionsFlowPost(Dictionary<string, object> body, string realm,
        string flowAlias);

    /// <summary>
    ///     Add new flow with new execution to existing flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">
    ///     New authentication flow / execution JSON data containing &#x27;alias&#x27;, &#x27;type&#x27;, &#x27;
    ///     provider&#x27;, and &#x27;description&#x27; attributes
    /// </param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Alias of parent authentication flow</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationFlowsFlowAliasExecutionsFlowPostWithHttpInfo(Dictionary<string, object> body,
        string realm, string flowAlias);

    /// <summary>
    ///     Get authentication executions for a flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Flow alias</param>
    /// <returns></returns>
    void RealmAuthenticationFlowsFlowAliasExecutionsGet(string realm, string flowAlias);

    /// <summary>
    ///     Get authentication executions for a flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Flow alias</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationFlowsFlowAliasExecutionsGetWithHttpInfo(string realm, string flowAlias);

    /// <summary>
    ///     Update authentication executions of a Flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">AuthenticationExecutionInfoRepresentation</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Flow alias</param>
    /// <returns></returns>
    void RealmAuthenticationFlowsFlowAliasExecutionsPut(AuthenticationExecutionInfoRepresentation body, string realm,
        string flowAlias);

    /// <summary>
    ///     Update authentication executions of a Flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">AuthenticationExecutionInfoRepresentation</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Flow alias</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationFlowsFlowAliasExecutionsPutWithHttpInfo(
        AuthenticationExecutionInfoRepresentation body, string realm, string flowAlias);

    /// <summary>
    ///     Get authentication flows   Returns a stream of authentication flows.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmAuthenticationFlowsGet(string realm);

    /// <summary>
    ///     Get authentication flows   Returns a stream of authentication flows.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmAuthenticationFlowsGetWithHttpInfo(string realm);

    /// <summary>
    ///     Delete an authentication flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Flow id</param>
    /// <returns></returns>
    void RealmAuthenticationFlowsIdDelete(string realm, string id);

    /// <summary>
    ///     Delete an authentication flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Flow id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationFlowsIdDeleteWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get authentication flow for id
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Flow id</param>
    /// <returns>AuthenticationFlowRepresentation</returns>
    AuthenticationFlowRepresentation RealmAuthenticationFlowsIdGet(string realm, string id);

    /// <summary>
    ///     Get authentication flow for id
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Flow id</param>
    /// <returns>ApiResponse of AuthenticationFlowRepresentation</returns>
    ApiResponse<AuthenticationFlowRepresentation> RealmAuthenticationFlowsIdGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Update an authentication flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Authentication flow representation</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Flow id</param>
    /// <returns></returns>
    void RealmAuthenticationFlowsIdPut(AuthenticationFlowRepresentation body, string realm, string id);

    /// <summary>
    ///     Update an authentication flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Authentication flow representation</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Flow id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationFlowsIdPutWithHttpInfo(AuthenticationFlowRepresentation body, string realm,
        string id);

    /// <summary>
    ///     Create a new authentication flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Authentication flow representation</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmAuthenticationFlowsPost(AuthenticationFlowRepresentation body, string realm);

    /// <summary>
    ///     Create a new authentication flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Authentication flow representation</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationFlowsPostWithHttpInfo(AuthenticationFlowRepresentation body, string realm);

    /// <summary>
    ///     Get form action providers   Returns a stream of form action providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmAuthenticationFormActionProvidersGet(string realm);

    /// <summary>
    ///     Get form action providers   Returns a stream of form action providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmAuthenticationFormActionProvidersGetWithHttpInfo(string realm);

    /// <summary>
    ///     Get form providers   Returns a stream of form providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmAuthenticationFormProvidersGet(string realm);

    /// <summary>
    ///     Get form providers   Returns a stream of form providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmAuthenticationFormProvidersGetWithHttpInfo(string realm);

    /// <summary>
    ///     Get configuration descriptions for all clients
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Dictionary&lt;string, Object&gt;</returns>
    Dictionary<string, object> RealmAuthenticationPerClientConfigDescriptionGet(string realm);

    /// <summary>
    ///     Get configuration descriptions for all clients
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
    ApiResponse<Dictionary<string, object>> RealmAuthenticationPerClientConfigDescriptionGetWithHttpInfo(string realm);

    /// <summary>
    ///     Register a new required actions
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON containing &#x27;providerId&#x27;, and &#x27;name&#x27; attributes.</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmAuthenticationRegisterRequiredActionPost(Dictionary<string, object> body, string realm);

    /// <summary>
    ///     Register a new required actions
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON containing &#x27;providerId&#x27;, and &#x27;name&#x27; attributes.</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationRegisterRequiredActionPostWithHttpInfo(Dictionary<string, object> body,
        string realm);

    /// <summary>
    ///     Delete required action
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns></returns>
    void RealmAuthenticationRequiredActionsAliasDelete(string realm, string alias);

    /// <summary>
    ///     Delete required action
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationRequiredActionsAliasDeleteWithHttpInfo(string realm, string alias);

    /// <summary>
    ///     Get required action for alias
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>RequiredActionProviderRepresentation</returns>
    RequiredActionProviderRepresentation RealmAuthenticationRequiredActionsAliasGet(string realm, string alias);

    /// <summary>
    ///     Get required action for alias
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>ApiResponse of RequiredActionProviderRepresentation</returns>
    ApiResponse<RequiredActionProviderRepresentation> RealmAuthenticationRequiredActionsAliasGetWithHttpInfo(
        string realm, string alias);

    /// <summary>
    ///     Lower required action’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns></returns>
    void RealmAuthenticationRequiredActionsAliasLowerPriorityPost(string realm, string alias);

    /// <summary>
    ///     Lower required action’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object>
        RealmAuthenticationRequiredActionsAliasLowerPriorityPostWithHttpInfo(string realm, string alias);

    /// <summary>
    ///     Update required action
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON describing new state of required action</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns></returns>
    void RealmAuthenticationRequiredActionsAliasPut(RequiredActionProviderRepresentation body, string realm,
        string alias);

    /// <summary>
    ///     Update required action
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON describing new state of required action</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmAuthenticationRequiredActionsAliasPutWithHttpInfo(
        RequiredActionProviderRepresentation body, string realm, string alias);

    /// <summary>
    ///     Raise required action’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns></returns>
    void RealmAuthenticationRequiredActionsAliasRaisePriorityPost(string realm, string alias);

    /// <summary>
    ///     Raise required action’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object>
        RealmAuthenticationRequiredActionsAliasRaisePriorityPostWithHttpInfo(string realm, string alias);

    /// <summary>
    ///     Get required actions   Returns a stream of required actions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmAuthenticationRequiredActionsGet(string realm);

    /// <summary>
    ///     Get required actions   Returns a stream of required actions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmAuthenticationRequiredActionsGetWithHttpInfo(string realm);

    /// <summary>
    ///     Get unregistered required actions   Returns a stream of unregistered required actions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmAuthenticationUnregisteredRequiredActionsGet(string realm);

    /// <summary>
    ///     Get unregistered required actions   Returns a stream of unregistered required actions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>>
        RealmAuthenticationUnregisteredRequiredActionsGetWithHttpInfo(string realm);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Get authenticator providers   Returns a stream of authenticator providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmAuthenticationAuthenticatorProvidersGetAsync(string realm);

    /// <summary>
    ///     Get authenticator providers   Returns a stream of authenticator providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmAuthenticationAuthenticatorProvidersGetAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Get client authenticator providers   Returns a stream of client authenticator providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmAuthenticationClientAuthenticatorProvidersGetAsync(string realm);

    /// <summary>
    ///     Get client authenticator providers   Returns a stream of client authenticator providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmAuthenticationClientAuthenticatorProvidersGetAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Get authenticator provider’s configuration description
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="providerId"></param>
    /// <returns>Task of AuthenticatorConfigInfoRepresentation</returns>
    Task<AuthenticatorConfigInfoRepresentation> RealmAuthenticationConfigDescriptionProviderIdGetAsync(string realm,
        string providerId);

    /// <summary>
    ///     Get authenticator provider’s configuration description
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="providerId"></param>
    /// <returns>Task of ApiResponse (AuthenticatorConfigInfoRepresentation)</returns>
    Task<ApiResponse<AuthenticatorConfigInfoRepresentation>>
        RealmAuthenticationConfigDescriptionProviderIdGetAsyncWithHttpInfo(string realm, string providerId);

    /// <summary>
    ///     Delete authenticator configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Configuration id</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationConfigIdDeleteAsync(string realm, string id);

    /// <summary>
    ///     Delete authenticator configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Configuration id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationConfigIdDeleteAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get authenticator configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Configuration id</param>
    /// <returns>Task of AuthenticatorConfigRepresentation</returns>
    Task<AuthenticatorConfigRepresentation> RealmAuthenticationConfigIdGetAsync(string realm, string id);

    /// <summary>
    ///     Get authenticator configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Configuration id</param>
    /// <returns>Task of ApiResponse (AuthenticatorConfigRepresentation)</returns>
    Task<ApiResponse<AuthenticatorConfigRepresentation>> RealmAuthenticationConfigIdGetAsyncWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Update authenticator configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON describing new state of authenticator configuration</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Configuration id</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationConfigIdPutAsync(AuthenticatorConfigRepresentation body, string realm, string id);

    /// <summary>
    ///     Update authenticator configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON describing new state of authenticator configuration</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Configuration id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationConfigIdPutAsyncWithHttpInfo(AuthenticatorConfigRepresentation body,
        string realm, string id);

    /// <summary>
    ///     Update execution with new configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON with new configuration</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationExecutionsExecutionIdConfigPostAsync(AuthenticatorConfigRepresentation body, string realm,
        string executionId);

    /// <summary>
    ///     Update execution with new configuration
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON with new configuration</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationExecutionsExecutionIdConfigPostAsyncWithHttpInfo(
        AuthenticatorConfigRepresentation body, string realm, string executionId);

    /// <summary>
    ///     Delete execution
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationExecutionsExecutionIdDeleteAsync(string realm, string executionId);

    /// <summary>
    ///     Delete execution
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationExecutionsExecutionIdDeleteAsyncWithHttpInfo(string realm,
        string executionId);

    /// <summary>
    ///     Get Single Execution
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationExecutionsExecutionIdGetAsync(string realm, string executionId);

    /// <summary>
    ///     Get Single Execution
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationExecutionsExecutionIdGetAsyncWithHttpInfo(string realm,
        string executionId);

    /// <summary>
    ///     Lower execution’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationExecutionsExecutionIdLowerPriorityPostAsync(string realm, string executionId);

    /// <summary>
    ///     Lower execution’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationExecutionsExecutionIdLowerPriorityPostAsyncWithHttpInfo(string realm,
        string executionId);

    /// <summary>
    ///     Raise execution’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationExecutionsExecutionIdRaisePriorityPostAsync(string realm, string executionId);

    /// <summary>
    ///     Raise execution’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="executionId">Execution id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationExecutionsExecutionIdRaisePriorityPostAsyncWithHttpInfo(string realm,
        string executionId);

    /// <summary>
    ///     Add new authentication execution
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON model describing authentication execution</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationExecutionsPostAsync(AuthenticationExecutionRepresentation body, string realm);

    /// <summary>
    ///     Add new authentication execution
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON model describing authentication execution</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationExecutionsPostAsyncWithHttpInfo(
        AuthenticationExecutionRepresentation body, string realm);

    /// <summary>
    ///     Copy existing authentication flow under a new name   The new name is given as &#x27;newName&#x27; attribute of the
    ///     passed JSON object
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON containing &#x27;newName&#x27; attribute</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Name of the existing authentication flow</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationFlowsFlowAliasCopyPostAsync(Dictionary<string, object> body, string realm,
        string flowAlias);

    /// <summary>
    ///     Copy existing authentication flow under a new name   The new name is given as &#x27;newName&#x27; attribute of the
    ///     passed JSON object
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON containing &#x27;newName&#x27; attribute</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Name of the existing authentication flow</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationFlowsFlowAliasCopyPostAsyncWithHttpInfo(
        Dictionary<string, object> body, string realm, string flowAlias);

    /// <summary>
    ///     Add new authentication execution to a flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">New execution JSON data containing &#x27;provider&#x27; attribute</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Alias of parent flow</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationFlowsFlowAliasExecutionsExecutionPostAsync(Dictionary<string, object> body, string realm,
        string flowAlias);

    /// <summary>
    ///     Add new authentication execution to a flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">New execution JSON data containing &#x27;provider&#x27; attribute</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Alias of parent flow</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationFlowsFlowAliasExecutionsExecutionPostAsyncWithHttpInfo(
        Dictionary<string, object> body, string realm, string flowAlias);

    /// <summary>
    ///     Add new flow with new execution to existing flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">
    ///     New authentication flow / execution JSON data containing &#x27;alias&#x27;, &#x27;type&#x27;, &#x27;
    ///     provider&#x27;, and &#x27;description&#x27; attributes
    /// </param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Alias of parent authentication flow</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationFlowsFlowAliasExecutionsFlowPostAsync(Dictionary<string, object> body, string realm,
        string flowAlias);

    /// <summary>
    ///     Add new flow with new execution to existing flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">
    ///     New authentication flow / execution JSON data containing &#x27;alias&#x27;, &#x27;type&#x27;, &#x27;
    ///     provider&#x27;, and &#x27;description&#x27; attributes
    /// </param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Alias of parent authentication flow</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationFlowsFlowAliasExecutionsFlowPostAsyncWithHttpInfo(
        Dictionary<string, object> body, string realm, string flowAlias);

    /// <summary>
    ///     Get authentication executions for a flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Flow alias</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationFlowsFlowAliasExecutionsGetAsync(string realm, string flowAlias);

    /// <summary>
    ///     Get authentication executions for a flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Flow alias</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationFlowsFlowAliasExecutionsGetAsyncWithHttpInfo(string realm,
        string flowAlias);

    /// <summary>
    ///     Update authentication executions of a Flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">AuthenticationExecutionInfoRepresentation</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Flow alias</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationFlowsFlowAliasExecutionsPutAsync(AuthenticationExecutionInfoRepresentation body,
        string realm, string flowAlias);

    /// <summary>
    ///     Update authentication executions of a Flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">AuthenticationExecutionInfoRepresentation</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="flowAlias">Flow alias</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationFlowsFlowAliasExecutionsPutAsyncWithHttpInfo(
        AuthenticationExecutionInfoRepresentation body, string realm, string flowAlias);

    /// <summary>
    ///     Get authentication flows   Returns a stream of authentication flows.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmAuthenticationFlowsGetAsync(string realm);

    /// <summary>
    ///     Get authentication flows   Returns a stream of authentication flows.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmAuthenticationFlowsGetAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Delete an authentication flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Flow id</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationFlowsIdDeleteAsync(string realm, string id);

    /// <summary>
    ///     Delete an authentication flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Flow id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationFlowsIdDeleteAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get authentication flow for id
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Flow id</param>
    /// <returns>Task of AuthenticationFlowRepresentation</returns>
    Task<AuthenticationFlowRepresentation> RealmAuthenticationFlowsIdGetAsync(string realm, string id);

    /// <summary>
    ///     Get authentication flow for id
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Flow id</param>
    /// <returns>Task of ApiResponse (AuthenticationFlowRepresentation)</returns>
    Task<ApiResponse<AuthenticationFlowRepresentation>> RealmAuthenticationFlowsIdGetAsyncWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Update an authentication flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Authentication flow representation</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Flow id</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationFlowsIdPutAsync(AuthenticationFlowRepresentation body, string realm, string id);

    /// <summary>
    ///     Update an authentication flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Authentication flow representation</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">Flow id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationFlowsIdPutAsyncWithHttpInfo(AuthenticationFlowRepresentation body,
        string realm, string id);

    /// <summary>
    ///     Create a new authentication flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Authentication flow representation</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationFlowsPostAsync(AuthenticationFlowRepresentation body, string realm);

    /// <summary>
    ///     Create a new authentication flow
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">Authentication flow representation</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationFlowsPostAsyncWithHttpInfo(AuthenticationFlowRepresentation body,
        string realm);

    /// <summary>
    ///     Get form action providers   Returns a stream of form action providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmAuthenticationFormActionProvidersGetAsync(string realm);

    /// <summary>
    ///     Get form action providers   Returns a stream of form action providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmAuthenticationFormActionProvidersGetAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Get form providers   Returns a stream of form providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmAuthenticationFormProvidersGetAsync(string realm);

    /// <summary>
    ///     Get form providers   Returns a stream of form providers.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmAuthenticationFormProvidersGetAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Get configuration descriptions for all clients
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
    Task<Dictionary<string, object>> RealmAuthenticationPerClientConfigDescriptionGetAsync(string realm);

    /// <summary>
    ///     Get configuration descriptions for all clients
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
    Task<ApiResponse<Dictionary<string, object>>>
        RealmAuthenticationPerClientConfigDescriptionGetAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Register a new required actions
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON containing &#x27;providerId&#x27;, and &#x27;name&#x27; attributes.</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationRegisterRequiredActionPostAsync(Dictionary<string, object> body, string realm);

    /// <summary>
    ///     Register a new required actions
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON containing &#x27;providerId&#x27;, and &#x27;name&#x27; attributes.</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationRegisterRequiredActionPostAsyncWithHttpInfo(
        Dictionary<string, object> body, string realm);

    /// <summary>
    ///     Delete required action
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationRequiredActionsAliasDeleteAsync(string realm, string alias);

    /// <summary>
    ///     Delete required action
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>>
        RealmAuthenticationRequiredActionsAliasDeleteAsyncWithHttpInfo(string realm, string alias);

    /// <summary>
    ///     Get required action for alias
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>Task of RequiredActionProviderRepresentation</returns>
    Task<RequiredActionProviderRepresentation> RealmAuthenticationRequiredActionsAliasGetAsync(string realm,
        string alias);

    /// <summary>
    ///     Get required action for alias
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>Task of ApiResponse (RequiredActionProviderRepresentation)</returns>
    Task<ApiResponse<RequiredActionProviderRepresentation>> RealmAuthenticationRequiredActionsAliasGetAsyncWithHttpInfo(
        string realm, string alias);

    /// <summary>
    ///     Lower required action’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationRequiredActionsAliasLowerPriorityPostAsync(string realm, string alias);

    /// <summary>
    ///     Lower required action’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationRequiredActionsAliasLowerPriorityPostAsyncWithHttpInfo(string realm,
        string alias);

    /// <summary>
    ///     Update required action
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON describing new state of required action</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationRequiredActionsAliasPutAsync(RequiredActionProviderRepresentation body, string realm,
        string alias);

    /// <summary>
    ///     Update required action
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">JSON describing new state of required action</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationRequiredActionsAliasPutAsyncWithHttpInfo(
        RequiredActionProviderRepresentation body, string realm, string alias);

    /// <summary>
    ///     Raise required action’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>Task of void</returns>
    Task RealmAuthenticationRequiredActionsAliasRaisePriorityPostAsync(string realm, string alias);

    /// <summary>
    ///     Raise required action’s priority
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="alias">Alias of required action</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmAuthenticationRequiredActionsAliasRaisePriorityPostAsyncWithHttpInfo(string realm,
        string alias);

    /// <summary>
    ///     Get required actions   Returns a stream of required actions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmAuthenticationRequiredActionsGetAsync(string realm);

    /// <summary>
    ///     Get required actions   Returns a stream of required actions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmAuthenticationRequiredActionsGetAsyncWithHttpInfo(string realm);

    /// <summary>
    ///     Get unregistered required actions   Returns a stream of unregistered required actions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmAuthenticationUnregisteredRequiredActionsGetAsync(string realm);

    /// <summary>
    ///     Get unregistered required actions   Returns a stream of unregistered required actions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmAuthenticationUnregisteredRequiredActionsGetAsyncWithHttpInfo(string realm);

    #endregion Asynchronous Operations
}