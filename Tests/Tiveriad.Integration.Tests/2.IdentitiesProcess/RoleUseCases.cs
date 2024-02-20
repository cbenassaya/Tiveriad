using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Apis.Contracts.RoleContracts;
using Xunit;

namespace Tiveriad.Integration.Tests._2.IdentitiesProcess;

public class RoleUseCases : IntegrationTestBase
{
    [Fact]
    public async void PostAdminRole()
    {
        var client = GetRequiredService<HttpClient>();
        var organizations = Get<List<OrganizationReaderModelContract>>(client.GetAsync("/api/organizations?state=Validated").Result).Result;
        var role = new RoleWriterModelContract
        {
            Name = "Admin",
            Description = Faker.Lorem.Sentence(1)
        };
        
        var content =
            new StringContent(JsonSerializer.Serialize(role), Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync($"/api/organizations/{organizations.First().Id}/roles", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async void PostUserRole()
    {
        var client = GetRequiredService<HttpClient>();
        var organizations = Get<List<OrganizationReaderModelContract>>(client.GetAsync("/api/organizations?state=Validated").Result).Result;
        var role = new RoleWriterModelContract
        {
            Name = "User",
            Description = Faker.Lorem.Sentence(1)
        };
        
        var content =
            new StringContent(JsonSerializer.Serialize(role), Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync($"/api/organizations/{organizations.First().Id}/roles", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
}