#region

using System.Net;
using Tiveriad.Commons.HttpApis;
using Tiveriad.Keycloak.Apis;
using Tiveriad.Keycloak.Models;

#endregion

namespace Tiveriad.Keycloak.Services;

public class UsersApi : BaseApi, IUsersApi
{
    public UsersApi(HttpClient httpClient, IKeycloakSessionFactory keycloakSessionFactory) : base(httpClient,
        keycloakSessionFactory)
    {
    }

        /// <summary>
        ///  Get representation of the user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="id"></param>
        /// <returns>Task of ApiResponse (UserRepresentation)</returns>
        public  Task<ApiResponse<UserRepresentation>> GetUserByRealmBy (string realm, string id)
        {
            // verify the required parameter 'realm' is set
            if (realm == null)
                throw new ApiException(400, "Missing required parameter 'realm' when calling UsersApi->GetUserByRealmById");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling UsersApi->GetUserByRealmById");
            
            
            return   Execute(async (apiClient, token) =>
            {
                HttpResponseMessage result = await apiClient.GetAsync( builder =>
                {
                    builder
                        .Header(h => h.Authorization("Bearer", token))
                        .AppendPath($"/{realm}/users/{id}");
                });
                return new ApiResponse<UserRepresentation>((int)result.StatusCode,
                    result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                    await result.DeserializeAsync<UserRepresentation>().ConfigureAwait(false));
            });
        }
        
        
                /// <summary>
        ///  
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="id"></param>
        /// <param name="briefRepresentation"> (optional)</param>
        /// <param name="first"> (optional)</param>
        /// <param name="max"> (optional)</param>
        /// <param name="search"> (optional)</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        public  Task<ApiResponse<List<object>>> GetUserGroups (string realm, string id,  bool briefRepresentation = true,  int? first = null,  int? max =  null, string search = null)
        {
            // verify the required parameter 'realm' is set
            if (realm == null)
                throw new ApiException(400, "Missing required parameter 'realm' when calling UsersApi->GetUserGroups");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling UsersApi->GetUserGroups");
            
            
            
            return   Execute(async (apiClient, token) =>
            {
                HttpResponseMessage result = await apiClient.GetAsync( builder =>
                {
                    builder
                        .Header(h => h.Authorization("Bearer", token))
                        .QueryString("briefRepresentation", briefRepresentation)
                        .QueryString( "first", first)
                        .QueryString( "max", max)
                        .QueryStringIf(()=>!string.IsNullOrEmpty(search), "search", search)
                        .AppendPath($"/{realm}/users/{id}/groups");
                });
                return new ApiResponse<List<object>>((int)result.StatusCode,
                    result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                    await result.DeserializeAsync<List<object>>().ConfigureAwait(false));
            });


        }
                
        /// <summary>
        ///  Get users Returns a stream of users, filtered according to query parameters.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="briefRepresentation">Boolean which defines whether brief representations are returned (default: false) (optional)</param>
        /// <param name="email">A String contained in email, or the complete email, if param &amp;quot;exact&amp;quot; is true (optional)</param>
        /// <param name="emailVerified">whether the email has been verified (optional)</param>
        /// <param name="enabled">Boolean representing if user is enabled or not (optional)</param>
        /// <param name="exact">Boolean which defines whether the params &amp;quot;last&amp;quot;, &amp;quot;first&amp;quot;, &amp;quot;email&amp;quot; and &amp;quot;username&amp;quot; must match exactly (optional)</param>
        /// <param name="first">Pagination offset (optional)</param>
        /// <param name="firstName">A String contained in firstName, or the complete firstName, if param &amp;quot;exact&amp;quot; is true (optional)</param>
        /// <param name="idpAlias">The alias of an Identity Provider linked to the user (optional)</param>
        /// <param name="idpUserId">The userId at an Identity Provider linked to the user (optional)</param>
        /// <param name="lastName">A String contained in lastName, or the complete lastName, if param &amp;quot;exact&amp;quot; is true (optional)</param>
        /// <param name="max">Maximum results size (defaults to 100) (optional)</param>
        /// <param name="q">A query to search for custom attributes, in the format &#x27;key1:value2 key2:value2&#x27; (optional)</param>
        /// <param name="search">A String contained in username, first or last name, or email. Default search behavior is prefix-based (e.g., foo or foo*). Use foo for infix search and &amp;quot;foo&amp;quot; for exact search. (optional)</param>
        /// <param name="username">A String contained in username, or the complete username, if param &amp;quot;exact&amp;quot; is true (optional)</param>
        /// <returns>Task of ApiResponse (UserRepresentation)</returns>
        public Task<ApiResponse<List<UserRepresentation>>> GetUsersByRealm (string realm, bool briefRepresentation = true, string email = null, string emailVerified = null, bool? enabled = null, bool? exact = null,  int? first = null, string firstName = null, string idpAlias = null, string idpUserId = null, string lastName = null,  int? max = null, string q = null, string search = null, string username = null)
        {
            // verify the required parameter 'realm' is set
            if (realm == null)
                throw new ApiException(400, "Missing required parameter 'realm' when calling UsersApi->GetUsersByRealm");
            
            
            return   Execute(async (apiClient, token) =>
            {
                HttpResponseMessage result = await apiClient.GetAsync( builder =>
                {
                    builder
                        .Header(h => h.Authorization("Bearer", token))
                        .QueryString("briefRepresentation", briefRepresentation)
                        .QueryString( "first", first)
                        .QueryString( "max", max)
                        .QueryStringIf(()=>!string.IsNullOrEmpty(search), "search", search)
                        .QueryStringIf(()=>!string.IsNullOrEmpty(email), "email", email)
                        .QueryStringIf(()=>!string.IsNullOrEmpty(emailVerified), "emailVerified", emailVerified)
                        .QueryStringIf(()=>enabled!=null, "enabled", enabled)
                        .QueryStringIf(()=>exact!=null, "exact", exact)
                        .QueryStringIf(()=>!string.IsNullOrEmpty(firstName), "firstName", firstName)
                        .QueryStringIf(()=>!string.IsNullOrEmpty(idpAlias), "idpAlias", idpAlias)
                        .QueryStringIf(()=>!string.IsNullOrEmpty(idpUserId), "idpUserId", idpUserId)
                        .QueryStringIf(()=>!string.IsNullOrEmpty(lastName), "lastName", lastName)
                        .QueryStringIf(()=>!string.IsNullOrEmpty(q), "q", q)
                        .QueryStringIf(()=>!string.IsNullOrEmpty(username), "username", username)
                        .AppendPath($"/{realm}/users");
                });
                return new ApiResponse<List<UserRepresentation>>((int)result.StatusCode,
                    result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                    await result.DeserializeAsync<List<UserRepresentation>>().ConfigureAwait(false));
            });
            
            
        }


        /// <summary>
        ///  Remove all user sessions associated with the user Also send notification to all clients that have an admin URL to invalidate the sessions for the particular user.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="id"></param>
        /// <returns>Task of ApiResponse</returns>
        public Task<ApiResponse<bool>> PostLogout(string realm, string id)
        {
            // verify the required parameter 'realm' is set
            if (realm == null)
                throw new ApiException(400, "Missing required parameter 'realm' when calling UsersApi->PostLogout");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling UsersApi->PostLogout");

            return Execute(async (apiClient, token) =>
            {
                HttpResponseMessage result = await apiClient.PostAsync(builder =>
                {
                    builder
                        .Header(h => h.Authorization("Bearer", token))
                        .AppendPath($"/{realm}/users/{id}/logout");
                });
                return new ApiResponse<bool>((int)result.StatusCode,
                    result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                    result.IsSuccessStatusCode && result.StatusCode == HttpStatusCode.Created);
            });

        }
        
        /// <summary>
        ///  Create a new user Username must be unique.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="body">UserRepresentation (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Task<ApiResponse<bool>> PostUser (string realm, UserRepresentation body)
        {
            // verify the required parameter 'realm' is set
            if (realm == null)
                throw new ApiException(400, "Missing required parameter 'realm' when calling UsersApi->PostUser");
            // verify the required parameter 'realm' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling UsersApi->PostUser");
            
            return Execute(async (apiClient, token) =>
            {
                HttpResponseMessage result = await apiClient.PostAsync(builder =>
                {
                    builder
                        .Header(h => h.Authorization("Bearer", token))
                        .Content(body)
                        .AppendPath($"/{realm}/users");
                });
      
                return new ApiResponse<bool>((int)result.StatusCode,
                    result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                    result.IsSuccessStatusCode && result.StatusCode == HttpStatusCode.Created);
            });

        }



        /// <summary>
        ///  Update the user
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="id"></param>
        /// <param name="body">UserRepresentation (optional)</param>
        /// <returns>Task of ApiResponse</returns>
        public Task<ApiResponse<bool>> PutUser (string realm, string id, UserRepresentation body)
        {
            // verify the required parameter 'realm' is set
            if (realm == null)
                throw new ApiException(400, "Missing required parameter 'realm' when calling UsersApi->PutUser");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling UsersApi->PutUser");
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling UsersApi->PostUser");
            
            return Execute(async (apiClient, token) =>
            {
                HttpResponseMessage result = await apiClient.PutAsync(builder =>
                {
                    builder
                        .Header(h => h.Authorization("Bearer", token))
                        .Content(body)
                        .AppendPath($"/{realm}/users/{id}");
                });
                return new ApiResponse<bool>((int)result.StatusCode,
                    result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                    result.IsSuccessStatusCode && result.StatusCode == HttpStatusCode.OK);
            });

        }
        
        
        /// <summary>
        ///  PutUserGroup
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="realm">realm name (not id!)</param>
        /// <param name="id"></param>
        /// <param name="groupId"></param>
        /// <returns>bool</returns>
        public Task<ApiResponse<bool>> PutUserGroup (string realm, string id, string groupId)
        {
            // verify the required parameter 'realm' is set
            if (realm == null)
                throw new ApiException(400, "Missing required parameter 'realm' when calling UsersApi->PutUserGroup");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling UsersApi->PutUserGroup");
            // verify the required parameter 'groupId' is set
            if (groupId == null)
                throw new ApiException(400, "Missing required parameter 'groupId' when calling UsersApi->PutUserGroup");
                        
            return Execute(async (apiClient, token) =>
            {
                HttpResponseMessage result = await apiClient.PutAsync(builder =>
                {
                    builder
                        .Header(h => h.Authorization("Bearer", token))
                        .AppendPath($"/{realm}/users/{id}/groups/{groupId}");
                });
                return new ApiResponse<bool>((int)result.StatusCode,
                    result.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                    result.IsSuccessStatusCode && result.StatusCode == HttpStatusCode.NoContent);
            });

        }


}