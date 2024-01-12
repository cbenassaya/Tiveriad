#region

using Tiveriad.Keycloak.Models;

#endregion

namespace Tiveriad.Keycloak.Apis;

public interface IUserApi
{
    /// <summary>
    ///     Get representation of the user
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse (UserRepresentation)</returns>
    Task<ApiResponse<UserRepresentation>> GetUserByRealmBy(string realm, string id);

    /// <summary>
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="briefRepresentation"> (optional)</param>
    /// <param name="first"> (optional)</param>
    /// <param name="max"> (optional)</param>
    /// <param name="search"> (optional)</param>
    /// <returns>Task of ApiResponse (Object)</returns>
    Task<ApiResponse<List<object>>> GetUserGroups(string realm, string id, bool briefRepresentation = true,
        int? first = null, int? max = null, string search = null);

    /// <summary>
    ///     Get users Returns a stream of users, filtered according to query parameters.
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="briefRepresentation">
    ///     Boolean which defines whether brief representations are returned (default: false)
    ///     (optional)
    /// </param>
    /// <param name="email">
    ///     A String contained in email, or the complete email, if param &amp;quot;exact&amp;quot; is true
    ///     (optional)
    /// </param>
    /// <param name="emailVerified">whether the email has been verified (optional)</param>
    /// <param name="enabled">Boolean representing if user is enabled or not (optional)</param>
    /// <param name="exact">
    ///     Boolean which defines whether the params &amp;quot;last&amp;quot;, &amp;quot;first&amp;quot;, &amp;
    ///     quot;email&amp;quot; and &amp;quot;username&amp;quot; must match exactly (optional)
    /// </param>
    /// <param name="first">Pagination offset (optional)</param>
    /// <param name="firstName">
    ///     A String contained in firstName, or the complete firstName, if param &amp;quot;exact&amp;quot;
    ///     is true (optional)
    /// </param>
    /// <param name="idpAlias">The alias of an Identity Provider linked to the user (optional)</param>
    /// <param name="idpUserId">The userId at an Identity Provider linked to the user (optional)</param>
    /// <param name="lastName">
    ///     A String contained in lastName, or the complete lastName, if param &amp;quot;exact&amp;quot; is
    ///     true (optional)
    /// </param>
    /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
    /// <param name="q">A query to search for custom attributes, in the format &#x27;key1:value2 key2:value2&#x27; (optional)</param>
    /// <param name="search">
    ///     A String contained in username, first or last name, or email. Default search behavior is
    ///     prefix-based (e.g., foo or foo*). Use foo for infix search and &amp;quot;foo&amp;quot; for exact search. (optional)
    /// </param>
    /// <param name="username">
    ///     A String contained in username, or the complete username, if param &amp;quot;exact&amp;quot; is
    ///     true (optional)
    /// </param>
    /// <returns>Task of ApiResponse (Object)</returns>
    Task<ApiResponse<List<UserRepresentation>>> GetUsersByRealm(string realm, bool briefRepresentation = true,
        string? email = null, bool? emailVerified = null, bool? enabled = null, bool? exact = null, int? first = null,
        string? firstName = null, string? idpAlias = null, string? idpUserId = null, string? lastName = null,
        int? max = null, string? q = null, string? search = null, string? username = null);

    /// <summary>
    ///     Remove all user sessions associated with the user Also send notification to all clients that have an admin URL to
    ///     invalidate the sessions for the particular user.
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<bool>> PostLogout(string realm, string id);

    /// <summary>
    ///     Create a new user Username must be unique.
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="body">UserRepresentation (optional)</param>
    /// <returns>ApiResponse of Object(void)</returns>
    Task<ApiResponse<bool>> PostUser(string realm, UserRepresentation body);

    /// <summary>
    ///     Update the user
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="body">UserRepresentation (optional)</param>
    /// <returns>Task of ApiResponse</returns>
    Task<ApiResponse<bool>> PutUser(string realm, string id, UserRepresentation body);

    /// <summary>
    ///     PutUserGroup
    /// </summary>
    /// <exception cref="ApiException">Thrown when fails to make API call</exception>
    /// <param name="realm">realm name (not id!)</param>
    /// <param name="id"></param>
    /// <param name="groupId"></param>
    /// <returns>bool</returns>
    Task<ApiResponse<bool>> PutUserGroup(string realm, string id, string groupId);
}