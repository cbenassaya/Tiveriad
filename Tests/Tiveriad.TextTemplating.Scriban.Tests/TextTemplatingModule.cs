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
        var value = templateRenderer.RenderAsync("HelloWorld.txt", model);
        Assert.Equal("Top:HelloWorld!", value.Result);
    }

    [Fact]
    public void Render_HelloWord_WithExtension()
    {
        var templateRenderer = GetRequiredService<ITemplateRenderer>();
        var model = new { Text = "HelloWorld!" };
        var value = templateRenderer.RenderAsync("HelloWorldWithExtension.txt", model);
        Assert.Equal("Top:helloWorld!", value.Result);
    }

    [Fact]
    public void Format_HelloWord()
    {
        string test = "{0}.{1}";
        var result = string.Format(test, "1", "2");
        Assert.Equal("1.2",result);
    }
}