using Tiveriad.Keycloak.Client;

namespace Tiveriad.Keycloak;

public interface IKeycloakConnectionFactory
{
    Configuration GetConfiguration();
}