using System.Diagnostics.CodeAnalysis;

namespace Tiveriad.TextTemplating;

public interface ITemplateRenderer
{

   
    
    public Task<string> RenderAsync(
         string templateName, 
         object model = null,
         string cultureName = null,
         Dictionary<string, object> globalContext = null
    );
}