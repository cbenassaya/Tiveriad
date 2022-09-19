using System.Reflection;

namespace Tiveriad.TextTemplating;

public interface ITemplateFactory<T> where T:TemplateRendererBase
{
    ITemplateFactory<T> Add(params Assembly[] assemblies);
    ITemplateFactory<T> Add(string root, params string[] paths);
    ITemplateFactory<T> FilterBy(string pattern);
    T Build();
}