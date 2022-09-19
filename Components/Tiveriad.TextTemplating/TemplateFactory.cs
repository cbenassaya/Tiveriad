using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileProviders;
using Tiveriad.TextTemplating.Extensions;

namespace Tiveriad.TextTemplating;

public class TemplateFactory<T> : ITemplateFactory<T> where T : TemplateRendererBase
{
    private List<IFileInfo> _fileInfos = new();
    private string _pattern = "*.*";
    
    private void Add(Assembly assembly)
    {
        var embeddedFileProvider = new EmbeddedFileProvider(assembly);
        _fileInfos.AddRange(assembly.GetManifestResourceNames().Select( x=>embeddedFileProvider.GetFileInfo(x.ToResourceName())).ToList());
    }
    
    public ITemplateFactory<T> Add(params Assembly[] assemblies)
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

    public ITemplateFactory<T> Add(string root, params string[] paths)
    {
        foreach (var path in paths)
        {
            Add(root,path);
        }
        return this;
    }

    public ITemplateFactory<T> FilterBy(string pattern)
    {
        _pattern = pattern;
        return this;
    }

    public T Build()
    {
        var pattern = $"^{_pattern.Replace("*", ".*?")}$";
        var filesInfos = _fileInfos.Where(x=>Regex.IsMatch(x.Name,pattern,RegexOptions.IgnoreCase)).ToList();
        var templateManager = new TemplateManager(filesInfos.ToDictionary(x=>x.Name.ToResourceName(),x=>x));
        Type type = typeof(T);
        return (T) Activator.CreateInstance(type, templateManager);
    }
}