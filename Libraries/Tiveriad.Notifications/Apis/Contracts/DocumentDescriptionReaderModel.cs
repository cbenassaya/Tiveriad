namespace Tiveriad.Documents.Apis.Contracts;

public class DocumentDescriptionReaderModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Provider { get; set; }
    public object Properties { get; set; }
    public string Reference { get; set; }
    public string ReferenceType { get; set; }
}