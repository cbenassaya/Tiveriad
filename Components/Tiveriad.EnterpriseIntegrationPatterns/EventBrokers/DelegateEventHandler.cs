using Tiveriad.Core.Abstractions.DomainEvents;

namespace Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

/// <summary>
///     An adapter used to represent delegate as IEventHandler.
/// </summary>
/// <typeparam name="TEvent">The type of the event to be handled.</typeparam>
/// <typeparam name="TKey">The key of event</typeparam>
public class DelegateEventHandler<TEvent, TKey> : IEventHandler<TEvent, TKey>
    where TEvent : IDomainEvent<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly Func<TEvent, Task<bool>> _filter;
    private readonly Func<TEvent, Task> _handler;
    private readonly Func<Exception, TEvent, Task> _onError;

    /// <summary>
    ///     Creates a new instance of the DelegateEventHandler class.
    /// </summary>
    /// <param name="handler">A delegate used for event handling.</param>
    /// <param name="filter">A delegate used to determine whether the event should be handled.</param>
    /// <param name="onError">A delegate called when an error is caught during execution.</param>
    public DelegateEventHandler(Func<TEvent, Task> handler, Func<TEvent, Task<bool>> filter = null,
        Func<Exception, TEvent, Task> onError = null)
    {
        _handler = handler;
        _filter = filter;
        _onError = onError;
    }

    /// <summary>
    ///     Handles the event.
    /// </summary>
    /// <param name="event">An instance of TEvent representing the event.</param>
    public Task HandleAsync(TEvent @event)
    {
        return _handler(@event);
    }

    /// <summary>
    ///     Called when an error is caught during execution.
    /// </summary>
    /// <param name="exception">The exception caught.</param>
    /// <param name="event">The event instance which handling caused the exception.</param>
    public Task OnErrorAsync(Exception exception, TEvent @event)
    {
        return _onError?.Invoke(exception, @event);
    }

    /// <summary>
    ///     Returns a value indicating whether the event handler should be executed.
    /// </summary>
    /// <param name="event">An instance of TEvent representing the event.</param>
    /// <returns>A value indicating whether the event handler should be executed.</returns>
    public Task<bool> ShouldHandleAsync(TEvent @event)
    {
        if (_filter is null) return Task.FromResult(true);

        return _filter(@event);
    }
}