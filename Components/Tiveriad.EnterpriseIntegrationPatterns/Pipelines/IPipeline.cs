namespace Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

public interface IPipeline<TModel>
{
    public Task ExecuteAsync(TModel model, CancellationToken cancellationToken = default);
    public void Execute(TModel model);
}