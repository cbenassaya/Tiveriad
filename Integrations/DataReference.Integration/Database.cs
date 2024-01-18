using Mongo2Go;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Tiveriad.Repositories;

namespace DataReference.Integration;

public class Database : IDisposable
{
    private readonly MongoDbRunner _runner;
    public  Database()
    {
        _runner = MongoDbRunner.Start();
    }
    public string ConnectionString => _runner.ConnectionString;
    
    public void Dispose()
    {
        using (_runner) ;

    }
}

public class InternationalizedStringSerializer : SerializerBase<InternationalizedString>
{
    public override InternationalizedString Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        InternationalizedString internationalizedString = new InternationalizedString();
        internationalizedString.SetValue(context.Reader.ReadString());
        return internationalizedString;
    }

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, InternationalizedString value)
    {
        context.Writer.WriteString(value.Value);
    }
}

public class InternationalizedSerializationProvider : IBsonSerializationProvider
{
    public IBsonSerializer GetSerializer(Type type)
    {
        return type == typeof(InternationalizedString) ? new InternationalizedStringSerializer() : null;
    }
}