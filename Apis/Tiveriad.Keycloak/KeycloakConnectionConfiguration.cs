namespace Tiveriad.Keycloak;

public class KeycloakConnectionConfiguration
{
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string UrlBase { get; private set; }
    public string ClientSecret { get; private set; }

    public KeycloakConnectionConfiguration SetUrlBase(string urlBase)
    {
        UrlBase = urlBase;
        return this;
    }

    public KeycloakConnectionConfiguration SetCredential(string username, string password)
    {
        Username = username;
        Password = password;
        return this;
    }

    public KeycloakConnectionConfiguration SetCredential(string clientSecret)
    {
        ClientSecret = clientSecret;
        return this;
    }
}