namespace Tiveriad.Identities.Apis.Contracts.TimeAreaContracts;

public class TimeAreaReduceModelContract
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public int? UtcOffSet { get; set; }
    public string? CountryCode { get; set; }
}