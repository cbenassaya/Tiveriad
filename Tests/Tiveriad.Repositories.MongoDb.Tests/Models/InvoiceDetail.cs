using MongoDB.Bson;

namespace Tiveriad.Repositories.MongoDb.Tests.Models;

public class InvoiceDetail : IEntity<ObjectId> 
{
    public string Label { get; set; } = null!;
    public decimal Amount { get; set; }
    public Invoice Invoice { get; set; } = null!;
    public ObjectId Id { get; set; } 
}