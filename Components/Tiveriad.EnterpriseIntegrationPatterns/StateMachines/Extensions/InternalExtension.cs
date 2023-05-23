//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Infrastructure;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.States;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.Transitions;

#endregion

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

    public void StartedStateMachine()
    {
        apiExtension.StartedStateMachine(stateMachineInformation);
    }

    public void StoppedStateMachine()
    {
        apiExtension.StoppedStateMachine(stateMachineInformation);
    }

    public void EventQueued(TEvent eventId, object eventArgument)
    {
        apiExtension.EventQueued(stateMachineInformation, eventId, eventArgument);
    }

    public void EventQueuedWithPriority(TEvent eventId, object eventArgument)
    {
        apiExtension.EventQueuedWithPriority(stateMachineInformation, eventId, eventArgument);
    }

    public void SwitchedState(IStateDefinition<TState, TEvent> oldState, IStateDefinition<TState, TEvent> newState)
    {
        apiExtension.SwitchedState(stateMachineInformation, oldState, newState);
    }

    public void EnteringInitialState(TState state)
    {
        apiExtension.EnteringInitialState(stateMachineInformation, state);
    }

    public void EnteredInitialState(TState state, ITransitionContext<TState, TEvent> context)
    {
        apiExtension.EnteredInitialState(stateMachineInformation, state, context);
    }

    public void FiringEvent(ref TEvent eventId, ref object eventArgument)
    {
        apiExtension.FiringEvent(stateMachineInformation, ref eventId, ref eventArgument);
    }

    public void FiredEvent(ITransitionContext<TState, TEvent> context)
    {
        apiExtension.FiredEvent(stateMachineInformation, context);
    }

    public void HandlingEntryActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ref Exception exception)
    {
        apiExtension.HandlingEntryActionException(stateMachineInformation, stateDefinition, context, ref exception);
    }

    public void HandledEntryActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        Exception exception)
    {
        apiExtension.HandledEntryActionException(stateMachineInformation, stateDefinition, context, exception);
    }

    public void HandlingExitActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ref Exception exception)
    {
        apiExtension.HandlingExitActionException(stateMachineInformation, stateDefinition, context, ref exception);
    }

    public void HandledExitActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        Exception exception)
    {
        apiExtension.HandledExitActionException(stateMachineInformation, stateDefinition, context, exception);
    }

    public void HandlingGuardException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext,
        ref Exception exception)
    {
        apiExtension.HandlingGuardException(stateMachineInformation, transitionDefinition, transitionContext,
            ref exception);
    }

    public void HandledGuardException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext,
        Exception exception)
    {
        apiExtension.HandledGuardException(stateMachineInformation, transitionDefinition, transitionContext, exception);
    }

    public void HandlingTransitionException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> context,
        ref Exception exception)
    {
        apiExtension.HandlingTransitionException(stateMachineInformation, transitionDefinition, context, ref exception);
    }

    public void HandledTransitionException(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext,
        Exception exception)
    {
        apiExtension.HandledTransitionException(stateMachineInformation, transitionDefinition, transitionContext,
            exception);
    }

    public void SkippedTransition(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> context)
    {
        apiExtension.SkippedTransition(stateMachineInformation, transitionDefinition, context);
    }

    public void ExecutingTransition(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext)
    {
        apiExtension.ExecutingTransition(stateMachineInformation, transitionDefinition, transitionContext);
    }

    public void ExecutedTransition(
        ITransitionDefinition<TState, TEvent> transitionDefinition,
        ITransitionContext<TState, TEvent> transitionContext)
    {
        apiExtension.ExecutedTransition(stateMachineInformation, transitionDefinition, transitionContext);
    }

    public void Loaded(
        IInitializable<TState> loadedCurrentState,
        IReadOnlyDictionary<TState, TState> loadedHistoryStates,
        IReadOnlyCollection<EventInformation<TEvent>> events)
    {
        apiExtension.Loaded(stateMachineInformation, loadedCurrentState, loadedHistoryStates, events);
    }

    public void EnteringState(IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context)
    {
        apiExtension.EnteringState(stateMachineInformation, stateDefinition, context);
    }
}