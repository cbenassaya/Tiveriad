//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.States;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine;

/// <summary>
///     Responsible for entering the initial state of the state machine.
///     All states up in the hierarchy are entered, too.
/// </summary>
/// <typeparam name="TState">The type of the state.</typeparam>
/// <typeparam name="TEvent">The type of the event.</typeparam>
public class StateMachineInitializer<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    private readonly ITransitionContext<TState, TEvent> context;
    private readonly IStateDefinition<TState, TEvent> initialState;

    public StateMachineInitializer(
        IStateDefinition<TState, TEvent> initialState,
        ITransitionContext<TState, TEvent> context)
    {
        this.initialState = initialState;
        this.context = context;
    }

    public TState EnterInitialState(
        IStateLogic<TState, TEvent> stateLogic,
        ILastActiveStateModifier<TState> lastActiveStateModifier,
        IStateDefinitionDictionary<TState, TEvent> stateDefinitions)
    {
        var stack = TraverseUpTheStateHierarchy();
        TraverseDownTheStateHierarchyAndEnterStates(stateLogic, stack);

        return stateLogic.EnterByHistory(initialState, context, lastActiveStateModifier, stateDefinitions);
    }

    /// <summary>
    ///     Traverses up the state hierarchy and build the stack of states.
    /// </summary>
    /// <returns>The stack containing all states up the state hierarchy.</returns>
    private Stack<IStateDefinition<TState, TEvent>> TraverseUpTheStateHierarchy()
    {
        var stack = new Stack<IStateDefinition<TState, TEvent>>();

        var state = initialState;
        while (state != null)
        {
            stack.Push(state);
            state = state.SuperState;
        }

        return stack;
    }

    private void TraverseDownTheStateHierarchyAndEnterStates(
        IStateLogic<TState, TEvent> stateLogic,
        Stack<IStateDefinition<TState, TEvent>> stack)
    {
        while (stack.Count > 0)
        {
            var state = stack.Pop();
            stateLogic.Entry(state, context);
        }
    }
}