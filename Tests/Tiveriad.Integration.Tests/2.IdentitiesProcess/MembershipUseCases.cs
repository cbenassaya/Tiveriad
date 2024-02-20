using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Identities.Apis.Contracts.MembershipContracts;
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Apis.Contracts.RoleContracts;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Xunit;

namespace Tiveriad.Integration.Tests._2.IdentitiesProcess;

public class MembershipUseCases : IntegrationTestBase
{
    [Fact]
    public async void PostNewMembership()
    {
        var client = GetRequiredService<HttpClient>();
        var users = Get<List<UserReaderModelContract>>(client.GetAsync("/api/users").Result).Result;
        var organizations = Get<List<OrganizationReaderModelContract>>(client.GetAsync("/api/organizations?state=Validated").Result).Result;
        var roles = Get<List<RoleReaderModelContract>>(client.GetAsync($"/api/organizations/{organizations.First().Id}/roles").Result).Result;
        
        var membership = new MembershipWriterModelContract
        {
            UserId = users.First().Id,
            OrganizationId = organizations.First().Id,
            RolesId = roles.Select(x=>x.Id).ToList()
        };
        var content =
            new StringContent(JsonSerializer.Serialize(membership), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/api/memberships", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}