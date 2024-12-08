namespace Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

public abstract class PipelineContextBase<TModel,TConfiguration> : IPipelineContext<TModel, TConfiguration>
    where TModel : class
    where TConfiguration : class, IPipelineConfiguration
{
    protected PipelineContextBase(TModel model, TConfiguration configuration, CancellationToken cancellationToken)
    {
        CancellationToken = cancellationToken;
        Configuration = configuration;
        Model = model;
    }

    public CancellationToken CancellationToken { get; }
    public TConfiguration Configuration { get; }
    
    public TModel Model { get;  } = default!;
}