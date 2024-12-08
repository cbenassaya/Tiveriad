namespace Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

public interface IPipelineContext<TModel, TConfiguration>
    where TModel : class
    where TConfiguration : class, IPipelineConfiguration
{
    public CancellationToken CancellationToken { get; }
    public TConfiguration Configuration { get; }
    public TModel Model { get; }
}