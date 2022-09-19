using Scriban;
using Scriban.Runtime;

namespace Tiveriad.TextTemplating.Scriban;

public class ScribanTemplateRenderer: TemplateRendererBase
{
    public ScribanTemplateRenderer(ITemplateManager templateManager) : base(templateManager) { }

    public override async Task<string> RenderAsync(string templateName, object model = null, string cultureName = null, Dictionary<string, object> globalContext = null)
    {
        var templateDefinition = TemplateManager.Get(templateName);
        var template = Template.Parse(templateDefinition.Layout);
        return await template.RenderAsync(CreateScribanTemplateContext(globalContext,model));
    }
    
    private  TemplateContext CreateScribanTemplateContext(Dictionary<string, object> globalContext, object model = null)
    {
        var context = new TemplateContext();
        var scriptObject = new ScriptObject();
        scriptObject.Import(globalContext);
        scriptObject["model"] = model;
        context.PushGlobal(scriptObject);
        return context;
    }
}