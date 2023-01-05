using MongoDB.Bson;

namespace Tiveriad.Repositories.MongoDb.Tests.Models;

public class Invoice : IEntity<ObjectId> 
{
    public InvoiceState InvoiceState { get; set; }
    public Party From { get; set; } = null!;
    public Party To { get; set; } = null!;
    public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = null!;
    public ObjectId Id { get; set; }
}