using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Apis.Contracts.RoleContracts;
using Xunit;
using Xunit.Abstractions;

namespace Tiveriad.Identities.Tests.NominalTests;

public class RoleUseCases : IntegrationTestBase
{
    private readonly ITestOutputHelper _testOutputHelper;
    [Fact]
    public async void PostAdminRole()
    {
        var client = GetRequiredService<HttpClient>();

        var role = new RoleWriterModelContract
        {
            Name = "Admin",
            Description = Faker.Lorem.Sentence(1),
            Code = Faker.Company.Suffix(),
        };
        
        var content =
            new StringContent(JsonSerializer.Serialize(role), Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync($"/roles", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async void PostUserRole()
    {
        var client = GetRequiredService<HttpClient>();
        var role = new RoleWriterModelContract
        {
            Name = "User",
            Description = Faker.Lorem.Sentence(1)
        };
        
        var content =
            new StringContent(JsonSerializer.Serialize(role), Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync($"/roles", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
}