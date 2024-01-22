namespace Tiveriad.Identities.Apis.Contracts;

public class ClientReaderModel
{
    public string? Id { get; set; }

    public string? Name { get; set; }
    
    public string? Code { get; set; }

    public string? Description { get; set; }
    public OrganizationReduceModel Organization { get; set; }

}