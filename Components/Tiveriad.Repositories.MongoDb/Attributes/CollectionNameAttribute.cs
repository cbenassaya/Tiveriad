namespace Tiveriad.Repositories.MongoDb.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CollectionNameAttribute : Attribute
{
    /// <summary>
    ///     The constructor.
    /// </summary>
    /// <param name="name">The name of the collection.</param>
    public CollectionNameAttribute(string? name)
    {
        Name = name;
    }

    /// <summary>
    ///     The name of the collection in which your documents are stored.
    /// </summary>
    public string? Name { get; set; }
}