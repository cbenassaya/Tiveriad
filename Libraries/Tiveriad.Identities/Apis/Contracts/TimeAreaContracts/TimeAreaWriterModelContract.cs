namespace Tiveriad.Identities.Apis.Contracts.TimeAreaContracts;

public class TimeAreaWriterModelContract
{
    public string? Name { get; set; }
    public string? Code { get; set; }
    public int? UtcOffSet { get; set; }
    public string? CountryCode { get; set; }
    public string? Descriptions { get; set; }
}