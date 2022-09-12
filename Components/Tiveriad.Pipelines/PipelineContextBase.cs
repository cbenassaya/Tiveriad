namespace Tiveriad.Pipelines;

public abstract class PipelineContextBase<TConfiguration> : IPipelineContext<TConfiguration>
    where TConfiguration : class, IPipelineConfiguration
{
    private readonly CancellationToken _cancellationToken;
    private readonly TConfiguration _configuration;

    protected PipelineContextBase(TConfiguration configuration, CancellationToken cancellationToken )
    {
        _cancellationToken = cancellationToken;
        _configuration = configuration;
    }

    public CancellationToken CancellationToken { get; }
    public TConfiguration Configuration { get; }
}