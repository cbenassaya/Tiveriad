using Microsoft.Extensions.DependencyInjection;
using Tiveriad.Commons.Extensions;
using Tiveriad.Keycloak.Apis;
using Tiveriad.Keycloak.Models;
using Tiveriad.Keycloak.Services;
using Tiveriad.UnitTests;
using Xunit;

namespace Tiveriad.Keycloak.Tests;

public class Startup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        var factory = KeycloakSessionFactory.Configurator.Get(x =>
        {
            x.SetCredential("admin_user", "HlAe!26!BtLt").SetUrlBase("https://secure.kodin.info");
        }).Build();

        services.AddSingleton<IKeycloakSessionFactory>(factory);
        
        
        services.AddScoped<HttpClient>( x =>
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://secure.kodin.info/auth/admin/realms/");
            return httpClient;
        });
        
        services.AddScoped<IRolesApi, RolesApi>();
        services.AddScoped<IUsersApi, UsersApi>();
        services.AddScoped<IRoleMapperApi, RoleMapperApi>();
        
    }
}


public class UserTestModule : TestBase<Startup>
{
    [Fact]
    public async Task Add_User()
    {
        IUsersApi? usersApi = GetService<IUsersApi>();
        var result = await usersApi.PostUser("kodin-dev-realm", new UserRepresentation()
        {
            Email = "charles.benassaya@gmail.com",
            FirstName = "Charles",
            LastName = "Benassaya",
            Username = "charles.benassaya@gmail.com",
            Credentials = new List<CredentialRepresentation>()
            {
                new CredentialRepresentation()
                {
                    Type = "password",
                    Value = "J5x5omsg",
                    Temporary = false
                }
            },
            Attributes = new Dictionary<string, object>()
            {
                {"tenantId", "natan"},
                {"tenantIds", new List<string>() {"one", "two"}},
                {"locale", "fr"}
            },
            Enabled = true,
            EmailVerified = true
        });
        Assert.True(result.Data);
    }
    
    [Fact]
    public async Task Get_User()
    {
        IUsersApi? usersApi = GetService<IUsersApi>();
        var response = await usersApi.GetUsersByRealm("kodin-dev-realm", false, "charles.benassaya@gmail.com", first: 0, max:10);
        var result = response.Data.FirstOrDefault();
        
        Assert.True(response.Data!=null);
    }
    
    
    [Fact]
    public async Task Put_User()
    {
        IUsersApi? usersApi = GetService<IUsersApi>();
        var response = await usersApi.GetUsersByRealm("kodin-dev-realm", false, "charles.benassaya@gmail.com", first: 0, max:10);
        var result = response.Data.FirstOrDefault();
        
        Assert.True(response.Data!=null);
    }
}