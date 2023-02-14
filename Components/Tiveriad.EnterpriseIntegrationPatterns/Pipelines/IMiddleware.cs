namespace Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

public interface IMiddleware<TModel, TPipelineContext, TConfiguration>
    where TPipelineContext : class, IPipelineContext<TConfiguration>
    where TConfiguration : class, IPipelineConfiguration
{
    public Task Run(TPipelineContext context, TModel model);
}