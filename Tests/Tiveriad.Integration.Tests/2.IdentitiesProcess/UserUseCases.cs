using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Xunit;

namespace Tiveriad.Integration.Tests._2.IdentitiesProcess;

public class UserUseCases: IntegrationTestBase
{

    
    
    
    
    [Fact]
    public async void PostNewUser()
    {
        var client = GetRequiredService<HttpClient>();
        
        
        var user = new UserWriterModelContract
        {
            Firstname = Faker.Name.First(),
            Lastname = Faker.Name.Last(),
            Username = Faker.Internet.UserName(),
            Password = "ABCD1234qw@$",
            Email = Faker.Internet.Email(),
            DateOfBirth = Faker.Identification.DateOfBirth(),
            Language = "en",
            Locale = "en-US",
            
        };
        var content =
            new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/api/users", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}