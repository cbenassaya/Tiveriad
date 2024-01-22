#region

using Microsoft.AspNetCore.Http;

#endregion

namespace Tiveriad.DataReferences.Apis.Contracts;

public class DataReferenceWriterModel
{
    public string? Label { get; set; }
    public string? Description { get; set; }
    public string? Code { get; set; }

    public IFormFile Image { get; set; }
}