#region

using MongoDB.Bson;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Repositories.MongoDb.Tests.Models;

public class Course : IEntity<ObjectId>
{
    public string Name { get; set; } = null!;
    public Professor Professor { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = null!;
    public ObjectId Id { get; set; } = ObjectId.Empty;

    protected bool Equals(Course other)
    {
        return Id.Equals(other.Id);
    }
}