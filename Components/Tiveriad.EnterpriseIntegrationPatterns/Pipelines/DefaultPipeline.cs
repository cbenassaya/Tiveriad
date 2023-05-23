namespace Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

public class DefaultPipeline<TModel, TPipelineContext, TConfiguration> : IPipeline<TModel>
    where TPipelineContext : class, IPipelineContext<TConfiguration>
    where TConfiguration : class, IPipelineConfiguration
{
    private readonly TConfiguration _configuration;
    private readonly RequestDelegate<TModel, TPipelineContext, TConfiguration> _firstMiddleware;

    public DefaultPipeline(TConfiguration configuration,
        RequestDelegate<TModel, TPipelineContext, TConfiguration> firstMiddleware)
    {
        _configuration = configuration;
        _firstMiddleware = firstMiddleware;
    }

    public async Task ExecuteAsync(TModel model, CancellationToken cancellationToken = default)
    {
        var type = typeof(TPipelineContext);
        var context = (TPipelineContext)Activator.CreateInstance(type, _configuration, cancellationToken)!;
        ArgumentNullException.ThrowIfNull(context);
        await Task.FromResult(_firstMiddleware(context, model));
    }

    public void Execute(TModel model)
    {
        var type = typeof(TPipelineContext);
        var context = (TPipelineContext)Activator.CreateInstance(type, _configuration, default(CancellationToken))!;
        ArgumentNullException.ThrowIfNull(context);
        _firstMiddleware(context, model);
    }
}