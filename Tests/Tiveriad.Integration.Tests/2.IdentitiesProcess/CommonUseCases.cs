using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Identities.Apis.Contracts.LanguageContracts;
using Tiveriad.Identities.Apis.Contracts.LocaleContracts;
using Tiveriad.Identities.Apis.Contracts.TimeAreaContracts;
using Xunit;

namespace Tiveriad.Integration.Tests._2.IdentitiesProcess;

public class CommonUseCases: IntegrationTestBase
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
    
    public async void PostNewTimeArea()
    {
        var client = GetRequiredService<HttpClient>();
        var timeAreaWriter = new TimeAreaWriterModelContract
        {
            Name = "Israel",
            Code = "+02:00",
            UtcOffSet = 2*60*60,
            CountryCode = "IL"
        };
        

        var content =
            new StringContent(JsonSerializer.Serialize(timeAreaWriter), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/api/timeAreas", content );
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}