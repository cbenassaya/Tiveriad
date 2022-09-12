namespace Tiveriad.Pipelines;

public class DefaultPipeline<TModel, TPipelineContext, TConfiguration> : IPipeline<TModel>
    where TPipelineContext : class, IPipelineContext<TConfiguration>
    where TConfiguration : class, IPipelineConfiguration
{
    private TConfiguration _configuration;
    private readonly RequestDelegate<TModel, TPipelineContext, TConfiguration> _firstMiddleware;

    public DefaultPipeline(TConfiguration configuration,
        RequestDelegate<TModel, TPipelineContext, TConfiguration> firstMiddleware)
    {
        _configuration = configuration;
        _firstMiddleware = firstMiddleware;
    }

    public async Task ExecuteAsync(TModel model, CancellationToken cancellationToken = default)
    {
        var context = Activator.CreateInstance<TPipelineContext>();
        context.CancellationToken = cancellationToken;
        await Task.FromResult(_firstMiddleware(context, model));
    }

    public void Execute(TModel model)
    {
        var context = Activator.CreateInstance<TPipelineContext>();
        _firstMiddleware(context, model);
    }
}