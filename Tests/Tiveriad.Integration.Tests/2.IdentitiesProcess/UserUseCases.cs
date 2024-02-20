using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Identities.Apis.Contracts.LanguageContracts;
using Tiveriad.Identities.Apis.Contracts.LocaleContracts;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Xunit;

namespace Tiveriad.Integration.Tests._2.IdentitiesProcess;

public class UserUseCases: IntegrationTestBase
{
    [Fact]
    public async void PostNewLanguage()
    {
        var client = GetRequiredService<HttpClient>();
        var language = new LanguageWriterModelContract
        {
            Name = Faker.Country.Name(),
            Code = Faker.Country.TwoLetterCode(),
        };
        var content =
            new StringContent(JsonSerializer.Serialize(language), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/api/languages", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async void PostNewLocale()
    {
        var client = GetRequiredService<HttpClient>();
        var locale = new LocaleWriterModelContract()
        {
            Name = Faker.Country.Name(),
            Code = Faker.Country.TwoLetterCode(),
        };
        var content =
            new StringContent(JsonSerializer.Serialize(locale), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/api/locales", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    
    
    
    [Fact]
    public async void PostNewUser()
    {
        var client = GetRequiredService<HttpClient>();
        
        var locales = Get<List<LocaleReaderModelContract>>(client.GetAsync("/api/locales").Result).Result;
        var languages = Get<List<LanguageReaderModelContract>>(client.GetAsync("/api/languages").Result).Result;
        
        var user = new UserWriterModelContract
        {
            Firstname = Faker.Name.First(),
            Lastname = Faker.Name.Last(),
            Username = Faker.Internet.UserName(),
            Password = "ABCD1234qw@$",
            Email = Faker.Internet.Email(),
            DateOfBirth = Faker.Identification.DateOfBirth(),
            LanguageId = languages.First().Id,
            LocaleId = locales.First().Id,
            
        };
        var content =
            new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/api/users", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}