#region

using MongoDB.Bson;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Repositories.MongoDb.Tests.Models;

public class Party : IEntity<ObjectId>
{
    public string PartyType { get; set; } = null!;

    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string StreetAddress { get; set; } = null!;
    public ObjectId Id { get; set; } = ObjectId.Empty;
}