namespace Tiveriad.Pipelines;

public interface IPipelineContext<TConfiguration> where TConfiguration : class, IPipelineConfiguration
{
    public CancellationToken CancellationToken { get; set; }
    public TConfiguration Configuration { get; set; }
}