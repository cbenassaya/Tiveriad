//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Infrastructure;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.States;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.Transitions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine;

public interface IExtensionInternal<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    void StartedStateMachine();

    void StoppedStateMachine();

    void EventQueued(TEvent eventId, object eventArgument);

    void EventQueuedWithPriority(TEvent eventId, object eventArgument);

    void SwitchedState(IStateDefinition<TState, TEvent> oldState, IStateDefinition<TState, TEvent> newState);

    void EnteringInitialState(TState state);

    void EnteredInitialState(TState state, ITransitionContext<TState, TEvent> context);

    void FiringEvent(
        ref TEvent eventId,
        ref object eventArgument);

    void FiredEvent(ITransitionContext<TState, TEvent> context);

    void HandlingEntryActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ref Exception exception);

    void HandledEntryActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        Exception exception);

    void HandlingExitActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ref Exception exception);

    void HandledExitActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        Exception exception);

    void HandlingGuardException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext,
        ref Exception exception);

    void HandledGuardException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext,
        Exception exception);

    void HandlingTransitionException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> context,
        ref Exception exception);

    void HandledTransitionException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext,
        Exception exception);

    void SkippedTransition(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> context);

    void ExecutingTransition(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> context);

    void ExecutedTransition(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> context);

    void Loaded(
        IInitializable<TState> loadedCurrentState,
        IReadOnlyDictionary<TState, TState> loadedHistoryStates,
        IReadOnlyCollection<EventInformation<TEvent>> events);

    void EnteringState(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context);
}