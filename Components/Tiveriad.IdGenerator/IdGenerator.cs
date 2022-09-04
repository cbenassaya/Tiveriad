namespace Tiveriad.IdGenerator;
public class IdGenerator
{
    private static readonly IntIdGenerator _intIdGenerator  = new IntIdGenerator(0);
    private static readonly LongIdGenerator _longIdGenerator  = new LongIdGenerator(0);
    private static readonly StringIdGenerator _stringIdGenerator  = new StringIdGenerator();


    public static TKey NewId<TKey>()
    {
        if (typeof(TKey) == typeof(Guid))
        {
            return (TKey)Convert.ChangeType(Guid.NewGuid(), typeof(TKey));
        }
            
        if (typeof(TKey) == typeof(string))
        {
            return (TKey)Convert.ChangeType(_stringIdGenerator.CreateId(), typeof(TKey));
        }
            
        if (typeof(TKey) == typeof(Int32))
        {
            return (TKey)Convert.ChangeType(_intIdGenerator.CreateId(), typeof(TKey));
        }
        
        if (typeof(TKey) == typeof(Int64))
        {
            return (TKey)Convert.ChangeType(_longIdGenerator.CreateId(), typeof(TKey));
        }
            
        throw new InvalidOperationException("Primary key could not be generated. This only works for GUID, String.");
            
    }
}