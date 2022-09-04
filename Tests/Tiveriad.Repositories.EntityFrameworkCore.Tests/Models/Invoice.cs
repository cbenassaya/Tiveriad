namespace Tiveriad.Repositories.EntityFrameworkCore.Tests.Models;

public class Invoice:IEntity<int>
{
    public int Id { get; set; }
    public InvoiceState InvoiceState { get; set; }
    public Party From { get; set; }= null!;
    public Party To { get; set; }= null!;
    public ICollection<InvoiceDetail> InvoiceDetails { get; set; }= null!;
}