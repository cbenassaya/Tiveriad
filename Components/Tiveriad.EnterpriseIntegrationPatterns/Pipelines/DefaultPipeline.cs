namespace Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

public class DefaultPipeline<TPipelineContext, TModel,  TConfiguration> : IPipeline<TModel>
    where TModel : class
    where TPipelineContext : class, IPipelineContext<TModel, TConfiguration>
    where TConfiguration : class, IPipelineConfiguration
{
    private readonly TConfiguration _configuration;
    private readonly RequestDelegate<TPipelineContext, TModel,TConfiguration> _firstMiddleware;

    public DefaultPipeline(TConfiguration configuration,
        RequestDelegate<TPipelineContext, TModel,TConfiguration> firstMiddleware)
    {
        _configuration = configuration;
        _firstMiddleware = firstMiddleware;
    }

    public Task ExecuteAsync(TModel model, CancellationToken cancellationToken = default)
    {
        var type = typeof(TPipelineContext);
        var context = (TPipelineContext)Activator.CreateInstance(type,model, _configuration, cancellationToken)!;
        ArgumentNullException.ThrowIfNull(context);
        return _firstMiddleware(context);
    }

    public async void Execute(TModel model)
    {
        var type = typeof(TPipelineContext);
        var context = (TPipelineContext)Activator.CreateInstance(type,model, _configuration, default(CancellationToken))!;
        ArgumentNullException.ThrowIfNull(context);
        await _firstMiddleware(context);
    }
}