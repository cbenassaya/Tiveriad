namespace Tiveriad.TextTemplating;

public abstract class TemplateRendererBase<C> : ITemplateRenderer where C:class, ITemplateRendererConfiguration
{
    protected  ITemplateManager TemplateManager { get; }
    protected  C RendererConfiguration { get; }

    protected TemplateRendererBase(ITemplateManager templateManager, C rendererConfiguration)
    {
        TemplateManager = templateManager;
        RendererConfiguration = rendererConfiguration;
    }

    public abstract Task<string> RenderAsync(string templateName, object model = null, string cultureName = null,
        Dictionary<string, object> globalContext = null);
}