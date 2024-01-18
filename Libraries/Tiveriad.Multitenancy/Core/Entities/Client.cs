using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Tiveriad.Repositories;
using Tiveriad.Repositories.MongoDb.Attributes;

namespace Tiveriad.Multitenancy.Core.Entities;


[CollectionName("Clients")]
public class Client : IEntity<ObjectId>, IAuditable<ObjectId>
{
    [MaxLength(24)]
    [BsonId]
    public ObjectId Id { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }

    public ObjectId CreatedBy { get; set; }

    public DateTime Created { get; set; }

    public ObjectId LastModifiedBy { get; set; }

    public DateTime? LastModified { get; set; }
    
}