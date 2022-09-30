using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileProviders;
using Tiveriad.TextTemplating.Extensions;

namespace Tiveriad.TextTemplating;

public class TemplateRendererFactory<T,C> : ITemplateRendererFactory<T,C> where T : TemplateRendererBase<C> where C:class,ITemplateRendererConfiguration
{
    private List<IFileInfo> _fileInfos = new();
    private string _pattern = "*.*";
    private readonly C _configuration;


    internal TemplateRendererFactory()
    {
        _configuration = Activator.CreateInstance<C>();
    }


    
    
    private void Add(Assembly assembly)
    {
        var embeddedFileProvider = new EmbeddedFileProvider(assembly);

        var assemblyName = assembly.FullName.Split(",")[0]; 
        _fileInfos.AddRange(
            assembly.GetManifestResourceNames().Select( 
                x=>embeddedFileProvider.GetFileInfo(x.Substring(assemblyName.Length+1))
            ).ToList());
    }
    
    public TemplateRendererFactory<T,C>  Configure(Action<C> config)
    {
       
        config(_configuration);
        return this;
    }
    
    public ITemplateRendererFactory<T,C> Add(params Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            Add(assembly);
        }
        return this;
    }
    
    private void Add(string root, string path)
    {
        var physicalFileProvider = new PhysicalFileProvider(root);
        _fileInfos.AddRange(physicalFileProvider.GetDirectoryContents(path).Where(x => !x.IsDirectory).ToList());
    }

    public ITemplateRendererFactory<T,C> Add(string root, params string[] paths)
    {
        foreach (var path in paths)
        {
            Add(root,path);
        }
        return this;
    }

    public ITemplateRendererFactory<T,C> FilterBy(string pattern)
    {
        _pattern = pattern;
        return this;
    }

    public void Register(Action<T> rendererAction)
    {
        var renderer = Build();
        rendererAction(renderer);
    }

    public T Build()
    {
        var pattern = $"^{_pattern.Replace("*", ".*?")}$";
        var filesInfos = _fileInfos.Where(x=>Regex.IsMatch(x.Name,pattern,RegexOptions.IgnoreCase)).ToList();
        var templateManager = new TemplateManager(filesInfos.ToDictionary(x=>x.Name.ToResourceName(),x=>x));
        Type type = typeof(T);
        return (T) Activator.CreateInstance(type, templateManager, _configuration);
    }
}