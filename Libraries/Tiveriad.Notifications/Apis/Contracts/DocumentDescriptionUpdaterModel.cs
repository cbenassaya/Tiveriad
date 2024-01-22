namespace Tiveriad.Documents.Apis.Contracts;

public class DocumentDescriptionUpdaterModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Reference { get; set; }
    public string ReferenceType { get; set; }
    public Dictionary<string, object> Properties { get; set; }
}