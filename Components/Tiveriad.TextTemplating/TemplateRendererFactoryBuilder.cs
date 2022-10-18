namespace Tiveriad.TextTemplating;

public class TemplateRendererFactoryBuilder
{
    private TemplateRendererFactoryBuilder()
    {
    }

    public static TemplateRendererFactory<T, C> With<T, C>() where T : TemplateRendererBase<C>
        where C : class, ITemplateRendererConfiguration
    {
        return new TemplateRendererFactory<T, C>();
    }
}