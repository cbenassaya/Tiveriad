namespace Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

public interface IPipelineContext<TConfiguration> where TConfiguration : class, IPipelineConfiguration
{
    public CancellationToken CancellationToken { get; }
    public TConfiguration Configuration { get; }
}