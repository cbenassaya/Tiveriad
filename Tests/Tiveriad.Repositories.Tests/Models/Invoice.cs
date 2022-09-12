namespace Tiveriad.Repositories.Tests.Models;

public class Invoice : IEntity<string>
{
    public InvoiceState InvoiceState { get; set; }
    public Party From { get; set; } = null!;
    public Party To { get; set; } = null!;
    public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = null!;
    public string Id { get; set; } = null!;
}