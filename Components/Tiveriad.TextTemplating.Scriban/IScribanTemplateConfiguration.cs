namespace Tiveriad.TextTemplating.Scriban;

public class ScribanTemplateRendererConfiguration:ITemplateRendererConfiguration
{
    private readonly List<Type> _types = new List<Type>();


    public List<Type> TypesOfImport => _types;
    
    public ScribanTemplateRendererConfiguration Add<T>()
    {
        _types.Add(typeof(T));
        return this;
    }
    
    public ScribanTemplateRendererConfiguration Add(Type type)
    {
        _types.Add(type);
        return this;
    }
}