namespace Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

public interface IMiddleware<TPipelineContext, TModel, TConfiguration>
    where TPipelineContext : class, IPipelineContext<TModel, TConfiguration>
    where TModel : class
    where TConfiguration : class, IPipelineConfiguration
{
    public Task Run(TPipelineContext context, RequestDelegate<TPipelineContext, TModel, TConfiguration> next);
}