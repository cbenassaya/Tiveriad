namespace Tiveriad.IdGenerator;
public static class IdGenerator
{
    public static TKey NewId<TKey>()
    {
        if (typeof(TKey) == typeof(Guid))
        {
            return (TKey)Convert.ChangeType(Guid.NewGuid(), typeof(TKey));
        }
            
        if (typeof(TKey) == typeof(string))
        {
            var stringIdGenerator  = new StringIdGenerator();
            return (TKey)Convert.ChangeType(stringIdGenerator.CreateId(), typeof(TKey));
        }
            
        if (typeof(TKey) == typeof(Int32))
        {
            var intIdGenerator  = new IntIdGenerator(0);
            return (TKey)Convert.ChangeType(intIdGenerator.CreateId(), typeof(TKey));
        }
        
        if (typeof(TKey) == typeof(Int64))
        {
            var  longIdGenerator  = new LongIdGenerator(0);
            return (TKey)Convert.ChangeType(longIdGenerator.CreateId(), typeof(TKey));
        }
            
        throw new InvalidOperationException("Primary key could not be generated. This only works for GUID, String.");
            
    }
}