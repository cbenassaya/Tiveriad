using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Documents.Apis.Contracts.DocumentCategoryContracts;
using Tiveriad.Documents.Apis.Contracts.DocumentDescriptionContracts;
using Xunit;


namespace Tiveriad.Integration.Tests;

public class DocumentTest : IntegrationTestBase
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
    public async void AddDocumentCategory()
    {
        var documentCategory = new DocumentCategoryWriterModel
        {
            Code = "RESUME",
            Name = "Resume"
        };
        var client = GetRequiredService<HttpClient>();
        HttpContent content =
            new StringContent(JsonSerializer.Serialize(documentCategory), Encoding.UTF8, "application/json");
        var response = client.PostAsync("/api/organizations/123456789/documentCategories", content).Result;
        var result = await Get<DocumentCategoryReaderModel>(response);
        Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        Assert.NotNull(result.Id);
        Assert.NotEmpty(result.Id);
    }

    [Fact]
    public async void AddDocument()
    {
        dynamic properties = new Metadata();
        properties.Severity = "max";
        properties.Type = "png";

        await using var stream = System.IO.File.OpenRead("Images/document.png");

        var documentCategories = await Get<IEnumerable<DocumentCategoryReaderModel>>("/api/organizations/123456789/documentCategories");
        var dc = documentCategories.First();

        using var content = new MultipartFormDataContent
        {
            { new StreamContent(stream), "FormFile", "document.png" },
            { new StringContent(Guid.NewGuid().ToString()), "Name" },
            { new StringContent("Image"), "Description" },
            { new StringContent("Images"), "Path" },
            { new StringContent(dc.Id), "DocumentCategoryId" },
            { new StringContent(properties), "Properties" }
        };
        var httpClient = GetRequiredService<HttpClient>();
        var response = await httpClient.PostAsync("/api/organizations/123456789/documentDescriptions", content);

        // Handle the response as needed
        if (response.IsSuccessStatusCode)
            Assert.True(response.IsSuccessStatusCode);
        else
            Assert.Fail($"Error: {response.StatusCode} - {response.ReasonPhrase}");
    }
}

