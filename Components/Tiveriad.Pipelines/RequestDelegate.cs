namespace Tiveriad.Pipelines;

public delegate Task RequestDelegate<TModel, TPipelineContext, TConfiguration>(TPipelineContext context, TModel model)
    where TPipelineContext : class, IPipelineContext<TConfiguration>
    where TConfiguration : class, IPipelineConfiguration;
    
    
