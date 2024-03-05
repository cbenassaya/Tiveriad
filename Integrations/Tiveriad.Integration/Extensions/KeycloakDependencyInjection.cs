#region

using Tiveriad.Integration.Infrastructure.Services;
using Tiveriad.Keycloak;
using Tiveriad.Keycloak.Apis;
using Tiveriad.Keycloak.Services;

#endregion

namespace Tiveriad.Integration.Extensions;

public static class KeycloakDependencyInjection
{
    public static IServiceCollection AddKeycloak(this IServiceCollection services)
    {
        services.AddSingleton<KeycloakConfigurationService>();

        var configuration = services
            .BuildServiceProvider()
            .GetRequiredService<KeycloakConfigurationService>();

        var uriBuilder = new UriBuilder
        {
            Scheme = configuration.Scheme,
            Host = configuration.Hostname
        };
        var factory = KeycloakSessionFactory.Configurator.Get(x =>
        {
            x.SetCredential(configuration.Username, configuration.Password).SetUrlBase(uriBuilder.Uri.ToString());
        }).Build();

        services.AddSingleton(factory);

        services.AddSingleton(x =>
        {
            var httpClient = new HttpClient();

            var uriBuilder = new UriBuilder
            {
                Scheme = configuration.Scheme,
                Host = configuration.Hostname,
                Path = configuration.Path
            };
            httpClient.BaseAddress = uriBuilder.Uri;
            return httpClient;
        });

        services.AddScoped<IRoleApi, RoleApi>();
        services.AddScoped<IUserApi, UserApi>();
        services.AddScoped<IRoleMapperApi, RoleMapperApi>();

        return services;
    }
}