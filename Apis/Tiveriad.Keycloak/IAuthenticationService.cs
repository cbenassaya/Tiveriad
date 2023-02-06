namespace Tiveriad.Keycloak;

public interface IAuthenticationService
{
    string AccessToken { get; }

    Task<bool> Connect( string userName, string password,
        CancellationToken cancellationToken = default);

    Task<bool> Connect(string clientSecret, CancellationToken cancellationToken = default);
}