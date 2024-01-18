using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Tiveriad.Repositories;
using Tiveriad.Repositories.MongoDb.Attributes;

namespace Tiveriad.Multitenancy.Core.Entities;
[CollectionName("Organizations")]
public class Organization : IEntity<ObjectId>, IAuditable<ObjectId>
{
    [MaxLength(24)]
    [BsonId]
    public ObjectId Id { get; set; }

    [MaxLength(50)] public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    [JsonIgnore]
    public string? Description { get; set; }= string.Empty;

    public OrganizationState? State { get; set; } = OrganizationState.Pending;

    [JsonIgnore]
    public ObjectId CreatedBy { get; set; }

    [JsonIgnore]
    public DateTime Created { get; set; } = DateTime.Now;

    [JsonIgnore]
    public ObjectId LastModifiedBy { get; set; }

    [JsonIgnore]
    public DateTime? LastModified { get; set; }
    
    protected bool Equals(Organization other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Organization)obj);
    }

    public override int GetHashCode()
    {
        return Id ==null ? 0: Id.GetHashCode();
    }

    public static bool operator ==(Organization? left, Organization? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Organization? left, Organization? right)
    {
        return !Equals(left, right);
    }
}