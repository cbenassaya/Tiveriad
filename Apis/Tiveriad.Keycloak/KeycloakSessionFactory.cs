namespace Tiveriad.Keycloak;

public class KeycloakSessionFactory : IKeycloakSessionFactory
{
    private readonly KeycloakConnectionConfiguration _configuration;
    private readonly Func<string> _getToken;
    private readonly object _lockObject = new();
    private KeycloakSession? _session;

    private KeycloakSessionFactory(KeycloakConnectionConfiguration configuration)
    {
        var authenticationService = new AuthenticationService(configuration.UrlBase);
        _configuration = configuration;

        if (!string.IsNullOrEmpty(configuration.ClientSecret))
            _getToken = () =>
                authenticationService.Connect(configuration.ClientSecret).Result
                    ? authenticationService.AccessToken
                    : string.Empty;
        else
            _getToken = () =>
                authenticationService.Connect(configuration.Username, configuration.Password)
                    .Result
                    ? authenticationService.AccessToken
                    : string.Empty;
    }

    public static KeycloakConnectionConfigurator Configurator => new();


    public KeycloakSession GetSession()
    {
        lock (_lockObject)
        {
            if (_session != null) return _session;
            _session = new KeycloakSession($"{_configuration.UrlBase}/auth/admin/realms", _getToken);
            _session.RenewToken();
            return _session;
        }
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

        public IKeycloakSessionFactory Build()
        {
            if (_configuration.UrlBase == null) throw new ArgumentNullException("Host configuration is mandatory !");

            return new KeycloakSessionFactory(_configuration);
        }
    }
}