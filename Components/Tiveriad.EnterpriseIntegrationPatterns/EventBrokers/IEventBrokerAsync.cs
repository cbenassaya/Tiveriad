namespace Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

/// <summary>
/// Represents an event broker.
/// </summary>
public interface IEventBroker : IDisposable
{
    /// <summary>
    /// Adds subscription for events of type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <typeparam name="TKey">The key of event</typeparam>
    /// <param name="handler">A delegate that will be invoked when event is published.</param>
    /// <param name="filter">A delegate used to perform filtering of events before invoking the handler.</param>
    /// <param name="onError">Called when an error is caught during execution.</param>
    void Subscribe<TEvent,TKey>(Func<TEvent, Task> handler, Func<TEvent, Task<bool>> filter = null, Func<Exception, TEvent, Task> onError = null)
        where TEvent:IDomainEvent < TKey> 
        where TKey : IEquatable<TKey>;

    /// <summary>
    /// Adds subscription for events of type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <typeparam name="TKey">The key of event</typeparam>
    /// <param name="handler">An instance of IEventHandler&lt;TEvent&gt; which Handle method will be invoked when event is published.</param>
    void Subscribe<TEvent,TKey>(IEventHandler<TEvent,TKey> handler)
        where TEvent:IDomainEvent < TKey> 
        where TKey : IEquatable<TKey>;

    /// <summary>
    /// Removes subscription for events of type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <typeparam name="TKey">The key of event</typeparam>
    /// <param name="handler">A delegate to remove form subscribers.</param>
    void Unsubscribe<TEvent,TKey>(Func<TEvent, Task> handler)
        where TEvent:IDomainEvent < TKey> 
        where TKey : IEquatable<TKey>;

    /// <summary>
    /// Removes subscription for events of type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <typeparam name="TKey">The key of event</typeparam>
    /// <param name="handler">An instance of IEventHandler&lt;TEvent&gt; to remove form subscribers.</param>
    void Unsubscribe<TEvent,TKey>(IEventHandler<TEvent,TKey> handler)
        where TEvent:IDomainEvent < TKey> 
        where TKey : IEquatable<TKey>;

    /// <summary>
    /// Publishes an event of type <typeparamref name="TEvent"/>.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <typeparam name="TKey">The key of event</typeparam>
    /// <param name="event">An <typeparamref name="TEvent"/> instance to be passed to all handlers of the event.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    Task PublishAsync<TEvent,TKey>(TEvent @event)
        where TEvent:IDomainEvent < TKey> 
        where TKey : IEquatable<TKey>;
}