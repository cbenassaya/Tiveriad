#region

using System.Net;
using System.Text;
using System.Text.Json;
using Faker;
using Tiveriad.Registrations.Apis.Contracts;
using Tiveriad.Registrations.Apis.Contracts.RegistrationContracts;
using Tiveriad.Registrations.Apis.Contracts.RegistrationModelContracts;
using Xunit;

#endregion

namespace Tiveriad.Integration.Tests._1.SubscribeProcess;

public class ErrorUseCases : IntegrationTestBase
{
    [Fact]
    public async void AddTwiceTheSameOrganization()
    {
        var registrationModels =
            Get<List<RegistrationModelReaderModelContract>>("/api/registrationModels?name=Tiveriad.Registrations").Result;

        RegistrationWriterModelContract registration = new()
        {
            OrganizationName = Company.Name(),
            Description = Company.CatchPhrase(),
            Firstname = Name.First(),
            Lastname = Name.Last(),
            Username = Internet.UserName(),
            Password = "ABCD1234qw@$",
            Email = Internet.Email(),
            DefaultLocale = Country.TwoLetterCode(),
            RegistrationModelId = registrationModels.First().Id
        };

        var client = GetRequiredService<HttpClient>();
        var content =
            new StringContent(JsonSerializer.Serialize(registration), Encoding.UTF8, "application/json");

        var firstResponse = client.PostAsync("/api/registrations", content).Result;
        Assert.Equal(firstResponse.StatusCode, HttpStatusCode.OK);
        var secondResponse = client.PostAsync("/api/registrations", content).Result;
        var secondContentResponse = await secondResponse.Content.ReadAsStringAsync();
        Assert.Equal(secondContentResponse, "Registration_OrganizationName_XUniqueRule");
    }
    
    
    [Fact]
    public async void OrganizationNameUsernamePasswordEmailMandatory()
    {
        var registrationModels =
            Get<List<RegistrationModelReaderModelContract>>("/api/registrationModels?name=Tiveriad.Registrations").Result;

        RegistrationWriterModelContract registration = new()
        {
            Description = Company.CatchPhrase(),
            Firstname = Name.First(),
            Lastname = Name.Last(),
            DefaultLocale = Country.TwoLetterCode(),
            RegistrationModelId = registrationModels.First().Id
        };

        var client = GetRequiredService<HttpClient>();
        var requestContent =
            new StringContent(JsonSerializer.Serialize(registration), Encoding.UTF8, "application/json");


        var response = client.PostAsync("/api/registrations", requestContent).Result;
        var responseContent = await response.Content.ReadAsStringAsync();
        Assert.Equal(responseContent, "Registration_OrganizationName_XNotEmptyRule,Registration_Username_XNotEmptyRule,Registration_Password_XNotEmptyRule,Registration_Email_XNotEmptyRule");
        Assert.Equal(responseContent.Split(",").Length,4);
    }
}