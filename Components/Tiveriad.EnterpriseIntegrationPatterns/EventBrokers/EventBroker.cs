#region

using System.Collections.Concurrent;
using Tiveriad.Core.Abstractions.DomainEvents;
using Tiveriad.ServiceResolvers;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

public class EventBroker : IEventBroker

{
    private readonly IEventHandlerRunner _runner;
    private readonly IServiceResolver? _serviceResolver;
    private readonly ConcurrentDictionary<Type, List<object>?> _subscribers = new();

    public EventBroker(IServiceResolver? serviceResolver, IEventHandlerRunner runner)
    {
        _serviceResolver = serviceResolver;
        _runner = runner;
    }

    /// <summary>
    ///     Adds subscription for events of type <typeparamref name="TEvent" />.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <typeparam name="TKey">The key of event</typeparam>
    /// <param name="handler">A delegate that will be invoked when event is published.</param>
    /// <param name="filter">A delegate used to perform filtering of events before invoking the handler.</param>
    /// <param name="onError">A delegate called when an error is caught during execution.</param>
    public void Subscribe<TEvent, TKey>(Func<TEvent, Task> handler, Func<TEvent, Task<bool>> filter = null,
        Func<Exception, TEvent, Task> onError = null)
        where TEvent : IDomainEvent<TKey>
        where TKey : IEquatable<TKey>
    {
        var handlers = _subscribers.GetOrAdd(typeof(TEvent), _ => new List<object>());
        handlers.Add(new EventHandlerWrapper<TEvent, TKey>(handler, filter, onError));
    }

    /// <summary>
    ///     Adds subscription for events of type <typeparamref name="TEvent" />.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <param name="handler">
    ///     An instance of IEventHandler&lt;TEvent&gt; which Handle method will be invoked when event is
    ///     published.
    /// </param>
    public void Subscribe<TEvent, TKey>(IEventHandler<TEvent, TKey> handler)
        where TEvent : IDomainEvent<TKey>
        where TKey : IEquatable<TKey>
    {
        var handlers = _subscribers.GetOrAdd(typeof(TEvent), _ => new List<object>());
        handlers.Add(new EventHandlerWrapper<TEvent, TKey>(handler));
    }

    /// <summary>
    ///     Removes subscription for events of type <typeparamref name="TEvent" />.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <param name="handler">A delegate to remove form subscribers.</param>
    public void Unsubscribe<TEvent, TKey>(Func<TEvent, Task> handler)
        where TEvent : IDomainEvent<TKey>
        where TKey : IEquatable<TKey>
    {
        Unsubscribe<TEvent, TKey>(x => x.IsWrapping(handler));
    }

    /// <summary>
    ///     Removes subscription for events of type <typeparamref name="TEvent" />.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <param name="handler">An instance of IEventHandler&lt;TEvent&gt; to remove form subscribers.</param>
    public void Unsubscribe<TEvent, TKey>(IEventHandler<TEvent, TKey> handler)
        where TEvent : IDomainEvent<TKey>
        where TKey : IEquatable<TKey>
    {
        Unsubscribe<TEvent, TKey>(x => x.IsWrapping(handler));
    }


    /// <summary>
    ///     Publishes an event of type <typeparamref name="TEvent" />.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <param name="event">
    ///     An <typeparamref name="TEvent" /> instance to be passed to all handlers of the event. All handlers
    ///     will be invoked asynchronously.
    /// </param>
    public async Task PublishAsync<TEvent, TKey>(TEvent @event)
        where TEvent : IDomainEvent<TKey>
        where TKey : IEquatable<TKey>
    {
        await EnqueueSubscribers<TEvent, TKey>(@event).ConfigureAwait(false);
        await EnqueueFromHandlersFactory<TEvent, TKey>(@event).ConfigureAwait(false);
    }

    /// <summary>
    ///     Releases all resources used by the current instance of the EventBroker class.
    /// </summary>
    public void Dispose()
    {
        _runner.Dispose();
    }


    private void Unsubscribe<TEvent, TKey>(Func<EventHandlerWrapper<TEvent, TKey>, bool> handlerPredicate)
        where TEvent : IDomainEvent<TKey>
        where TKey : IEquatable<TKey>
    {
        var handlers = _subscribers.GetOrAdd(typeof(TEvent), _ => new List<object>());
        var targetHandlers = handlers.Cast<EventHandlerWrapper<TEvent, TKey>>().ToArray();
        foreach (var handlerAction in targetHandlers.Where(x => handlerPredicate(x)))
        {
            handlers.Remove(handlerAction);
            handlerAction.IsSubscribed = false;
        }
    }

    private async Task EnqueueFromHandlersFactory<TEvent, TKey>(TEvent @event)
        where TEvent : IDomainEvent<TKey>
        where TKey : IEquatable<TKey>
    {
        if (_serviceResolver == null) return;

        var handlerInstances = _serviceResolver.GetServices(typeof(IEventHandler<TEvent, TKey>)).Select(x => x)
            .Cast<IEventHandler<TEvent, TKey>>().ToArray();

        if (!handlerInstances.Any()) return;

        Func<Task> CreateHandlerAction(IEventHandler<TEvent, TKey> handler)

        {
            return async () => await TryRunHandler(handler, @event).ConfigureAwait(false);
        }

        var handlerActions = handlerInstances.Select(CreateHandlerAction).ToArray();

        await _runner.RunAsync(handlerActions).ConfigureAwait(false);
    }

    private async Task EnqueueSubscribers<TEvent, TKey>(TEvent @event)
        where TEvent : IDomainEvent<TKey>
        where TKey : IEquatable<TKey>
    {
        var hasSubscribers = _subscribers.TryGetValue(typeof(TEvent), out var handlers);
        if (!hasSubscribers) return;

        if (handlers.Count == 0) return;

        Func<Task> CreateHandlerAction(EventHandlerWrapper<TEvent, TKey> handler)
        {
            return async () =>
            {
                if (!handler.IsSubscribed) return;

                await TryRunHandler(handler, @event).ConfigureAwait(false);
            };
        }

        var handlerActions =
            handlers.Cast<EventHandlerWrapper<TEvent, TKey>>()
                .Select(CreateHandlerAction)
                .ToArray();

        await _runner.RunAsync(handlerActions).ConfigureAwait(false);
    }

    private async Task TryRunHandler<TEvent, TKey>(IEventHandler<TEvent, TKey> handler, TEvent @event)
        where TEvent : IDomainEvent<TKey>
        where TKey : IEquatable<TKey>
    {
        try
        {
            if (!await handler.ShouldHandleAsync(@event).ConfigureAwait(false)) return;

            await handler.HandleAsync(@event).ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            await TryReportError(exception, handler, @event).ConfigureAwait(false);
        }
    }

    private async Task TryReportError<TEvent, TKey>(Exception exception, IEventHandler<TEvent, TKey> handler,
        TEvent @event)
        where TEvent : IDomainEvent<TKey>
        where TKey : IEquatable<TKey>
    {
        try
        {
            await handler.OnErrorAsync(exception, @event).ConfigureAwait(false);
        }
        catch
        {
            // yes, we mute exceptions here
        }
    }
}