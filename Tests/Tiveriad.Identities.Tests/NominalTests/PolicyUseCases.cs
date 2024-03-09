using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Identities.Apis.Contracts.FeatureContracts;
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Apis.Contracts.PolicyContracts;
using Tiveriad.Identities.Apis.Contracts.RealmContracts;
using Tiveriad.Identities.Apis.Contracts.RoleContracts;
using Xunit;
using Xunit.Abstractions;

namespace Tiveriad.Identities.Tests.NominalTests;

public class PolicyUseCases : IntegrationTestBase
{
    private readonly ITestOutputHelper _testOutputHelper;

    public PolicyUseCases(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async void PostNewPolicy()
    {
        var client = GetRequiredService<HttpClient>();
        
        var organizations = await Get<PagedResult<OrganizationReaderModelContract>>("/organizations?state=validated",response =>
        {
            _testOutputHelper.WriteLine(response.StatusCode.ToString());
            _testOutputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
            _testOutputHelper.WriteLine(response.Headers.ToString());
        });
        
        var roles = await Get<PagedResult<OrganizationReaderModelContract>>("/roles",response =>
        {
            _testOutputHelper.WriteLine(response.StatusCode.ToString());
            _testOutputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
            _testOutputHelper.WriteLine(response.Headers.ToString());
        });
        
        var realms = await Get<PagedResult<RealmReaderModelContract>>("/realms",response =>
        {
            _testOutputHelper.WriteLine(response.StatusCode.ToString());
            _testOutputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
            _testOutputHelper.WriteLine(response.Headers.ToString());
        });
        
        var features = await Get<PagedResult<FeatureReaderModelContract>>($"/realms/{realms.Items.First().Id}/features",response =>
        {
            _testOutputHelper.WriteLine(response.StatusCode.ToString());
            _testOutputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
            _testOutputHelper.WriteLine(response.Headers.ToString());
        });
        
        var policy = new PolicyWriterModelContract
        {
            RealmId = realms.Items.First().Id,
            RoleId = roles.Items.First().Id,
            FeaturesId = features.Items.Select(x=>x.Id).ToList()
        };
        
        var content =
            new StringContent(JsonSerializer.Serialize(policy), Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"/realms/{realms.Items.First().Id}/roles/{roles.Items.First().Id}/policies", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}