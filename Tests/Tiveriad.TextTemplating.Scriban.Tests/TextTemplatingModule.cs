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
        Assert.Equal( "HelloWorld!",model.Text);
        var value = templateRenderer.RenderAsync("HelloWorld.txt",model );
        Assert.Equal( "Top:HelloWorld!",value.Result);
    }
}