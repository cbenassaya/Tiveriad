namespace Tiveriad.Pipelines;

public interface IPipelineBuilder<TModel, TPipelineContext, TConfiguration>
    where TPipelineContext : class, IPipelineContext<TConfiguration>
    where TConfiguration : class, IPipelineConfiguration
{
    IPipelineBuilder<TModel, TPipelineContext, TConfiguration> Configure(Action<TConfiguration> action);

    IPipelineBuilder<TModel, TPipelineContext, TConfiguration> Use(
        Func<RequestDelegate<TModel, TPipelineContext, TConfiguration>,
            RequestDelegate<TModel, TPipelineContext, TConfiguration>> middleware);

    IPipelineBuilder<TModel, TPipelineContext, TConfiguration> Use(
        Func<TPipelineContext, TModel, Func<Task>, Task> middleware);

    IPipelineBuilder<TModel, TPipelineContext, TConfiguration> Use(
        Func<TPipelineContext, TModel, RequestDelegate<TModel, TPipelineContext, TConfiguration>, Task> middleware);

    IPipelineBuilder<TModel, TPipelineContext, TConfiguration> Add<TMiddleware>()
        where TMiddleware : IMiddleware<TModel, TPipelineContext, TConfiguration>;

    IPipeline<TModel> Build();
}