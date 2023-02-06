using Newtonsoft.Json.Linq;
using Tiveriad.Commons.HttpApis;

namespace Tiveriad.Keycloak;

public class AuthenticationService : IAuthenticationService
{
    private string _url;
    
    public AuthenticationService(string url)
    {
        _url = url;
    }

    public string AccessToken { get; private set; }

    public async Task<bool> Connect( string userName, string password,
        CancellationToken cancellationToken = default)
    {
        var apiClient = new ApiClient(new HttpClient(){ BaseAddress =  new Uri(_url, UriKind.Absolute)});
        var result = await apiClient.PostAsync(builder =>
        {
            builder
                .AppendPath("auth/realms/master/protocol/openid-connect/token")
                .Header(x => x.Accept("application/json"))
                .FormValue("grant_type", "password")
                .FormValue("username", userName)
                .FormValue("password", password)
                .FormValue("client_id", "admin-cli");
        });

        if (!result.IsSuccessStatusCode) return false;
        var values = JObject.Parse(await result.Content.ReadAsStringAsync(cancellationToken));
        AccessToken = values?.GetValue("access_token")?.Value<string>() ?? string.Empty;
        return !string.IsNullOrEmpty(AccessToken);
    }

    public async Task<bool> Connect(string clientSecret, CancellationToken cancellationToken = default)
    {
        var apiClient = new ApiClient(new HttpClient(){ BaseAddress =  new Uri(_url, UriKind.Absolute)});
        var result = await apiClient.PostAsync(builder =>
        {
            builder
                .AppendPath("auth/realms/master/protocol/openid-connect/token")
                .Header(x => x.Accept("application/json"))
                .FormValue("grant_type", "client_credentials")
                .FormValue("username", clientSecret)
                .FormValue("client_id", "admin-cli");
        });

        if (!result.IsSuccessStatusCode) return false;
        var values = JObject.Parse(await result.Content.ReadAsStringAsync(cancellationToken));
        AccessToken = values?.GetValue("access_token")?.Value<string>() ?? string.Empty;
        return !string.IsNullOrEmpty(AccessToken);
    }
}