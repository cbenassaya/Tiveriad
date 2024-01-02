//-------------------------------------------------------------------------------

#region

#endregion

using Tiveriad.Commons.Optionals;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Contexts;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Events;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Models;

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Extensions;

public class InternalExtension<TState, TEvent> : IExtensionInternal<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    private readonly IExtension<TState, TEvent> apiExtension;
    private readonly IStateMachineInformation<TState, TEvent> stateMachineInformation;

    public InternalExtension(
        IExtension<TState, TEvent> apiExtension,
        IStateMachineInformation<TState, TEvent> stateMachineInformation)
    {
        this.apiExtension = apiExtension;
        this.stateMachineInformation = stateMachineInformation;
    }

    public Task StartedStateMachine()
    {
        return apiExtension.StartedStateMachine(stateMachineInformation);
    }

    public Task StoppedStateMachine()
    {
        return apiExtension.StoppedStateMachine(stateMachineInformation);
    }

    public Task EventQueued(TEvent eventId, object eventArgument)
    {
        return apiExtension.EventQueued(stateMachineInformation, eventId, eventArgument);
    }

    public Task EventQueuedWithPriority(TEvent eventId, object eventArgument)
    {
        return apiExtension.EventQueuedWithPriority(stateMachineInformation, eventId, eventArgument);
    }

    public Task SwitchedState(IStateDefinition<TState, TEvent> oldState, IStateDefinition<TState, TEvent> newState)
    {
        return apiExtension.SwitchedState(stateMachineInformation, oldState, newState);
    }

    public Task EnteringInitialState(TState state)
    {
        return apiExtension.EnteringInitialState(stateMachineInformation, state);
    }

    public Task EnteredInitialState(TState state, ITransitionContext<TState, TEvent> context)
    {
        return apiExtension.EnteredInitialState(stateMachineInformation, state, context);
    }

    public Task FiringEvent(ref TEvent eventId, ref object eventArgument)
    {
        return apiExtension.FiringEvent(stateMachineInformation, ref eventId, ref eventArgument);
    }

    public Task FiredEvent(ITransitionContext<TState, TEvent> context)
    {
        return apiExtension.FiredEvent(stateMachineInformation, context);
    }

    public Task HandlingEntryActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ref Exception exception)
    {
        return apiExtension.HandlingEntryActionException(stateMachineInformation, stateDefinition, context,
            ref exception);
    }

    public Task HandledEntryActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        Exception exception)
    {
        return apiExtension.HandledEntryActionException(stateMachineInformation, stateDefinition, context, exception);
    }

    public Task HandlingExitActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ref Exception exception)
    {
        return apiExtension.HandlingExitActionException(stateMachineInformation, stateDefinition, context,
            ref exception);
    }

    public Task HandledExitActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        Exception exception)
    {
        return apiExtension.HandledExitActionException(stateMachineInformation, stateDefinition, context, exception);
    }

    public Task HandlingGuardException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext,
        ref Exception exception)
    {
        return apiExtension.HandlingGuardException(stateMachineInformation, transitionDefinition, transitionContext,
            ref exception);
    }

    public Task HandledGuardException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext,
        Exception exception)
    {
        return apiExtension.HandledGuardException(stateMachineInformation, transitionDefinition, transitionContext,
            exception);
    }

    public Task HandlingTransitionException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> context,
        ref Exception exception)
    {
        return apiExtension.HandlingTransitionException(stateMachineInformation, transitionDefinition, context,
            ref exception);
    }

    public Task HandledTransitionException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext,
        Exception exception)
    {
        return apiExtension.HandledTransitionException(stateMachineInformation, transitionDefinition, transitionContext,
            exception);
    }

    public Task SkippedTransition(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> context)
    {
        return apiExtension.SkippedTransition(stateMachineInformation, transitionDefinition, context);
    }

    public Task ExecutingTransition(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext)
    {
        return apiExtension.ExecutingTransition(stateMachineInformation, transitionDefinition, transitionContext);
    }

    public Task ExecutedTransition(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext)
    {
        return apiExtension.ExecutedTransition(stateMachineInformation, transitionDefinition, transitionContext);
    }

    public Task Loaded(
        IInitializable<TState> loadedCurrentState,
        IReadOnlyDictionary<TState, TState> loadedHistoryStates,
        IReadOnlyCollection<EventInformation<TEvent>> events,
        IReadOnlyCollection<EventInformation<TEvent>> priorityEvents)
    {
        return apiExtension.Loaded(stateMachineInformation, loadedCurrentState, loadedHistoryStates, events,
            priorityEvents);
    }

    public Task EnteringState(IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context)
    {
        return apiExtension.EnteringState(stateMachineInformation, stateDefinition, context);
    }
}