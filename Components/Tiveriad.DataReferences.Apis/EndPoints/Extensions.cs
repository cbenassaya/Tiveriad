using Microsoft.AspNetCore.Http;

namespace Tiveriad.DataReferences.Apis.EndPoints;

public static  class Extensions {
    public static async Task<MultipartFormDataContent> ToMultipartFormDataContent(this IFormFile file)
    {
        var multipartContent = new MultipartFormDataContent();
        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            multipartContent.Add(
                new ByteArrayContent(memoryStream.ToArray()), "FormFile",
                file.FileName);
        }
        return multipartContent;
    } 
}