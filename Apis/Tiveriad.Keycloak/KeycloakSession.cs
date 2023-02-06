namespace Tiveriad.Keycloak;

public class KeycloakSession
{
    private readonly Func<string> _getToken;
    private readonly object _lockObject = new();
    public KeycloakSession(string basePath, Func<string> getToken)
    {
        BasePath = basePath;
        _getToken = getToken;
    }

    public string BasePath { get; }

    public string Token { get; private set; }

    public void RenewToken()
    {
        lock(_lockObject)
            Token = _getToken();
    } 
}