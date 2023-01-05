using MongoDB.Bson;

namespace Tiveriad.Repositories.MongoDb.Tests.Models;

public class Student : IEntity<ObjectId> 
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string StreetAddress { get; set; } = null!;
    public ICollection<Course> Courses { get; set; } = null!;
    public ObjectId Id { get; set; }
}