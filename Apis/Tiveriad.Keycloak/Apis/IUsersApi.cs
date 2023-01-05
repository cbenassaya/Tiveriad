using Tiveriad.Keycloak.Models;

namespace Tiveriad.Keycloak.Apis;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IUsersApi : IApiAccessor
{
    #region Synchronous Operations

    /// <summary>
    ///     Returns the number of users that match the given criteria.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="email">email filter (optional)</param>
    /// <param name="emailVerified"> (optional)</param>
    /// <param name="firstName">first name filter (optional)</param>
    /// <param name="lastName">last name filter (optional)</param>
    /// <param name="search">arbitrary search string for all the fields below (optional)</param>
    /// <param name="username">username filter (optional)</param>
    /// <returns>int?</returns>
    int? RealmUsersCountGet(string realm, string email = null, bool? emailVerified = null, string firstName = null,
        string lastName = null, string search = null, string username = null);

    /// <summary>
    ///     Returns the number of users that match the given criteria.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="email">email filter (optional)</param>
    /// <param name="emailVerified"> (optional)</param>
    /// <param name="firstName">first name filter (optional)</param>
    /// <param name="lastName">last name filter (optional)</param>
    /// <param name="search">arbitrary search string for all the fields below (optional)</param>
    /// <param name="username">username filter (optional)</param>
    /// <returns>ApiResponse of int?</returns>
    ApiResponse<int?> RealmUsersCountGetWithHttpInfo(string realm, string email = null, bool? emailVerified = null,
        string firstName = null, string lastName = null, string search = null, string username = null);

    /// <summary>
    ///     Get users   Returns a stream of users, filtered according to query parameters.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="briefRepresentation">
    ///     Boolean which defines whether brief representations are returned (default: false)
    ///     (optional)
    /// </param>
    /// <param name="email">A String contained in email, or the complete email, if param \&quot;exact\&quot; is true (optional)</param>
    /// <param name="emailVerified">whether the email has been verified (optional)</param>
    /// <param name="enabled">Boolean representing if user is enabled or not (optional)</param>
    /// <param name="exact">
    ///     Boolean which defines whether the params \&quot;last\&quot;, \&quot;first\&quot;, \&quot;email\
    ///     &quot; and \&quot;username\&quot; must match exactly (optional)
    /// </param>
    /// <param name="first">Pagination offset (optional)</param>
    /// <param name="firstName">
    ///     A String contained in firstName, or the complete firstName, if param \&quot;exact\&quot; is
    ///     true (optional)
    /// </param>
    /// <param name="idpAlias">The alias of an Identity Provider linked to the user (optional)</param>
    /// <param name="idpUserId">The userId at an Identity Provider linked to the user (optional)</param>
    /// <param name="lastName">
    ///     A String contained in lastName, or the complete lastName, if param \&quot;exact\&quot; is true
    ///     (optional)
    /// </param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="q">A query to search for custom attributes, in the format &#x27;key1:value2 key2:value2&#x27; (optional)</param>
    /// <param name="search">A String contained in username, first or last name, or email (optional)</param>
    /// <param name="username">
    ///     A String contained in username, or the complete username, if param \&quot;exact\&quot; is true
    ///     (optional)
    /// </param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmUsersGet(string realm, bool? briefRepresentation = null, string email = null,
        bool? emailVerified = null, bool? enabled = null, bool? exact = null, int? first = null,
        string firstName = null, string idpAlias = null, string idpUserId = null, string lastName = null,
        int? max = null, string q = null, string search = null, string username = null);

    /// <summary>
    ///     Get users   Returns a stream of users, filtered according to query parameters.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="briefRepresentation">
    ///     Boolean which defines whether brief representations are returned (default: false)
    ///     (optional)
    /// </param>
    /// <param name="email">A String contained in email, or the complete email, if param \&quot;exact\&quot; is true (optional)</param>
    /// <param name="emailVerified">whether the email has been verified (optional)</param>
    /// <param name="enabled">Boolean representing if user is enabled or not (optional)</param>
    /// <param name="exact">
    ///     Boolean which defines whether the params \&quot;last\&quot;, \&quot;first\&quot;, \&quot;email\
    ///     &quot; and \&quot;username\&quot; must match exactly (optional)
    /// </param>
    /// <param name="first">Pagination offset (optional)</param>
    /// <param name="firstName">
    ///     A String contained in firstName, or the complete firstName, if param \&quot;exact\&quot; is
    ///     true (optional)
    /// </param>
    /// <param name="idpAlias">The alias of an Identity Provider linked to the user (optional)</param>
    /// <param name="idpUserId">The userId at an Identity Provider linked to the user (optional)</param>
    /// <param name="lastName">
    ///     A String contained in lastName, or the complete lastName, if param \&quot;exact\&quot; is true
    ///     (optional)
    /// </param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="q">A query to search for custom attributes, in the format &#x27;key1:value2 key2:value2&#x27; (optional)</param>
    /// <param name="search">A String contained in username, first or last name, or email (optional)</param>
    /// <param name="username">
    ///     A String contained in username, or the complete username, if param \&quot;exact\&quot; is true
    ///     (optional)
    /// </param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmUsersGetWithHttpInfo(string realm,
        bool? briefRepresentation = null, string email = null, bool? emailVerified = null, bool? enabled = null,
        bool? exact = null, int? first = null, string firstName = null, string idpAlias = null, string idpUserId = null,
        string lastName = null, int? max = null, string q = null, string search = null, string username = null);

    /// <summary>
    ///     Return credential types, which are provided by the user storage where user is stored.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmUsersIdConfiguredUserStorageCredentialTypesGet(string realm, string id);

    /// <summary>
    ///     Return credential types, which are provided by the user storage where user is stored.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmUsersIdConfiguredUserStorageCredentialTypesGetWithHttpInfo(
        string realm, string id);

    /// <summary>
    ///     Revoke consent and offline tokens for particular client from user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client">Client id</param>
    /// <returns></returns>
    void RealmUsersIdConsentsClientDelete(string realm, string id, string _client);

    /// <summary>
    ///     Revoke consent and offline tokens for particular client from user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client">Client id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdConsentsClientDeleteWithHttpInfo(string realm, string id, string _client);

    /// <summary>
    ///     Get consents granted by the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmUsersIdConsentsGet(string realm, string id);

    /// <summary>
    ///     Get consents granted by the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmUsersIdConsentsGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Remove a credential for a user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId"></param>
    /// <returns></returns>
    void RealmUsersIdCredentialsCredentialIdDelete(string realm, string id, string credentialId);

    /// <summary>
    ///     Remove a credential for a user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdCredentialsCredentialIdDeleteWithHttpInfo(string realm, string id,
        string credentialId);

    /// <summary>
    ///     Move a credential to a position behind another credential
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId">The credential to move</param>
    /// <param name="newPreviousCredentialId">
    ///     The credential that will be the previous element in the list. If set to null, the
    ///     moved credential will be the first element in the list.
    /// </param>
    /// <returns></returns>
    void RealmUsersIdCredentialsCredentialIdMoveAfterNewPreviousCredentialIdPost(string realm, string id,
        string credentialId, string newPreviousCredentialId);

    /// <summary>
    ///     Move a credential to a position behind another credential
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId">The credential to move</param>
    /// <param name="newPreviousCredentialId">
    ///     The credential that will be the previous element in the list. If set to null, the
    ///     moved credential will be the first element in the list.
    /// </param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdCredentialsCredentialIdMoveAfterNewPreviousCredentialIdPostWithHttpInfo(
        string realm, string id, string credentialId, string newPreviousCredentialId);

    /// <summary>
    ///     Move a credential to a first position in the credentials list of the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId">The credential to move</param>
    /// <returns></returns>
    void RealmUsersIdCredentialsCredentialIdMoveToFirstPost(string realm, string id, string credentialId);

    /// <summary>
    ///     Move a credential to a first position in the credentials list of the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId">The credential to move</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdCredentialsCredentialIdMoveToFirstPostWithHttpInfo(string realm, string id,
        string credentialId);

    /// <summary>
    ///     Update a credential label for a user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId"></param>
    /// <returns></returns>
    void RealmUsersIdCredentialsCredentialIdUserLabelPut(string body, string realm, string id, string credentialId);

    /// <summary>
    ///     Update a credential label for a user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdCredentialsCredentialIdUserLabelPutWithHttpInfo(string body, string realm,
        string id, string credentialId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmUsersIdCredentialsGet(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmUsersIdCredentialsGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Delete the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns></returns>
    void RealmUsersIdDelete(string realm, string id);

    /// <summary>
    ///     Delete the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdDeleteWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Disable all credentials for a user of a specific type
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns></returns>
    void RealmUsersIdDisableCredentialTypesPut(List<string> body, string realm, string id);

    /// <summary>
    ///     Disable all credentials for a user of a specific type
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdDisableCredentialTypesPutWithHttpInfo(List<string> body, string realm, string id);

    /// <summary>
    ///     Send a update account email to the user   An email contains a link the user can click to perform a set of required
    ///     actions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">required actions the user needs to complete</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="clientId">Client id (optional)</param>
    /// <param name="lifespan">Number of seconds after which the generated token expires (optional)</param>
    /// <param name="redirectUri">Redirect uri (optional)</param>
    /// <returns></returns>
    void RealmUsersIdExecuteActionsEmailPut(List<string> body, string realm, string id, string clientId = null,
        int? lifespan = null, string redirectUri = null);

    /// <summary>
    ///     Send a update account email to the user   An email contains a link the user can click to perform a set of required
    ///     actions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">required actions the user needs to complete</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="clientId">Client id (optional)</param>
    /// <param name="lifespan">Number of seconds after which the generated token expires (optional)</param>
    /// <param name="redirectUri">Redirect uri (optional)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdExecuteActionsEmailPutWithHttpInfo(List<string> body, string realm, string id,
        string clientId = null, int? lifespan = null, string redirectUri = null);

    /// <summary>
    ///     Get social logins associated with the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmUsersIdFederatedIdentityGet(string realm, string id);

    /// <summary>
    ///     Get social logins associated with the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmUsersIdFederatedIdentityGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Remove a social login provider from user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="provider">Social login provider id</param>
    /// <returns></returns>
    void RealmUsersIdFederatedIdentityProviderDelete(string realm, string id, string provider);

    /// <summary>
    ///     Remove a social login provider from user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="provider">Social login provider id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdFederatedIdentityProviderDeleteWithHttpInfo(string realm, string id,
        string provider);

    /// <summary>
    ///     Add a social login provider to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="provider">Social login provider id</param>
    /// <returns></returns>
    void RealmUsersIdFederatedIdentityProviderPost(FederatedIdentityRepresentation body, string realm, string id,
        string provider);

    /// <summary>
    ///     Add a social login provider to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="provider">Social login provider id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdFederatedIdentityProviderPostWithHttpInfo(FederatedIdentityRepresentation body,
        string realm, string id, string provider);

    /// <summary>
    ///     Get representation of the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>UserRepresentation</returns>
    UserRepresentation RealmUsersIdGet(string realm, string id);

    /// <summary>
    ///     Get representation of the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of UserRepresentation</returns>
    ApiResponse<UserRepresentation> RealmUsersIdGetWithHttpInfo(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="search"> (optional)</param>
    /// <returns>Dictionary&lt;string, Object&gt;</returns>
    Dictionary<string, object> RealmUsersIdGroupsCountGet(string realm, string id, string search = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="search"> (optional)</param>
    /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
    ApiResponse<Dictionary<string, object>> RealmUsersIdGroupsCountGetWithHttpInfo(string realm, string id,
        string search = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmUsersIdGroupsGet(string realm, string id, bool? briefRepresentation = null,
        int? first = null, int? max = null, string search = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmUsersIdGroupsGetWithHttpInfo(string realm, string id,
        bool? briefRepresentation = null, int? first = null, int? max = null, string search = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="groupId"></param>
    /// <returns></returns>
    void RealmUsersIdGroupsGroupIdDelete(string realm, string id, string groupId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="groupId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdGroupsGroupIdDeleteWithHttpInfo(string realm, string id, string groupId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="groupId"></param>
    /// <returns></returns>
    void RealmUsersIdGroupsGroupIdPut(string realm, string id, string groupId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="groupId"></param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdGroupsGroupIdPutWithHttpInfo(string realm, string id, string groupId);

    /// <summary>
    ///     Impersonate the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Dictionary&lt;string, Object&gt;</returns>
    Dictionary<string, object> RealmUsersIdImpersonationPost(string realm, string id);

    /// <summary>
    ///     Impersonate the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of Dictionary&lt;string, Object&gt;</returns>
    ApiResponse<Dictionary<string, object>> RealmUsersIdImpersonationPostWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Remove all user sessions associated with the user   Also send notification to all clients that have an admin URL to
    ///     invalidate the sessions for the particular user.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns></returns>
    void RealmUsersIdLogoutPost(string realm, string id);

    /// <summary>
    ///     Remove all user sessions associated with the user   Also send notification to all clients that have an admin URL to
    ///     invalidate the sessions for the particular user.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdLogoutPostWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get offline sessions associated with the user and client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="clientUuid"></param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmUsersIdOfflineSessionsClientUuidGet(string realm, string id,
        string clientUuid);

    /// <summary>
    ///     Get offline sessions associated with the user and client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="clientUuid"></param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmUsersIdOfflineSessionsClientUuidGetWithHttpInfo(string realm,
        string id, string clientUuid);

    /// <summary>
    ///     Update the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns></returns>
    void RealmUsersIdPut(UserRepresentation body, string realm, string id);

    /// <summary>
    ///     Update the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdPutWithHttpInfo(UserRepresentation body, string realm, string id);

    /// <summary>
    ///     Set up a new password for the user.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">The representation must contain a rawPassword with the plain-text password</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns></returns>
    void RealmUsersIdResetPasswordPut(CredentialRepresentation body, string realm, string id);

    /// <summary>
    ///     Set up a new password for the user.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">The representation must contain a rawPassword with the plain-text password</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object>
        RealmUsersIdResetPasswordPutWithHttpInfo(CredentialRepresentation body, string realm, string id);

    /// <summary>
    ///     Send an email-verification email to the user   An email contains a link the user can click to verify their email
    ///     address.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="clientId">Client id (optional)</param>
    /// <param name="redirectUri">Redirect uri (optional)</param>
    /// <returns></returns>
    void RealmUsersIdSendVerifyEmailPut(string realm, string id, string clientId = null, string redirectUri = null);

    /// <summary>
    ///     Send an email-verification email to the user   An email contains a link the user can click to verify their email
    ///     address.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="clientId">Client id (optional)</param>
    /// <param name="redirectUri">Redirect uri (optional)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersIdSendVerifyEmailPutWithHttpInfo(string realm, string id, string clientId = null,
        string redirectUri = null);

    /// <summary>
    ///     Get sessions associated with the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    List<Dictionary<string, object>> RealmUsersIdSessionsGet(string realm, string id);

    /// <summary>
    ///     Get sessions associated with the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>ApiResponse of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    ApiResponse<List<Dictionary<string, object>>> RealmUsersIdSessionsGetWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Create a new user   Username must be unique.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmUsersPost(UserRepresentation body, string realm);

    /// <summary>
    ///     Create a new user   Username must be unique.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersPostWithHttpInfo(UserRepresentation body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>string</returns>
    string RealmUsersProfileGet(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of string</returns>
    ApiResponse<string> RealmUsersProfileGetWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns></returns>
    void RealmUsersProfilePut(string body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    ApiResponse<object> RealmUsersProfilePutWithHttpInfo(string body, string realm);

    #endregion Synchronous Operations

    #region Asynchronous Operations

    /// <summary>
    ///     Returns the number of users that match the given criteria.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="email">email filter (optional)</param>
    /// <param name="emailVerified"> (optional)</param>
    /// <param name="firstName">first name filter (optional)</param>
    /// <param name="lastName">last name filter (optional)</param>
    /// <param name="search">arbitrary search string for all the fields below (optional)</param>
    /// <param name="username">username filter (optional)</param>
    /// <returns>Task of int?</returns>
    Task<int?> RealmUsersCountGetAsync(string realm, string email = null, bool? emailVerified = null,
        string firstName = null, string lastName = null, string search = null, string username = null);

    /// <summary>
    ///     Returns the number of users that match the given criteria.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="email">email filter (optional)</param>
    /// <param name="emailVerified"> (optional)</param>
    /// <param name="firstName">first name filter (optional)</param>
    /// <param name="lastName">last name filter (optional)</param>
    /// <param name="search">arbitrary search string for all the fields below (optional)</param>
    /// <param name="username">username filter (optional)</param>
    /// <returns>Task of ApiResponse (int?)</returns>
    Task<ApiResponse<int?>> RealmUsersCountGetAsyncWithHttpInfo(string realm, string email = null,
        bool? emailVerified = null, string firstName = null, string lastName = null, string search = null,
        string username = null);

    /// <summary>
    ///     Get users   Returns a stream of users, filtered according to query parameters.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="briefRepresentation">
    ///     Boolean which defines whether brief representations are returned (default: false)
    ///     (optional)
    /// </param>
    /// <param name="email">A String contained in email, or the complete email, if param \&quot;exact\&quot; is true (optional)</param>
    /// <param name="emailVerified">whether the email has been verified (optional)</param>
    /// <param name="enabled">Boolean representing if user is enabled or not (optional)</param>
    /// <param name="exact">
    ///     Boolean which defines whether the params \&quot;last\&quot;, \&quot;first\&quot;, \&quot;email\
    ///     &quot; and \&quot;username\&quot; must match exactly (optional)
    /// </param>
    /// <param name="first">Pagination offset (optional)</param>
    /// <param name="firstName">
    ///     A String contained in firstName, or the complete firstName, if param \&quot;exact\&quot; is
    ///     true (optional)
    /// </param>
    /// <param name="idpAlias">The alias of an Identity Provider linked to the user (optional)</param>
    /// <param name="idpUserId">The userId at an Identity Provider linked to the user (optional)</param>
    /// <param name="lastName">
    ///     A String contained in lastName, or the complete lastName, if param \&quot;exact\&quot; is true
    ///     (optional)
    /// </param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="q">A query to search for custom attributes, in the format &#x27;key1:value2 key2:value2&#x27; (optional)</param>
    /// <param name="search">A String contained in username, first or last name, or email (optional)</param>
    /// <param name="username">
    ///     A String contained in username, or the complete username, if param \&quot;exact\&quot; is true
    ///     (optional)
    /// </param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmUsersGetAsync(string realm, bool? briefRepresentation = null,
        string email = null, bool? emailVerified = null, bool? enabled = null, bool? exact = null, int? first = null,
        string firstName = null, string idpAlias = null, string idpUserId = null, string lastName = null,
        int? max = null, string q = null, string search = null, string username = null);

    /// <summary>
    ///     Get users   Returns a stream of users, filtered according to query parameters.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="briefRepresentation">
    ///     Boolean which defines whether brief representations are returned (default: false)
    ///     (optional)
    /// </param>
    /// <param name="email">A String contained in email, or the complete email, if param \&quot;exact\&quot; is true (optional)</param>
    /// <param name="emailVerified">whether the email has been verified (optional)</param>
    /// <param name="enabled">Boolean representing if user is enabled or not (optional)</param>
    /// <param name="exact">
    ///     Boolean which defines whether the params \&quot;last\&quot;, \&quot;first\&quot;, \&quot;email\
    ///     &quot; and \&quot;username\&quot; must match exactly (optional)
    /// </param>
    /// <param name="first">Pagination offset (optional)</param>
    /// <param name="firstName">
    ///     A String contained in firstName, or the complete firstName, if param \&quot;exact\&quot; is
    ///     true (optional)
    /// </param>
    /// <param name="idpAlias">The alias of an Identity Provider linked to the user (optional)</param>
    /// <param name="idpUserId">The userId at an Identity Provider linked to the user (optional)</param>
    /// <param name="lastName">
    ///     A String contained in lastName, or the complete lastName, if param \&quot;exact\&quot; is true
    ///     (optional)
    /// </param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="q">A query to search for custom attributes, in the format &#x27;key1:value2 key2:value2&#x27; (optional)</param>
    /// <param name="search">A String contained in username, first or last name, or email (optional)</param>
    /// <param name="username">
    ///     A String contained in username, or the complete username, if param \&quot;exact\&quot; is true
    ///     (optional)
    /// </param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmUsersGetAsyncWithHttpInfo(string realm,
        bool? briefRepresentation = null, string email = null, bool? emailVerified = null, bool? enabled = null,
        bool? exact = null, int? first = null, string firstName = null, string idpAlias = null, string idpUserId = null,
        string lastName = null, int? max = null, string q = null, string search = null, string username = null);

    /// <summary>
    ///     Return credential types, which are provided by the user storage where user is stored.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmUsersIdConfiguredUserStorageCredentialTypesGetAsync(string realm,
        string id);

    /// <summary>
    ///     Return credential types, which are provided by the user storage where user is stored.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>>
        RealmUsersIdConfiguredUserStorageCredentialTypesGetAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Revoke consent and offline tokens for particular client from user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client">Client id</param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdConsentsClientDeleteAsync(string realm, string id, string _client);

    /// <summary>
    ///     Revoke consent and offline tokens for particular client from user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="_client">Client id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>>
        RealmUsersIdConsentsClientDeleteAsyncWithHttpInfo(string realm, string id, string _client);

    /// <summary>
    ///     Get consents granted by the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmUsersIdConsentsGetAsync(string realm, string id);

    /// <summary>
    ///     Get consents granted by the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmUsersIdConsentsGetAsyncWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Remove a credential for a user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId"></param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdCredentialsCredentialIdDeleteAsync(string realm, string id, string credentialId);

    /// <summary>
    ///     Remove a credential for a user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdCredentialsCredentialIdDeleteAsyncWithHttpInfo(string realm, string id,
        string credentialId);

    /// <summary>
    ///     Move a credential to a position behind another credential
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId">The credential to move</param>
    /// <param name="newPreviousCredentialId">
    ///     The credential that will be the previous element in the list. If set to null, the
    ///     moved credential will be the first element in the list.
    /// </param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdCredentialsCredentialIdMoveAfterNewPreviousCredentialIdPostAsync(string realm, string id,
        string credentialId, string newPreviousCredentialId);

    /// <summary>
    ///     Move a credential to a position behind another credential
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId">The credential to move</param>
    /// <param name="newPreviousCredentialId">
    ///     The credential that will be the previous element in the list. If set to null, the
    ///     moved credential will be the first element in the list.
    /// </param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdCredentialsCredentialIdMoveAfterNewPreviousCredentialIdPostAsyncWithHttpInfo(
        string realm, string id, string credentialId, string newPreviousCredentialId);

    /// <summary>
    ///     Move a credential to a first position in the credentials list of the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId">The credential to move</param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdCredentialsCredentialIdMoveToFirstPostAsync(string realm, string id, string credentialId);

    /// <summary>
    ///     Move a credential to a first position in the credentials list of the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId">The credential to move</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdCredentialsCredentialIdMoveToFirstPostAsyncWithHttpInfo(string realm,
        string id, string credentialId);

    /// <summary>
    ///     Update a credential label for a user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId"></param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdCredentialsCredentialIdUserLabelPutAsync(string body, string realm, string id,
        string credentialId);

    /// <summary>
    ///     Update a credential label for a user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="credentialId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdCredentialsCredentialIdUserLabelPutAsyncWithHttpInfo(string body,
        string realm, string id, string credentialId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmUsersIdCredentialsGetAsync(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmUsersIdCredentialsGetAsyncWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Delete the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdDeleteAsync(string realm, string id);

    /// <summary>
    ///     Delete the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdDeleteAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Disable all credentials for a user of a specific type
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdDisableCredentialTypesPutAsync(List<string> body, string realm, string id);

    /// <summary>
    ///     Disable all credentials for a user of a specific type
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdDisableCredentialTypesPutAsyncWithHttpInfo(List<string> body, string realm,
        string id);

    /// <summary>
    ///     Send a update account email to the user   An email contains a link the user can click to perform a set of required
    ///     actions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">required actions the user needs to complete</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="clientId">Client id (optional)</param>
    /// <param name="lifespan">Number of seconds after which the generated token expires (optional)</param>
    /// <param name="redirectUri">Redirect uri (optional)</param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdExecuteActionsEmailPutAsync(List<string> body, string realm, string id, string clientId = null,
        int? lifespan = null, string redirectUri = null);

    /// <summary>
    ///     Send a update account email to the user   An email contains a link the user can click to perform a set of required
    ///     actions.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">required actions the user needs to complete</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="clientId">Client id (optional)</param>
    /// <param name="lifespan">Number of seconds after which the generated token expires (optional)</param>
    /// <param name="redirectUri">Redirect uri (optional)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdExecuteActionsEmailPutAsyncWithHttpInfo(List<string> body, string realm,
        string id, string clientId = null, int? lifespan = null, string redirectUri = null);

    /// <summary>
    ///     Get social logins associated with the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmUsersIdFederatedIdentityGetAsync(string realm, string id);

    /// <summary>
    ///     Get social logins associated with the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmUsersIdFederatedIdentityGetAsyncWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Remove a social login provider from user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="provider">Social login provider id</param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdFederatedIdentityProviderDeleteAsync(string realm, string id, string provider);

    /// <summary>
    ///     Remove a social login provider from user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="provider">Social login provider id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdFederatedIdentityProviderDeleteAsyncWithHttpInfo(string realm, string id,
        string provider);

    /// <summary>
    ///     Add a social login provider to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="provider">Social login provider id</param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdFederatedIdentityProviderPostAsync(FederatedIdentityRepresentation body, string realm, string id,
        string provider);

    /// <summary>
    ///     Add a social login provider to the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="provider">Social login provider id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdFederatedIdentityProviderPostAsyncWithHttpInfo(
        FederatedIdentityRepresentation body, string realm, string id, string provider);

    /// <summary>
    ///     Get representation of the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of UserRepresentation</returns>
    Task<UserRepresentation> RealmUsersIdGetAsync(string realm, string id);

    /// <summary>
    ///     Get representation of the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse (UserRepresentation)</returns>
    Task<ApiResponse<UserRepresentation>> RealmUsersIdGetAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="search"> (optional)</param>
    /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
    Task<Dictionary<string, object>> RealmUsersIdGroupsCountGetAsync(string realm, string id, string search = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="search"> (optional)</param>
    /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
    Task<ApiResponse<Dictionary<string, object>>> RealmUsersIdGroupsCountGetAsyncWithHttpInfo(string realm, string id,
        string search = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmUsersIdGroupsGetAsync(string realm, string id,
        bool? briefRepresentation = null, int? first = null, int? max = null, string search = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmUsersIdGroupsGetAsyncWithHttpInfo(string realm, string id,
        bool? briefRepresentation = null, int? first = null, int? max = null, string search = null);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="groupId"></param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdGroupsGroupIdDeleteAsync(string realm, string id, string groupId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="groupId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdGroupsGroupIdDeleteAsyncWithHttpInfo(string realm, string id, string groupId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="groupId"></param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdGroupsGroupIdPutAsync(string realm, string id, string groupId);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="groupId"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdGroupsGroupIdPutAsyncWithHttpInfo(string realm, string id, string groupId);

    /// <summary>
    ///     Impersonate the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of Dictionary&lt;string, Object&gt;</returns>
    Task<Dictionary<string, object>> RealmUsersIdImpersonationPostAsync(string realm, string id);

    /// <summary>
    ///     Impersonate the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse (Dictionary&lt;string, Object&gt;)</returns>
    Task<ApiResponse<Dictionary<string, object>>> RealmUsersIdImpersonationPostAsyncWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Remove all user sessions associated with the user   Also send notification to all clients that have an admin URL to
    ///     invalidate the sessions for the particular user.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdLogoutPostAsync(string realm, string id);

    /// <summary>
    ///     Remove all user sessions associated with the user   Also send notification to all clients that have an admin URL to
    ///     invalidate the sessions for the particular user.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdLogoutPostAsyncWithHttpInfo(string realm, string id);

    /// <summary>
    ///     Get offline sessions associated with the user and client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="clientUuid"></param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmUsersIdOfflineSessionsClientUuidGetAsync(string realm, string id,
        string clientUuid);

    /// <summary>
    ///     Get offline sessions associated with the user and client
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="clientUuid"></param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmUsersIdOfflineSessionsClientUuidGetAsyncWithHttpInfo(
        string realm, string id, string clientUuid);

    /// <summary>
    ///     Update the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdPutAsync(UserRepresentation body, string realm, string id);

    /// <summary>
    ///     Update the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdPutAsyncWithHttpInfo(UserRepresentation body, string realm, string id);

    /// <summary>
    ///     Set up a new password for the user.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">The representation must contain a rawPassword with the plain-text password</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdResetPasswordPutAsync(CredentialRepresentation body, string realm, string id);

    /// <summary>
    ///     Set up a new password for the user.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body">The representation must contain a rawPassword with the plain-text password</param>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdResetPasswordPutAsyncWithHttpInfo(CredentialRepresentation body, string realm,
        string id);

    /// <summary>
    ///     Send an email-verification email to the user   An email contains a link the user can click to verify their email
    ///     address.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="clientId">Client id (optional)</param>
    /// <param name="redirectUri">Redirect uri (optional)</param>
    /// <returns>Task of void</returns>
    Task RealmUsersIdSendVerifyEmailPutAsync(string realm, string id, string clientId = null,
        string redirectUri = null);

    /// <summary>
    ///     Send an email-verification email to the user   An email contains a link the user can click to verify their email
    ///     address.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <param name="clientId">Client id (optional)</param>
    /// <param name="redirectUri">Redirect uri (optional)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersIdSendVerifyEmailPutAsyncWithHttpInfo(string realm, string id,
        string clientId = null, string redirectUri = null);

    /// <summary>
    ///     Get sessions associated with the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of List&lt;Dictionary&lt;string, Object&gt;&gt;</returns>
    Task<List<Dictionary<string, object>>> RealmUsersIdSessionsGetAsync(string realm, string id);

    /// <summary>
    ///     Get sessions associated with the user
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id">User id</param>
    /// <returns>Task of ApiResponse (List&lt;Dictionary&lt;string, Object&gt;&gt;)</returns>
    Task<ApiResponse<List<Dictionary<string, object>>>> RealmUsersIdSessionsGetAsyncWithHttpInfo(string realm,
        string id);

    /// <summary>
    ///     Create a new user   Username must be unique.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmUsersPostAsync(UserRepresentation body, string realm);

    /// <summary>
    ///     Create a new user   Username must be unique.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersPostAsyncWithHttpInfo(UserRepresentation body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of string</returns>
    Task<string> RealmUsersProfileGetAsync(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse (string)</returns>
    Task<ApiResponse<string>> RealmUsersProfileGetAsyncWithHttpInfo(string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of void</returns>
    Task RealmUsersProfilePutAsync(string body, string realm);

    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="body"></param>
    /// <param name="realm">realm name (not id!)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<object>> RealmUsersProfilePutAsyncWithHttpInfo(string body, string realm);

    #endregion Asynchronous Operations
}