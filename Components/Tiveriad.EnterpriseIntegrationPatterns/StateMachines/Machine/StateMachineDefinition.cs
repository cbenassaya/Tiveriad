//-------------------------------------------------------------------------------

#region

using Tiveriad.Commons.Extensions;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.States;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.Transitions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine;

public class StateMachineDefinition<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    private readonly IReadOnlyDictionary<TState, TState> initiallyLastActiveStates;
    private readonly TState initialState;
    private readonly IStateDefinitionDictionary<TState, TEvent> stateDefinitions;

    public StateMachineDefinition(
        IStateDefinitionDictionary<TState, TEvent> stateDefinitions,
        IReadOnlyDictionary<TState, TState> initiallyLastActiveStates,
        TState initialState)
    {
        this.stateDefinitions = stateDefinitions;
        this.initiallyLastActiveStates = initiallyLastActiveStates;
        this.initialState = initialState;
    }

    public PassiveStateMachine<TState, TEvent> CreatePassiveStateMachine()
    {
        var name = typeof(PassiveStateMachine<TState, TEvent>).FullNameToString();
        return CreatePassiveStateMachine(name);
    }

    public PassiveStateMachine<TState, TEvent> CreatePassiveStateMachine(string name)
    {
        var stateContainer = new StateContainer<TState, TEvent>(name);
        foreach (var stateIdAndLastActiveState in initiallyLastActiveStates)
            stateContainer.SetLastActiveStateFor(stateIdAndLastActiveState.Key, stateIdAndLastActiveState.Value);

        var transitionLogic = new TransitionLogic<TState, TEvent>(stateContainer);
        var stateLogic = new StateLogic<TState, TEvent>(transitionLogic, stateContainer);
        transitionLogic.SetStateLogic(stateLogic);

        var standardFactory = new StandardFactory<TState, TEvent>();
        var stateMachine = new StateMachine<TState, TEvent>(standardFactory, stateLogic);

        return new PassiveStateMachine<TState, TEvent>(stateMachine, stateContainer, stateDefinitions, initialState);
    }

    public ActiveStateMachine<TState, TEvent> CreateActiveStateMachine()
    {
        var name = typeof(ActiveStateMachine<TState, TEvent>).FullNameToString();
        return CreateActiveStateMachine(name);
    }

    public ActiveStateMachine<TState, TEvent> CreateActiveStateMachine(string name)
    {
        var stateContainer = new StateContainer<TState, TEvent>(name);
        foreach (var stateIdAndLastActiveState in initiallyLastActiveStates)
            stateContainer.SetLastActiveStateFor(stateIdAndLastActiveState.Key, stateIdAndLastActiveState.Value);

        var transitionLogic = new TransitionLogic<TState, TEvent>(stateContainer);
        var stateLogic = new StateLogic<TState, TEvent>(transitionLogic, stateContainer);
        transitionLogic.SetStateLogic(stateLogic);

        var standardFactory = new StandardFactory<TState, TEvent>();
        var stateMachine = new StateMachine<TState, TEvent>(standardFactory, stateLogic);

        return new ActiveStateMachine<TState, TEvent>(stateMachine, stateContainer, stateDefinitions, initialState);
    }
}