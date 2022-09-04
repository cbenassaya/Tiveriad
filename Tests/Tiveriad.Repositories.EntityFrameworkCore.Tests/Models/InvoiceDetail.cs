namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

public class InvoiceDetail:IEntity<int>
{
    public int Id { get; set; }
    public string Label { get; set; }
    public decimal Amount { get; set; }
    public Invoice Invoice { get; set; }
}