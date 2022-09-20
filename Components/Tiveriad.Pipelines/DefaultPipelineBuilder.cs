namespace Tiveriad.Pipelines;


public class
    DefaultPipelineBuilder<TModel, TPipelineContext, TConfiguration> : IPipelineBuilder<TModel, TPipelineContext,
        TConfiguration> where TPipelineContext : class, IPipelineContext<TConfiguration>
    where TConfiguration : class, IPipelineConfiguration
{
    private readonly TConfiguration _configuration;

    private readonly
        List<Func<RequestDelegate<TModel, TPipelineContext, TConfiguration>,
            RequestDelegate<TModel, TPipelineContext, TConfiguration>>> _middlewares = new();

    private readonly IServiceResolver _serviceResolver;

    public DefaultPipelineBuilder(IServiceResolver serviceResolver)
    {
        _serviceResolver = serviceResolver;
        _configuration = Activator.CreateInstance<TConfiguration>();
    }

    public IPipelineBuilder<TModel, TPipelineContext, TConfiguration> Configure(Action<TConfiguration> action)
    {
        action(_configuration);
        return this;
    }

    public IPipelineBuilder<TModel, TPipelineContext, TConfiguration> Use(
        Func<RequestDelegate<TModel, TPipelineContext, TConfiguration>,
            RequestDelegate<TModel, TPipelineContext, TConfiguration>> middleware)
    {
        _middlewares.Add(middleware);
        return this;
    }

    public IPipelineBuilder<TModel, TPipelineContext, TConfiguration> Use(
        Func<TPipelineContext, TModel, Func<Task>, Task> middleware)
    {
        return Use(next =>
        {
            return (context, model) =>
            {
                var simpleNext = () => next(context, model);
                return middleware(context, model, simpleNext);
            };
        });
    }

    public IPipelineBuilder<TModel, TPipelineContext, TConfiguration> Add<TMiddleware>()
        where TMiddleware : IMiddleware<TModel, TPipelineContext, TConfiguration>
    {
        return Use(async (context, model, next) =>
        {
            var middleware =
                (IMiddleware<TModel, TPipelineContext, TConfiguration>)_serviceResolver.Resolve(typeof(TMiddleware));
            middleware.Run(context, model);
            await next.Invoke(context, model);
        });
    }

    public IPipelineBuilder<TModel, TPipelineContext, TConfiguration> Use(
        Func<TPipelineContext, TModel, RequestDelegate<TModel, TPipelineContext, TConfiguration>, Task> middleware)
    {
        return Use(next => (context, model) => middleware(context, model, next));
    }


    public IPipeline<TModel> Build()
    {
        RequestDelegate<TModel, TPipelineContext, TConfiguration> app = (context, model) => Task.CompletedTask;

        for (var c = _middlewares.Count - 1; c >= 0; c--) app = _middlewares[c](app);

        return new DefaultPipeline<TModel, TPipelineContext, TConfiguration>(_configuration, app);
    }
}