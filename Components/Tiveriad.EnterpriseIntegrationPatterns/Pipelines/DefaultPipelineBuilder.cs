using Tiveriad.EnterpriseIntegrationPatterns.ServiceResolvers;

namespace Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

public class
    DefaultPipelineBuilder<TModel, TPipelineContext, TConfiguration> : IPipelineBuilder<TModel, TPipelineContext,
        TConfiguration> where TPipelineContext : class, IPipelineContext<TConfiguration>
    where TConfiguration : class, IPipelineConfiguration
{
    private readonly TConfiguration _configuration;

    private Action<Exception>? _exceptionHandler;

    private readonly List<RequestDelegate<TModel, TPipelineContext, TConfiguration>> _middlewares = new();


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
    
    public IPipelineBuilder<TModel, TPipelineContext, TConfiguration> WithExceptionHandler(Action<Exception> action)
    {
        _exceptionHandler = action;
        return this;
    }

    public IPipelineBuilder<TModel, TPipelineContext, TConfiguration> Use(RequestDelegate<TModel, TPipelineContext, TConfiguration> middleware)
    {
        _middlewares.Add(middleware);
        return this;
    }


    public IPipelineBuilder<TModel, TPipelineContext, TConfiguration> Add<TMiddleware>()
        where TMiddleware : IMiddleware<TModel, TPipelineContext, TConfiguration>
    {
        return Use((context, model) =>
        {
            var middleware = (IMiddleware<TModel, TPipelineContext, TConfiguration>)_serviceResolver.GetService(typeof(TMiddleware));
            return middleware.Run(context, model);
        });
    }



    public IPipeline<TModel> Build()
    {
        RequestDelegate<TModel, TPipelineContext, TConfiguration> nextAction = (context,model ) => Task.CompletedTask;
        RequestDelegate<TModel, TPipelineContext, TConfiguration>? currentAction = null;
        for (var c = _middlewares.Count - 1; c >= 0; c--)
        {
            var next = nextAction;
            var innerMiddleware = _middlewares[c];
           
            currentAction = async (context, model)  =>
            {
                var noException = true;
                try
                {
                    await innerMiddleware(context,model);
                }
                catch (Exception e)
                {
                    noException = false;
                    if (_exceptionHandler != null)
                    {
                        _exceptionHandler(e);
                    } else
                        throw e;
                }
                if (noException)
                    await next(context,model);
            };
            nextAction = currentAction;
        }
        return new DefaultPipeline<TModel, TPipelineContext, TConfiguration>(_configuration, currentAction);
    }
}