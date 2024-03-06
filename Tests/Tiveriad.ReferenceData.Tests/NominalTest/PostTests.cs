using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.ReferenceData.Apis.Contracts.InternationalizedValueContracts;
using Tiveriad.ReferenceData.Apis.Contracts.KeyValueContracts;
using Xunit;

namespace Tiveriad.ReferenceData.Tests.NominalTest;

public class PostTests: IntegrationTestBase
{
    [Fact]
    public async void PostNewSkill()
    {
        var client = GetRequiredService<HttpClient>();

        var keyValueWriterModelContract = new KeyValueWriterModelContract
        {
            Key = "TOP",
            InternationalizedValues =
            [
                new()
                {
                    Language = "en",
                    Value = "Top",
                    Default = true
                },

                new()
                {
                    Language = "fr",
                    Value = "Haut",
                    Default = false
                }
            ]
        };
        
        var content =
            new StringContent(JsonSerializer.Serialize(keyValueWriterModelContract), Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync($"/skills", content );
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}