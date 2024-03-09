using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Identities.Apis.Contracts.FeatureContracts;
using Tiveriad.Identities.Apis.Contracts.RealmContracts;
using Xunit;
using Xunit.Abstractions;

namespace Tiveriad.Identities.Tests.NominalTests;

public class FeatureUseCases: IntegrationTestBase
{
    private readonly ITestOutputHelper _testOutputHelper;

    public FeatureUseCases(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async void PostNewFeature()
    {
        
        var client = GetRequiredService<HttpClient>();
        
        var realms = await Get<PagedResult<RealmReaderModelContract>>("/realms",response =>
        {
            _testOutputHelper.WriteLine(response.StatusCode.ToString());
            _testOutputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
            _testOutputHelper.WriteLine(response.Headers.ToString());
        });

        var feature = new FeatureWriterModelContract()
        {
            Name = Faker.Company.Name(),
            Code = Faker.Company.Suffix(),
            RealmId = realms.Items.First().Id
        };
        
        var content =
            
            new StringContent(JsonSerializer.Serialize(feature), Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync($"/realms/{ realms.Items.First().Id}/features", content );
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}