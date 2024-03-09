using System.Net;
using System.Text;
using System.Text.Json;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.ReferenceData.Apis.Contracts.KeyValueContracts;
using Xunit;
using Xunit.Abstractions;

namespace Tiveriad.ReferenceData.Tests.NominalTests;

public class CrudTests: IntegrationTestBase
{
    private readonly ITestOutputHelper _testOutputHelper;

    public CrudTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async void NewSkill()
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

    [Fact]
    public async void GetAll()
    {
        var response = await  Get<PagedResult<KeyValueReaderModelContract>> ("/skills", response=>{
            _testOutputHelper.WriteLine(response.StatusCode.ToString());
            _testOutputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
            _testOutputHelper.WriteLine(response.Headers.ToString());
        } );
        Assert.True( response?.Items.Count > 0);
    }
    
    [Fact]
    public async void GetById()
    {
        var responseGetAll = await  Get<PagedResult<KeyValueReaderModelContract>> ("/skills", response=>{
            _testOutputHelper.WriteLine(response.StatusCode.ToString());
            _testOutputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
            _testOutputHelper.WriteLine(response.Headers.ToString());
        } );
        if (responseGetAll?.Items.Count > 1)
        {
            var response = await  Get<KeyInternationalizedValueReaderModelContract> ($"/skills/{{{responseGetAll.Items.First().Id}}}", response=>{
                _testOutputHelper.WriteLine(response.StatusCode.ToString());
                _testOutputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
                _testOutputHelper.WriteLine(response.Headers.ToString());
            } );
        }
    }
}