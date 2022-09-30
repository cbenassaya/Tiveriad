using Tiveriad.UnitTests;
using Xunit;

namespace Tiveriad.TextTemplating.Scriban.Tests;

public class TextTemplatingModule : TestBase<Startup>
{
    [Fact]
    public void Render_HelloWord()
    {
        var templateRenderer = GetRequiredService<ITemplateRenderer>();
        var model = new { Text = "HelloWorld!" };
        var value = templateRenderer.RenderAsync("HelloWorld.txt",model );
        Assert.Equal( "Top:HelloWorld!",value.Result);
    }
    
    [Fact]
    public void Render_HelloWord_WithExtension()
    {
        var templateRenderer = GetRequiredService<ITemplateRenderer>();
        var model = new { Text = "HelloWorld!" };
        var value = templateRenderer.RenderAsync("HelloWorldWithExtension.txt",model );
        Assert.Equal( "Top:helloWorld!",value.Result);
    }
}