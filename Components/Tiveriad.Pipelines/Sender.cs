using System.Collections.Concurrent;

namespace Tiveriad.Pipelines;

public class Sender : ISender
{
    private static readonly ConcurrentDictionary<Type, object> _requestHandlers = new();

    private readonly IServiceResolver _serviceResolver;

    public Sender(IServiceResolver serviceResolver)
    {
        _serviceResolver = serviceResolver;
    }

    public Task<TResponse>? Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        var requestType = request.GetType();
        var wrapper = _requestHandlers.GetOrAdd(
            requestType,
            t => Activator.CreateInstance(typeof(RequestHandlerWrapper<,>).MakeGenericType(t, typeof(TResponse)),
                     _serviceResolver)
                 ?? throw new InvalidOperationException($"Could not create wrapper type for {t}")
        );

        var method = wrapper.GetType().GetMethod("Handle")
                     ?? throw new InvalidOperationException(
                         $"Could not find Handle method on wrapper type for {requestType}");
        return method.Invoke(wrapper, new object[] { request, cancellationToken }) as Task<TResponse>;
    }
}