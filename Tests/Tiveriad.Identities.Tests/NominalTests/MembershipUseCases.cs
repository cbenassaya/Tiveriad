using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Identities.Apis.Contracts.MembershipContracts;
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Apis.Contracts.RoleContracts;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Xunit;
using Xunit.Abstractions;

namespace Tiveriad.Identities.Tests.NominalTests;

public class MembershipUseCases : IntegrationTestBase
{
    private readonly ITestOutputHelper _testOutputHelper;

    public MembershipUseCases(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async void PostNewMembership()
    {
        var client = GetRequiredService<HttpClient>();

        var users = await Get<PagedResult<UserReaderModelContract>>("/users",response =>
        {
            _testOutputHelper.WriteLine(response.StatusCode.ToString());
            _testOutputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
            _testOutputHelper.WriteLine(response.Headers.ToString());
        });
        
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
        
        var membership = new MembershipWriterModelContract
        {
            UserId = users.Items.First().Id,
            OrganizationId = organizations.Items.First().Id,
            RolesId = roles.Items.Select(x=>x.Id).ToList()
        };
        
        var content =
            new StringContent(JsonSerializer.Serialize(membership), Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync("/memberships", content );
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}