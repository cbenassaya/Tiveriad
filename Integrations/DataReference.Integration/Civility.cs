using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Tiveriad.DataReferences.Apis.Services;
using Tiveriad.Repositories;

namespace DataReference.Integration;

[DataReferenceRoute("api/civilities")]
public class Civility: IDataReference<ObjectId>
{
    [BsonId]
    public ObjectId Id { get; set; }
    public InternationalizedString Label { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public Visibility Visibility { get; set; }
    public ObjectId OrganizationId { get; set; }
}

public class KeyParser : IKeyParser<ObjectId>
{
    public ObjectId Parse(string? key)
    {
        return ObjectId.Parse(key);
    }
}

public class TenantService : ITenantService<ObjectId>
{
    private static ObjectId _objectId = ObjectId.GenerateNewId();
    public ObjectId GetOrganizationId()
    {
        return _objectId;
    }
}