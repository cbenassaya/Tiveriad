using Tiveriad.Repositories;

namespace Tiveriad.DataReferences.Apis.Contracts;

public class DataReferenceReaderModel
{
    public string? Id { get; set; }
    public string? Label { get; set; }
    public string? Description { get; set; }
    public string? Code { get; set; }
    public string? Visibility { get; set; }
    
}