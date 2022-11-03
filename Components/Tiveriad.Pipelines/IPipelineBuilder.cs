namespace Tiveriad.Pipelines;

public interface IPipelineBuilder<TModel, TPipelineContext, TConfiguration>
    where TPipelineContext : class, IPipelineContext<TConfiguration>
    where TConfiguration : class, IPipelineConfiguration
{

    IPipelineBuilder<TModel, TPipelineContext, TConfiguration> Configure(Action<TConfiguration> action);
    IPipelineBuilder<TModel, TPipelineContext, TConfiguration> WithExceptionHandler(Action<Exception> action);
    IPipelineBuilder<TModel, TPipelineContext, TConfiguration> Use(RequestDelegate<TModel, TPipelineContext, TConfiguration> middleware);

    IPipelineBuilder<TModel, TPipelineContext, TConfiguration> Add<TMiddleware>()
        where TMiddleware : IMiddleware<TModel, TPipelineContext, TConfiguration>;

    IPipeline<TModel> Build();
}