using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Identities.Apis.Contracts;
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Registrations.Apis.Contracts;
using Tiveriad.Registrations.Apis.Contracts.RegistrationContracts;
using Xunit;

namespace Tiveriad.Integration.Tests._1.SubscribeProcess;

public class NominalUseCases: IntegrationTestBase
{

    [Fact]
    public void GetRegistrationModel()
    {
        var client = GetRequiredService<HttpClient>();
        var response = client.GetAsync("/api/registrationModels?name=Tiveriad.Registrations").Result;
        Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        var result = Get<List<RegistrationReaderModelContract>>(response).Result;
    }
    
    [Fact]
    public async void RegisterANewOrganization()
    {
        var registrationModels = Get<List<RegistrationReaderModelContract>>("/api/registrationModels?name=Tiveriad.Registrations").Result;
        
        RegistrationWriterModelContract registration = new()
        {
            OrganizationName = Faker.Company.Name(),
            Description = Faker.Company.CatchPhrase(),
            Firstname = Faker.Name.First(),
            Lastname = Faker.Name.Last(),
            Username = Faker.Internet.UserName(),
            Password = "ABCD1234qw@$",
            Email = Faker.Internet.Email(),
            DefaultLocale = Faker.Country.TwoLetterCode(),
            RegistrationModelId = registrationModels.First().Id

        };
        
        var client = GetRequiredService<HttpClient>();
        var content =
            new StringContent(JsonSerializer.Serialize(registration), Encoding.UTF8, "application/json");
        
        var response = client.PostAsync("/api/registrations", content).Result;
        var result = await Get<RegistrationReaderModelContract>(response);
        Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        Assert.NotNull(result.Id);
        Assert.NotEmpty(result.Id);
    }
    
    [Fact]
    public async void GetAllOrganizations() 
    {
        var client = GetRequiredService<HttpClient>();
        var response = client.GetAsync("/api/organizations").Result;
        Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        var result = Get<List<OrganizationReaderModelContract>>(response).Result;
        Assert.True(result.Any());
        
    }
}