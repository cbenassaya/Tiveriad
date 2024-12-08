namespace Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

public delegate Task RequestDelegate<TPipelineContext, TModel, TConfiguration>(TPipelineContext context)
    where TPipelineContext : class, IPipelineContext<TModel, TConfiguration>
    where TModel : class
    where TConfiguration : class, IPipelineConfiguration;