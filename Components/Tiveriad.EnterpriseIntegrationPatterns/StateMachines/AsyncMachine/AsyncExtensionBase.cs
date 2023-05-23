//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.States;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.Transitions;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Infrastructure;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine;

/// <summary>
///     Base class for state machine extensions with empty implementation.
/// </summary>
/// <typeparam name="TState">The type of the state.</typeparam>
/// <typeparam name="TEvent">The type of the event.</typeparam>
public class AsyncExtensionBase<TState, TEvent> : IExtension<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    /// <summary>
    ///     Starts the state machine.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task StartedStateMachine(IStateMachineInformation<TState, TEvent> stateMachine)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Stops the state machine.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task StoppedStateMachine(IStateMachineInformation<TState, TEvent> stateMachine)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Events the queued.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="eventId">The event id.</param>
    /// <param name="eventArgument">The event argument.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task EventQueued(IStateMachineInformation<TState, TEvent> stateMachine, TEvent eventId,
        object eventArgument)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Events the queued with priority.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="eventId">The event id.</param>
    /// <param name="eventArgument">The event argument.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task EventQueuedWithPriority(IStateMachineInformation<TState, TEvent> stateMachine, TEvent eventId,
        object eventArgument)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called after the state machine switched states.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="oldState">The old state.</param>
    /// <param name="newState">The new state.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task SwitchedState(IStateMachineInformation<TState, TEvent> stateMachine,
        IStateDefinition<TState, TEvent> oldState, IStateDefinition<TState, TEvent> newState)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called when the state machine enters the initial state.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="state">The state.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task EnteringInitialState(IStateMachineInformation<TState, TEvent> stateMachine, TState state)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called when the state machine entered the initial state.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="state">The state.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task EnteredInitialState(IStateMachineInformation<TState, TEvent> stateMachine, TState state,
        ITransitionContext<TState, TEvent> context)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called when an event is firing on the state machine.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="eventId">The event id. Can be replaced by the extension.</param>
    /// <param name="eventArgument">The event argument. Can be replaced by the extension.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task FiringEvent(IStateMachineInformation<TState, TEvent> stateMachine, ref TEvent eventId,
        ref object eventArgument)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called when an event was fired on the state machine.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="context">The transition context.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task FiredEvent(IStateMachineInformation<TState, TEvent> stateMachine,
        ITransitionContext<TState, TEvent> context)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called before an entry action exception is handled.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="stateDefinition">The state.</param>
    /// <param name="context">The context.</param>
    /// <param name="exception">The exception. Can be replaced by the extension.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task HandlingEntryActionException(IStateMachineInformation<TState, TEvent> stateMachine,
        IStateDefinition<TState, TEvent> stateDefinition, ITransitionContext<TState, TEvent> context,
        ref Exception exception)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called after an entry action exception was handled.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="stateDefinition">The state.</param>
    /// <param name="context">The context.</param>
    /// <param name="exception">The exception.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task HandledEntryActionException(IStateMachineInformation<TState, TEvent> stateMachine,
        IStateDefinition<TState, TEvent> stateDefinition, ITransitionContext<TState, TEvent> context,
        Exception exception)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called before an exit action exception is handled.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="stateDefinition">The state.</param>
    /// <param name="context">The context.</param>
    /// <param name="exception">The exception. Can be replaced by the extension.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task HandlingExitActionException(IStateMachineInformation<TState, TEvent> stateMachine,
        IStateDefinition<TState, TEvent> stateDefinition, ITransitionContext<TState, TEvent> context,
        ref Exception exception)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called after an exit action exception was handled.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="stateDefinition">The state.</param>
    /// <param name="context">The context.</param>
    /// <param name="exception">The exception.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task HandledExitActionException(IStateMachineInformation<TState, TEvent> stateMachine,
        IStateDefinition<TState, TEvent> stateDefinition, ITransitionContext<TState, TEvent> context,
        Exception exception)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called before a guard exception is handled.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="transitionDefinition">The transition.</param>
    /// <param name="transitionContext">The transition context.</param>
    /// <param name="exception">The exception. Can be replaced by the extension.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task HandlingGuardException(IStateMachineInformation<TState, TEvent> stateMachine,
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext, ref Exception exception)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called after a guard exception was handled.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="transitionDefinition">The transition.</param>
    /// <param name="transitionContext">The transition context.</param>
    /// <param name="exception">The exception.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task HandledGuardException(IStateMachineInformation<TState, TEvent> stateMachine,
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext, Exception exception)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called before a transition exception is handled.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="transitionDefinition">The transition.</param>
    /// <param name="context">The context.</param>
    /// <param name="exception">The exception. Can be replaced by the extension.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task HandlingTransitionException(IStateMachineInformation<TState, TEvent> stateMachine,
        ITransitionDefinition<TState, TEvent> transitionDefinition, ITransitionContext<TState, TEvent> context,
        ref Exception exception)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called after a transition exception is handled.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="transitionDefinition">The transition.</param>
    /// <param name="transitionContext">The transition context.</param>
    /// <param name="exception">The exception.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task HandledTransitionException(IStateMachineInformation<TState, TEvent> stateMachine,
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext, Exception exception)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called when a transition is skipped because its guard returned false.
    /// </summary>
    /// <param name="stateMachineInformation">The state machine.</param>
    /// <param name="transitionDefinition">The transition.</param>
    /// <param name="context">The transition context.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task SkippedTransition(
        IStateMachineInformation<TState, TEvent> stateMachineInformation,
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> context)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called when a transition is going to be executed. After the guard of the transition evaluated to true.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="transitionDefinition">The transition.</param>
    /// <param name="transitionContext">The transition context.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task ExecutingTransition(
        IStateMachineInformation<TState, TEvent> stateMachine,
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext)
    {
        return Task.FromResult(0);
    }

    /// <summary>
    ///     Called when a transition was executed.
    /// </summary>
    /// <param name="stateMachine">The state machine.</param>
    /// <param name="transitionDefinition">The transition.</param>
    /// <param name="transitionContext">The transition context.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public virtual Task ExecutedTransition(
        IStateMachineInformation<TState, TEvent> stateMachine,
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext)
    {
        return Task.FromResult(0);
    }

    public virtual Task EnteringState(
        IStateMachineInformation<TState, TEvent> stateMachine,
        IStateDefinition<TState, TEvent> state,
        ITransitionContext<TState, TEvent> context)
    {
        return Task.FromResult(0);
    }

    public virtual Task Loaded(
        IStateMachineInformation<TState, TEvent> stateMachineInformation,
        IInitializable<TState> loadedCurrentState,
        IReadOnlyDictionary<TState, TState> loadedHistoryStates,
        IReadOnlyCollection<EventInformation<TEvent>> events,
        IReadOnlyCollection<EventInformation<TEvent>> priorityEvents)
    {
        return Task.FromResult(0);
    }
}