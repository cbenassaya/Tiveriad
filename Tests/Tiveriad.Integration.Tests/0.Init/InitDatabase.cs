using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Registrations.Apis.Contracts;
using Tiveriad.Registrations.Apis.Contracts.RegistrationModelContracts;
using Xunit;

namespace Tiveriad.Integration.Tests._0.Init;

public class InitDatabase : IntegrationTestBase
{
    
    [Fact]
    public async void CleanDatabase()
    {
        var exist = File.Exists("database.db");
        if (exist)
        {
            File.Delete("database.db");
            Assert.True(true);
        }
        else
        {
            Assert.True(false);
        }
    }
    
    [Fact]
    public async void InitRegistrationMode()
    {
        var registrationModelWriterModel = new RegistrationModelWriterModelContract
        {
            Name = "Tiveriad.Registrations",
            Description = Faker.Company.CatchPhrase()
        };
        dynamic model = new Metadata();
        model.domain  = Faker.Internet.DomainName();
        registrationModelWriterModel.Model = model;
        
        var client = GetRequiredService<HttpClient>();
        var content =
            new StringContent(JsonSerializer.Serialize(registrationModelWriterModel), Encoding.UTF8, "application/json");
        
        var response = client.PostAsync("/api/registrationModels", content).Result;
        var result = await Get<RegistrationModelReaderModelContract>(response);
        Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        Assert.NotNull(result.Id);
        Assert.NotEmpty(result.Id);
    }
}