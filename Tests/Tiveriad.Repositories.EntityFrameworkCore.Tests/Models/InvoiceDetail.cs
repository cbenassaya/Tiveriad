namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

public class InvoiceDetail:IEntity<string>
{
    public string Id { get; set; }= null!;
    public string Label { get; set; }= null!;
    public decimal Amount { get; set; }
    public Invoice Invoice { get; set; }= null!;
}