using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Identities.Apis.Contracts.RealmContracts;
using Xunit;

namespace Tiveriad.Integration.Tests._2.IdentitiesProcess;

public class RealmUseCases: IntegrationTestBase
{
    [Fact]
    public async void PostNewRealm()
    {
        var client = GetRequiredService<HttpClient>();

        var realm = new RealmWriterModelContract
        {
            Name = Faker.Company.Name(),
            Description = Faker.Lorem.Sentence(3)
        };
        
        var content =
            
            new StringContent(JsonSerializer.Serialize(realm), Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync($"/api/realms", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}