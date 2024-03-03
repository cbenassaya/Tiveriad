using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Tiveriad.Identities.Core.Entities;
using Xunit;

namespace Tiveriad.Integration.Tests._2.IdentitiesProcess;

public class OrganizationUseCases: IntegrationTestBase
{
    
    [Fact]
    public async void PostNewOrganization()
    {
        var client = GetRequiredService<HttpClient>();
        var users = Get<List<UserReaderModelContract>>(client.GetAsync("/api/users").Result).Result;
        
        var organization = new OrganizationWriterModelContract
        {
            Name = Faker.Company.Name(),
            Domain = Faker.Internet.DomainName(),
            OwnerId = users.First().Id,
            TimeZone = "Europe/Paris",
            Description = Faker.Lorem.Sentence(3)
        };
        
        
        var content =
            new StringContent(JsonSerializer.Serialize(organization), Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync("/api/organizations", content );
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }

    [Fact]
    public async void PutValidateOrganization()
    {
        var client = GetRequiredService<HttpClient>();
        var organizations = Get<List<OrganizationReaderModelContract>>(client.GetAsync("/api/organizations?state=Pending").Result).Result;
        var organizationEvent = new OrganizationEventModelContract
        {
            Event = OrganizationEvent.Validate
        };
        var content =
            new StringContent(JsonSerializer.Serialize(organizationEvent), Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"/api/organizations/{organizations.First().Id}/events", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
    }

    [Fact]
    public async void GetAllValidateOrganizations()
    {
        var client = GetRequiredService<HttpClient>();
        var organizations = Get<List<OrganizationReaderModelContract>>(client.GetAsync("/api/organizations?state=Validated").Result).Result;
        Assert.True(organizations is { Count: > 0 });
    }
    
    [Fact]
    public async void PutOrganization()
    {
        var client = GetRequiredService<HttpClient>();
        var organizations = Get<List<OrganizationReaderModelContract>>(client.GetAsync("/api/organizations?state=Validated").Result).Result;
        var organization = organizations.First();
        
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
        var response = await client.PutAsync($"/api/organizations/{organization.Id}", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}