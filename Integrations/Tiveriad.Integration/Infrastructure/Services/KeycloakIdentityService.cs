#region

using System.Text.Json;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Keycloak.Apis;
using Tiveriad.Keycloak.Models;

#endregion

namespace Tiveriad.Integration.Infrastructure.Services;

public class KeycloakIdentityService 
{
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly KeycloakConfigurationService _keycloakConfigurationService;
    private readonly ILogger<KeycloakIdentityService> _logger;
    private readonly IUserApi _userApi;


    public KeycloakIdentityService(ILogger<KeycloakIdentityService> logger, IUserApi userApi,
        KeycloakConfigurationService keycloakConfigurationService)
    {
        _logger = logger;
        _userApi = userApi;
        _keycloakConfigurationService = keycloakConfigurationService;
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };
    }

    public async Task Update(User user, Organization organization)
    {
        var userRepresentionApiReponse = await _userApi.GetUsersByRealm("kodin-dev-realm", false, user.Email);
        var userReprensentation = userRepresentionApiReponse?.Data?.FirstOrDefault();

        if (userReprensentation != null)
        {
            _logger.LogInformation($"User {user.Email} already exists");
            userReprensentation.Attributes ??= new Dictionary<string, object>();
            userReprensentation.Attributes["organization"] = JsonSerializer.Serialize(organization);
            if (userReprensentation.Attributes.ContainsKey("organizations"))
            {
                var organizations = JsonSerializer.Deserialize<List<Organization>>(
                    userReprensentation.Attributes["organizations"].ToString() ?? string.Empty, _jsonSerializerOptions);
                organizations ??= new List<Organization>();
                if (!organizations.Contains(organization))
                    organizations.Add(organization);
                userReprensentation.Attributes["organizations"] = JsonSerializer.Serialize(organizations);
            }
            else
            {
                userReprensentation.Attributes["organizations"] =
                    JsonSerializer.Serialize(new List<Organization> { organization });
            }

            return;
        }

        userReprensentation = new UserRepresentation
        {
            Email = user.Email,
            FirstName = user.Firstname,
            LastName = user.Lastname,
            Username = user.Username,
            Credentials = new List<CredentialRepresentation>
            {
                new()
                {
                    Type = "password",
                    Value = user.Password,
                    Temporary = false
                }
            },
            Attributes = new Dictionary<string, object>
            {
                { "organization", JsonSerializer.Serialize(organization) },
                { "organizations", JsonSerializer.Serialize(new List<Organization> { organization }) },
                { "locale", user.Locale }
            },
            Enabled = true,
            EmailVerified = true
        };

        await _userApi.PostUser(_keycloakConfigurationService.Realm, userReprensentation);
    }
}

