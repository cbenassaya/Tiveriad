using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Apis.Contracts.RealmContracts;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Tiveriad.Identities.Core.Entities;
using Xunit;
using Xunit.Abstractions;

namespace Tiveriad.Identities.Tests.NominalTests;

public class OrganizationUseCases: IntegrationTestBase
{
    private readonly ITestOutputHelper _testOutputHelper;

    public OrganizationUseCases(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async void PostNewOrganization()
    {
        var client = GetRequiredService<HttpClient>();
        var users = await Get<PagedResult<UserReaderModelContract>>("/users",response =>
        {
            _testOutputHelper.WriteLine(response.StatusCode.ToString());
            _testOutputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
            _testOutputHelper.WriteLine(response.Headers.ToString());
        });
        
        var organization = new OrganizationWriterModelContract
        {
            Name = Faker.Company.Name(),
            Domain = Faker.Internet.DomainName(),
            OwnerId = users.Items.First().Id,
            TimeZone = "Europe/Paris",
            Description = Faker.Lorem.Sentence(3)
        };
        

        
        var content =
            new StringContent(JsonSerializer.Serialize(organization), Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync("/organizations", content );
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Fact]
    public async void PutValidateOrganization()
    {
        var client = GetRequiredService<HttpClient>();      
        var organizations = await Get<PagedResult<OrganizationReaderModelContract>>("/organizations?state=pending",response =>
        {
            _testOutputHelper.WriteLine(response.StatusCode.ToString());
            _testOutputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
            _testOutputHelper.WriteLine(response.Headers.ToString());
        });
        var organizationEvent = new OrganizationEventModelContract
        {
            Event = OrganizationEvent.Validate
        };
        var content =
            new StringContent(JsonSerializer.Serialize(organizationEvent), Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"organizations/{organizations.Items.First().Id}/events", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
    }

    [Fact]
    public async void GetAllValidateOrganizations()
    {
        var client = GetRequiredService<HttpClient>();
        var organizations = await Get<PagedResult<OrganizationReaderModelContract>>("/organizations?state=Validated",response =>
        {
            _testOutputHelper.WriteLine(response.StatusCode.ToString());
            _testOutputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
            _testOutputHelper.WriteLine(response.Headers.ToString());
        });
        Assert.True(organizations.Items is { Count: > 0 });
    }
    
    [Fact]
    public async void PutOrganization()
    {
        var client = GetRequiredService<HttpClient>();
        var organizations = await Get<PagedResult<OrganizationReaderModelContract>>("/organizations?state=Validated",response =>
        {
            _testOutputHelper.WriteLine(response.StatusCode.ToString());
            _testOutputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
            _testOutputHelper.WriteLine(response.Headers.ToString());
        });
        var organization = organizations.Items.First();
        
        var organizationUpdater = new OrganizationUpdaterModelContract
        {
            Name = organization.Name,
            Domain = organization.Domain,
            Description = Faker.Lorem.Sentence(3),
            Properties = organization.Properties,
            TimeZone = "Europe/Paris"
        };
        var content =
            new StringContent(JsonSerializer.Serialize(organizationUpdater), Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"/organizations/{organization.Id}", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}