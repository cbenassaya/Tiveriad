#region

using MongoDB.Bson;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Repositories.MongoDb.Tests.Models;

public class Professor : IEntity<ObjectId>
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public ObjectId Id { get; set; } = ObjectId.Empty;
}