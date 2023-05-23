//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.Events;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Persistence;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines;

/// <summary>
///     A state machine.
/// </summary>
/// <typeparam name="TState">The type of the state.</typeparam>
/// <typeparam name="TEvent">The type of the event.</typeparam>
public interface IAsyncStateMachine<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    /// <summary>
    ///     Gets a value indicating whether this instance is running. The state machine is running if if was started and not
    ///     yet stopped.
    /// </summary>
    /// <value><c>true</c> if this instance is running; otherwise, <c>false</c>.</value>
    bool IsRunning { get; }

    /// <summary>
    ///     Occurs when no transition could be executed.
    /// </summary>
    event EventHandler<TransitionEventArgs<TState, TEvent>> TransitionDeclined;

    /// <summary>
    ///     Occurs when an exception was thrown inside a transition of the state machine.
    /// </summary>
    event EventHandler<TransitionExceptionEventArgs<TState, TEvent>> TransitionExceptionThrown;

    /// <summary>
    ///     Occurs when a transition begins.
    /// </summary>
    event EventHandler<TransitionEventArgs<TState, TEvent>> TransitionBegin;

    /// <summary>
    ///     Occurs when a transition completed.
    /// </summary>
    event EventHandler<TransitionCompletedEventArgs<TState, TEvent>> TransitionCompleted;

    /// <summary>
    ///     Fires the specified event.
    /// </summary>
    /// <param name="eventId">The event.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    Task Fire(TEvent eventId);

    /// <summary>
    ///     Fires the specified event.
    /// </summary>
    /// <param name="eventId">The event.</param>
    /// <param name="eventArgument">The event argument.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    Task Fire(TEvent eventId, object eventArgument);

    /// <summary>
    ///     Fires the specified priority event. The event will be handled before any already queued event.
    /// </summary>
    /// <param name="eventId">The event.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    Task FirePriority(TEvent eventId);

    /// <summary>
    ///     Fires the specified priority event. The event will be handled before any already queued event.
    /// </summary>
    /// <param name="eventId">The event.</param>
    /// <param name="eventArgument">The event argument.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    Task FirePriority(TEvent eventId, object eventArgument);

    /// <summary>
    ///     Starts the state machine. Events will be processed.
    ///     If the state machine is not started then the events will be queued until the state machine is started.
    ///     Already queued events are processed.
    /// </summary>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    Task Start();

    /// <summary>
    ///     Stops the state machine. Events will be queued until the state machine is started.
    /// </summary>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    Task Stop();

    /// <summary>
    ///     Adds an extension.
    /// </summary>
    /// <param name="extension">The extension.</param>
    void AddExtension(IExtension<TState, TEvent> extension);

    /// <summary>
    ///     Clears all extensions.
    /// </summary>
    void ClearExtensions();

    /// <summary>
    ///     Creates a state machine report with the specified generator.
    /// </summary>
    /// <param name="reportGenerator">The report generator.</param>
    void Report(IStateMachineReport<TState, TEvent> reportGenerator);

    /// <summary>
    ///     Saves the current state and history states to a persisted state. Can be restored using
    ///     <see cref="Load(IAsyncStateMachineLoader{TState,TEvent})" />.
    /// </summary>
    /// <param name="stateMachineSaver">Data to be persisted is passed to the saver.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    Task Save(IAsyncStateMachineSaver<TState, TEvent> stateMachineSaver);

    /// <summary>
    ///     Loads the current state and history states from a persisted state (
    ///     <see cref="Save(IAsyncStateMachineSaver{TState, TEvent})" />).
    ///     The loader should return exactly the data that was passed to the saver.
    /// </summary>
    /// <param name="stateMachineLoader">Loader providing persisted data.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    Task Load(IAsyncStateMachineLoader<TState, TEvent> stateMachineLoader);
}