namespace Tiveriad.Documents.Core.Services;

[AttributeUsage(AttributeTargets.Class)]
public class BlobProviderNameAttribute : Attribute
{
    /// <summary>
    ///     The constructor.
    /// </summary>
    /// <param name="name">The name of the collection.</param>
    public BlobProviderNameAttribute(string name)
    {
        Name = name;
    }

    /// <summary>
    ///     The name of the collection in which your documents are stored.
    /// </summary>
    public string Name { get; set; }
}