using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Identities.Apis.Contracts.FeatureContracts;
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Apis.Contracts.PolicyContracts;
using Tiveriad.Identities.Apis.Contracts.RealmContracts;
using Tiveriad.Identities.Apis.Contracts.RoleContracts;
using Xunit;

namespace Tiveriad.Integration.Tests._2.IdentitiesProcess;

public class PolicyUseCases : IntegrationTestBase
{
    [Fact]
    public async void PostNewPolicy()
    {
        var client = GetRequiredService<HttpClient>();
        var organizations = Get<List<OrganizationReaderModelContract>>(client.GetAsync("/api/organizations?state=Validated").Result).Result;
        var realms = Get<List<RealmReaderModelContract>>(client.GetAsync("/api/realms").Result).Result;
        var roles = Get<List<RoleReaderModelContract>>(client.GetAsync($"/api/organizations/{organizations.First().Id}/roles").Result).Result;
        var features = Get<List<FeatureReaderModelContract>>(client.GetAsync($"/api/realms/{realms.First().Id}/features").Result).Result;
        
        
        var policy = new PolicyWriterModelContract
        {
            RealmId = realms.First().Id,
            RoleId = roles.First().Id,
            FeaturesId = features.Select(x=>x.Id).ToList()
        };
        
        var content =
            
            new StringContent(JsonSerializer.Serialize(policy), Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"/api/realms/{realms.First().Id}/roles/{roles.First().Id}/policies", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}