namespace Tiveriad.TextTemplating.Scriban;

public class ScribanTemplateRendererConfiguration : ITemplateRendererConfiguration
{
    public List<Type> TypesOfImport { get; } = new();

    public ScribanTemplateRendererConfiguration Add<T>()
    {
        TypesOfImport.Add(typeof(T));
        return this;
    }

    public ScribanTemplateRendererConfiguration Add(Type type)
    {
        TypesOfImport.Add(type);
        return this;
    }
}