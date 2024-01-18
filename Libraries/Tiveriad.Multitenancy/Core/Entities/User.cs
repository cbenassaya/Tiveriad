using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Tiveriad.Repositories;
using Tiveriad.Repositories.MongoDb.Attributes;

namespace Tiveriad.Multitenancy.Core.Entities;
[CollectionName("Users")]
public class User : IEntity<ObjectId>, IAuditable<ObjectId>
{
    [MaxLength(24)]
    [BsonId]
    public ObjectId Id { get; set; }

    [MaxLength(100)]
    public string Email { get; set; }

    [MaxLength(50)]
    public string Firstname { get; set; }

    [MaxLength(50)]
    public string Lastname { get; set; }
    
    [MaxLength(50)]
    public string Username { get; set; }
    
    [MaxLength(12)]
    [Required]
    [NotMapped]
    public string Password { get; set; }
    
    [MaxLength(50)]
    public string Locale { get; set; }

    [MaxLength(500)]
    [JsonIgnore]
    public string? Description { get; set; }

    [JsonIgnore]
    public ObjectId CreatedBy { get; set; }

    [JsonIgnore]
    public DateTime Created { get; set; }

    [JsonIgnore]
    public ObjectId LastModifiedBy { get; set; }

    [JsonIgnore]
    public DateTime? LastModified { get; set; }
}