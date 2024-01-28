namespace Tiveriad.Integration.Infrastructure.Services;

public class KeycloakConfigurationService
{
    private readonly IConfiguration _configuration;

    public KeycloakConfigurationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string? Hostname => Environment.GetEnvironmentVariable("KEYCLOAKSERVICE_HOSTNAME") ??
                               _configuration.GetSection("KeycloakService").GetSection("Hostname").Value;

    public string? Port => Environment.GetEnvironmentVariable("KEYCLOAKSERVICE_PORT") ??
                           _configuration.GetSection("KeycloakService").GetSection("Port").Value;

    public string? Scheme => Environment.GetEnvironmentVariable("KEYCLOAKSERVICE_SCHEME") ??
                             _configuration.GetSection("KeycloakService").GetSection("Scheme").Value;
    
    public string? Path => Environment.GetEnvironmentVariable("KEYCLOAKSERVICE_PATH") ??
                              _configuration.GetSection("KeycloakService").GetSection("Path").Value;

    public string? Realm => Environment.GetEnvironmentVariable("KEYCLOAKSERVICE_REALM") ??
                            _configuration.GetSection("KeycloakService").GetSection("Realm").Value;

    public string? Username => Environment.GetEnvironmentVariable("KEYCLOAKSERVICE_USERNAME") ??
                               _configuration.GetSection("KeycloakService").GetSection("Username").Value;

    public string? Password => Environment.GetEnvironmentVariable("KEYCLOAKSERVICE_PASSWORD") ??
                               _configuration.GetSection("KeycloakService").GetSection("Password").Value;
    
    public string? MasterRealm => Environment.GetEnvironmentVariable("KEYCLOAKSERVICE_MASTERREALM") ??
                                  _configuration.GetSection("KeycloakService").GetSection("MasterRealm").Value;
    
    public string? ClientSecret => Environment.GetEnvironmentVariable("KEYCLOAKSERVICE_CLIENTSECRET") ??
                                   _configuration.GetSection("KeycloakService").GetSection("ClientSecret").Value;
    
    public string? ClientId => Environment.GetEnvironmentVariable("KEYCLOAKSERVICE_CLIENTID") ??
                               _configuration.GetSection("KeycloakService").GetSection("ClientId").Value;

}