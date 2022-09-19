namespace Tiveriad.TextTemplating;

public abstract class TemplateRendererBase : ITemplateRenderer
{
    protected  ITemplateManager TemplateManager { get; }

    protected TemplateRendererBase(ITemplateManager templateManager)
    {
        TemplateManager = templateManager;
    }

    public abstract Task<string> RenderAsync(string templateName, object model = null, string cultureName = null,
        Dictionary<string, object> globalContext = null);
}