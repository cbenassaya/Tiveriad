namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

public class Invoice:IEntity<int>
{
    public int Id { get; set; }
    public InvoiceState InvoiceState { get; set; }
    public Party From { get; set; }
    public Party To { get; set; }
    public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
}