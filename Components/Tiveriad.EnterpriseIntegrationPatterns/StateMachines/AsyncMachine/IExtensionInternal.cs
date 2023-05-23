//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.States;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.Transitions;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Infrastructure;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine;

public interface IExtensionInternal<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    Task StartedStateMachine();

    Task StoppedStateMachine();

    Task EventQueued(TEvent eventId, object eventArgument);

    Task EventQueuedWithPriority(TEvent eventId, object eventArgument);

    Task SwitchedState(IStateDefinition<TState, TEvent> oldState, IStateDefinition<TState, TEvent> newState);

    Task EnteringInitialState(TState state);

    Task EnteredInitialState(TState state, ITransitionContext<TState, TEvent> context);

    Task FiringEvent(
        ref TEvent eventId,
        ref object eventArgument);

    Task FiredEvent(ITransitionContext<TState, TEvent> context);

    Task HandlingEntryActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ref Exception exception);

    Task HandledEntryActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        Exception exception);

    Task HandlingExitActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ref Exception exception);

    Task HandledExitActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        Exception exception);

    Task HandlingGuardException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext,
        ref Exception exception);

    Task HandledGuardException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext,
        Exception exception);

    Task HandlingTransitionException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> context,
        ref Exception exception);

    Task HandledTransitionException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext,
        Exception exception);

    Task SkippedTransition(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> context);

    Task ExecutingTransition(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> context);

    Task ExecutedTransition(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> context);

    Task Loaded(
        IInitializable<TState> loadedCurrentState,
        IReadOnlyDictionary<TState, TState> loadedHistoryStates,
        IReadOnlyCollection<EventInformation<TEvent>> events,
        IReadOnlyCollection<EventInformation<TEvent>> priorityEvents);

    Task EnteringState(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context);
}