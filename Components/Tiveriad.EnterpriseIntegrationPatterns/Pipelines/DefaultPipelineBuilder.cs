#region

#endregion

using Tiveriad.ServiceResolvers;

namespace Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

public class
    DefaultPipelineBuilder<TPipelineContext,TModel,  TConfiguration> : IPipelineBuilder<TPipelineContext, TModel,TConfiguration>
        where TPipelineContext : class, IPipelineContext<TModel, TConfiguration>
        where TModel : class
        where TConfiguration : class, IPipelineConfiguration
{
    private readonly TConfiguration _configuration;

    private readonly List<Func<TPipelineContext,RequestDelegate<TPipelineContext, TModel,TConfiguration>, Task>> _nodes = new();

    private readonly IServiceResolver _serviceResolver;

    private Action<Exception,TPipelineContext>? _exceptionHandler;

    public DefaultPipelineBuilder(IServiceResolver serviceResolver)
    {
        _serviceResolver = serviceResolver;
        _configuration = Activator.CreateInstance<TConfiguration>();
    }

    public IPipelineBuilder<TPipelineContext, TModel,TConfiguration> Configure(Action<TConfiguration> action)
    {
        action(_configuration);
        return this;
    }

    public IPipelineBuilder<TPipelineContext, TModel,TConfiguration> WithExceptionHandler(Action<Exception,TPipelineContext> action)
    {
        _exceptionHandler = action;
        return this;
    }
    
    

    
    public IPipelineBuilder<TPipelineContext, TModel,TConfiguration> Use(
        Func<TPipelineContext,RequestDelegate<TPipelineContext, TModel,TConfiguration>, Task> node
        )
    {
        _nodes.Add(node);
        return this;
    }
    
    public IPipelineBuilder<TPipelineContext, TModel,TConfiguration> Use(
        Func<RequestDelegate<TPipelineContext, TModel,TConfiguration>, Task> node
    )
    {
        Func<TPipelineContext, RequestDelegate<TPipelineContext, TModel, TConfiguration>, Task> innerNode =
            (current, next) => node(next);
        _nodes.Add(innerNode);
        return this;
    }



    public IPipelineBuilder<TPipelineContext, TModel,TConfiguration> Add<TMiddleware>()
        where TMiddleware : IMiddleware<TPipelineContext, TModel,TConfiguration>
    {
        var middleware =
            (IMiddleware<TPipelineContext, TModel,TConfiguration>)_serviceResolver.GetService(typeof(TMiddleware));
        Func< TPipelineContext, RequestDelegate<TPipelineContext, TModel, TConfiguration>, Task> innerNode =
            (context, next) => middleware.Run(context, next);
        _nodes.Add(innerNode);
        return this;
        
        
   
    }


    public IPipeline<TModel> Build()
    {
        RequestDelegate<TPipelineContext, TModel,TConfiguration> nextRequest = (context) => Task.CompletedTask;
        RequestDelegate<TPipelineContext, TModel,TConfiguration> currentRequest = (context) => Task.CompletedTask;
        
        for (var c = _nodes.Count - 1; c >= 0; c--)
        {
            var innerNode = _nodes[c];
            var request = nextRequest;
            currentRequest =  (context) =>
            {
                try
                { 
                    return innerNode(context, request);
                }
                catch (Exception e)
                {
                    if (_exceptionHandler != null)
                        _exceptionHandler(e,context);
                    return Task.CompletedTask;
                }
              
            };
            nextRequest = currentRequest;
        }

        return new DefaultPipeline< TPipelineContext, TModel, TConfiguration>(_configuration, currentRequest);
    }
}