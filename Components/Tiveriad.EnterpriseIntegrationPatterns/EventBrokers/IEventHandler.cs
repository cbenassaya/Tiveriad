using Tiveriad.Core.Abstractions.DomainEvents;

namespace Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

/// <summary>
///     Represents a logic for handling events.
/// </summary>
/// <typeparam name="TEvent">The type of the event.</typeparam>
/// <typeparam name="TKey">The key of event</typeparam>
public interface IEventHandler<TEvent, TKey>
    where TEvent : IDomainEvent<TKey>
    where TKey : IEquatable<TKey>
{
    /// <summary>
    ///     Handles the event.
    /// </summary>
    /// <param name="event">An instance of TEvent representing the event.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    Task HandleAsync(TEvent @event);

    /// <summary>
    ///     Returns a value indicating whether the event handler should be executed.
    /// </summary>
    /// <param name="event">An instance of TEvent representing the event.</param>
    /// <returns>A value indicating whether the event handler should be executed.</returns>
    Task<bool> ShouldHandleAsync(TEvent @event);

    /// <summary>
    ///     Called when an error is caught during execution.
    /// </summary>
    /// <param name="exception">The exception caught.</param>
    /// <param name="event">The event instance which handling caused the exception.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    Task OnErrorAsync(Exception exception, TEvent @event);
}