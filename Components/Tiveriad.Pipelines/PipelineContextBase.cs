namespace Tiveriad.Pipelines;

public abstract class PipelineContextBase<TConfiguration> : IPipelineContext<TConfiguration>
    where TConfiguration : class, IPipelineConfiguration
{


    protected PipelineContextBase(TConfiguration configuration, CancellationToken cancellationToken )
    {
        CancellationToken = cancellationToken;
        Configuration = configuration;
    }

    public CancellationToken CancellationToken { get; }
    public TConfiguration Configuration { get; }
}