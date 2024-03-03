using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Identities.Apis.Contracts.FeatureContracts;
using Tiveriad.Identities.Apis.Contracts.RealmContracts;
using Xunit;

namespace Tiveriad.Integration.Tests._2.IdentitiesProcess;

public class FeatureUseCases: IntegrationTestBase
{
    [Fact]
    public async void PostNewFeature()
    {
        var client = GetRequiredService<HttpClient>();
        var realms = Get<List<RealmReaderModelContract>>(client.GetAsync("/api/realms").Result).Result;
        

        var feature = new FeatureWriterModelContract()
        {
            Name = Faker.Company.Name(),
            Code = Faker.Company.Suffix(),
            RealmId = realms.First().Id
        };
        
        var content =
            
            new StringContent(JsonSerializer.Serialize(feature), Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync($"/api/realms/{realms.First().Id}/features", content );
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}