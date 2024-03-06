using System.Text.Json;
using Tiveriad.UnitTests;

namespace Tiveriad.ReferenceData.Tests;

public class IntegrationTestBase : TestBase<Startup>
{
    private JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
    
    protected async Task<T?> Get<T>(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions);
    }
    
    protected async Task<T?> Get<T>(string api)
    {
        var client = GetRequiredService<HttpClient>();
        var response =  await client.GetAsync(api);
        return await Get<T>(response);
    }
}