using Tiveriad.Keycloak.Client;

namespace Tiveriad.Keycloak;

public class KeycloakConnectionFactory : IKeycloakConnectionFactory
{
    private readonly IAuthenticationService _authenticationService;
    private readonly KeycloakConnectionConfiguration _configuration;
    private readonly Func<string> _getToken;

    public static KeycloakConnectionConfigurator Configurator => new KeycloakConnectionConfigurator();

    private KeycloakConnectionFactory(KeycloakConnectionConfiguration configuration)
    {
        _authenticationService = new AuthenticationService(configuration.UrlBase);
        _configuration = configuration;
        
        if (!string.IsNullOrEmpty(configuration.ClientSecret))
            _getToken = () =>
                _authenticationService.Connect(configuration.ClientSecret).Result
                    ? _authenticationService.AccessToken
                    : string.Empty;
        else
            _getToken = () =>
                _authenticationService.Connect( configuration.Username, configuration.Password)
                    .Result
                    ? _authenticationService.AccessToken
                    : string.Empty;
    }


    public Configuration GetConfiguration()
    {
        return new Configuration()
        {
            BasePath = $"{_configuration.UrlBase}/auth/admin/realms",
            AccessToken = _getToken()
        };
    }
    
    
    public class KeycloakConnectionConfigurator
    {
        
        private KeycloakConnectionConfiguration _configuration;
        
        public KeycloakConnectionConfigurator Get(Action<KeycloakConnectionConfiguration> action)
        {
            _configuration = new KeycloakConnectionConfiguration();
            action(_configuration);
            return this;
        }

        public KeycloakConnectionFactory Build()
        {
            if (_configuration.UrlBase == null) throw new ArgumentNullException("Host configuration is mandatory !");
            
            return new KeycloakConnectionFactory(_configuration);
        }
    }
}