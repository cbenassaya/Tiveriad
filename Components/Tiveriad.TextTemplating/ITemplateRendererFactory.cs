#region

using System.Reflection;

#endregion

namespace Tiveriad.TextTemplating;

public interface ITemplateRendererFactory<T, C> where T : TemplateRendererBase<C>
    where C : class, ITemplateRendererConfiguration
{
    ITemplateRendererFactory<T, C> Add(params Assembly[] assemblies);
    ITemplateRendererFactory<T, C> Add(string root, params string[] paths);
    ITemplateRendererFactory<T, C> FilterBy(string pattern);
    TemplateRendererFactory<T, C> Configure(Action<C> config);
    void Register(Action<T> rendererAction);
    T Build();
}