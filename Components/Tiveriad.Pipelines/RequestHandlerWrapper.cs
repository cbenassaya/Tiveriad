namespace Tiveriad.Pipelines;

public class RequestHandlerWrapper<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private IServiceResolver _serviceResolver;

    public RequestHandlerWrapper(IServiceResolver serviceResolver)
    {
        _serviceResolver = serviceResolver;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var handler = _serviceResolver.Resolve(typeof(TRequest)) as IRequestHandler<TRequest, TResponse>
                      ?? throw new InvalidOperationException($"Could not get handler request {typeof(TRequest)}");
        return handler.Handle(request, cancellationToken);
    }
}