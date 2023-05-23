#region

using Tiveriad.EnterpriseIntegrationPatterns.ServiceResolvers;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.Mediators;

public class RequestHandlerWrapper<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IServiceResolver _serviceResolver;

    public RequestHandlerWrapper(IServiceResolver serviceResolver)
    {
        _serviceResolver = serviceResolver;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var handler =
            _serviceResolver.GetService(typeof(IRequestHandler<TRequest, TResponse>)) as
                IRequestHandler<TRequest, TResponse>
            ?? throw new InvalidOperationException($"Could not get handler request {typeof(TRequest)}");
        return handler.Handle(request, cancellationToken);
    }
}