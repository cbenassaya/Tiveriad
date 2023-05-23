namespace Tiveriad.Keycloak;

public interface IKeycloakSessionFactory
{
    KeycloakSession GetSession();
}