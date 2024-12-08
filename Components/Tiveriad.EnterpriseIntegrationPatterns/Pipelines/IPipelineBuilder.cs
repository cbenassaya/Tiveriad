namespace Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

public interface IPipelineBuilder<TPipelineContext, TModel, TConfiguration>
    where TPipelineContext : class, IPipelineContext<TModel, TConfiguration>
    where TModel : class
    where TConfiguration : class, IPipelineConfiguration
{
    IPipelineBuilder<TPipelineContext,TModel,  TConfiguration> Configure(Action<TConfiguration> action);
    IPipelineBuilder<TPipelineContext, TModel,  TConfiguration> WithExceptionHandler(Action<Exception,TPipelineContext> action);

    public IPipelineBuilder<TPipelineContext, TModel,TConfiguration> Add<TMiddleware>()
        where TMiddleware : IMiddleware<TPipelineContext, TModel,TConfiguration>;
    
    public IPipelineBuilder<TPipelineContext, TModel,TConfiguration> Use(
        Func<RequestDelegate<TPipelineContext, TModel,TConfiguration>, Task> node
    );
    
    public IPipelineBuilder<TPipelineContext, TModel,TConfiguration> Use(
        Func<TPipelineContext,RequestDelegate<TPipelineContext, TModel,TConfiguration>, Task> node
    );
    


    IPipeline<TModel> Build();
}