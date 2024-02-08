namespace Tiveriad.Core.Abstractions.DomainEvents;

public class OccursOnAttribute: Attribute
{
    public OccursOnAttribute(Type entity)
    {
        Entity = entity;
    }
        
    public Type Entity { get; set; }
}