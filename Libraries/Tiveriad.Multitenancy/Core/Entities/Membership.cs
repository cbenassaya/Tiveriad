using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Tiveriad.Repositories;
using Tiveriad.Repositories.MongoDb.Attributes;

namespace Tiveriad.Multitenancy.Core.Entities;
[CollectionName("Memberships")]
public class Membership : IEntity<ObjectId>, IAuditable<ObjectId>
{
    [MaxLength(24)]
    [BsonId]
    public ObjectId Id { get; set; }

    public MembershipState State { get; set; }

    public ObjectId CreatedBy { get; set; }

    public DateTime Created { get; set; }

    public ObjectId LastModifiedBy { get; set; }

    public DateTime? LastModified { get; set; }
    
    public bool IsOwner { get; set; } = false;

    public ObjectId UserId { get; set; }

    public ObjectId OrganizationId { get; set; }
}