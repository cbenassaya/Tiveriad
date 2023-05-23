//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.States;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.Transitions;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Infrastructure;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine;

public class InternalExtensionBase<TState, TEvent> : IExtensionInternal<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    public virtual Task StartedStateMachine()
    {
        return Task.FromResult(0);
    }

    public virtual Task StoppedStateMachine()
    {
        return Task.FromResult(0);
    }

    public virtual Task EventQueued(TEvent eventId, object eventArgument)
    {
        return Task.FromResult(0);
    }

    public virtual Task EventQueuedWithPriority(TEvent eventId, object eventArgument)
    {
        return Task.FromResult(0);
    }

    public virtual Task SwitchedState(IStateDefinition<TState, TEvent> oldState,
        IStateDefinition<TState, TEvent> newState)
    {
        return Task.FromResult(0);
    }

    public virtual Task EnteringInitialState(TState state)
    {
        return Task.FromResult(0);
    }

    public virtual Task EnteredInitialState(TState state, ITransitionContext<TState, TEvent> context)
    {
        return Task.FromResult(0);
    }

    public virtual Task FiringEvent(ref TEvent eventId, ref object eventArgument)
    {
        return Task.FromResult(0);
    }

    public virtual Task FiredEvent(ITransitionContext<TState, TEvent> context)
    {
        return Task.FromResult(0);
    }

    public virtual Task HandlingEntryActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ref Exception exception)
    {
        return Task.FromResult(0);
    }

    public virtual Task HandledEntryActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        Exception exception)
    {
        return Task.FromResult(0);
    }

    public virtual Task HandlingExitActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ref Exception exception)
    {
        return Task.FromResult(0);
    }

    public virtual Task HandledExitActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        Exception exception)
    {
        return Task.FromResult(0);
    }

    public virtual Task HandlingGuardException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext,
        ref Exception exception)
    {
        return Task.FromResult(0);
    }

    public virtual Task HandledGuardException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext,
        Exception exception)
    {
        return Task.FromResult(0);
    }

    public virtual Task HandlingTransitionException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> context,
        ref Exception exception)
    {
        return Task.FromResult(0);
    }

    public virtual Task HandledTransitionException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext,
        Exception exception)
    {
        return Task.FromResult(0);
    }

    public virtual Task SkippedTransition(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> context)
    {
        return Task.FromResult(0);
    }

    public virtual Task ExecutingTransition(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext)
    {
        return Task.FromResult(0);
    }

    public virtual Task ExecutedTransition(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext)
    {
        return Task.FromResult(0);
    }

    public virtual Task Loaded(
        IInitializable<TState> loadedCurrentState,
        IReadOnlyDictionary<TState, TState> loadedHistoryStates,
        IReadOnlyCollection<EventInformation<TEvent>> events,
        IReadOnlyCollection<EventInformation<TEvent>> priorityEvents)
    {
        return Task.FromResult(0);
    }

    public Task EnteringState(IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context)
    {
        return Task.FromResult(0);
    }
}