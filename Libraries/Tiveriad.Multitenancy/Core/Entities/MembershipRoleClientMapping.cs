using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Core.Entities;

public class MembershipRoleClientMapping : IEntity<ObjectId>, IAuditable<ObjectId>
{
    [MaxLength(24)]
    [BsonId]
    public ObjectId Id { get; set; }
    public string ClientId { get; set; }
    
    public string MembershipId { get; set; }
    public Role Role { get; set; }
    
    public ObjectId CreatedBy { get; set; }

    public DateTime Created { get; set; }

    public ObjectId LastModifiedBy { get; set; }

    public DateTime? LastModified { get; set; }

}