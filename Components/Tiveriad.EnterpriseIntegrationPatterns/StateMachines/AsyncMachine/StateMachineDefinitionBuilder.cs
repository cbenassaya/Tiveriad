//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncSyntax;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine;

public class StateMachineDefinitionBuilder<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    private readonly StandardFactory<TState, TEvent> factory = new();
    private readonly Dictionary<TState, TState> initiallyLastActiveStates = new();

    private readonly ImplicitAddIfNotAvailableStateDefinitionDictionary<TState, TEvent> stateDefinitionDictionary =
        new();

    private TState initialState;
    private bool isInitialStateConfigured;

    public IEntryActionSyntax<TState, TEvent> In(TState state)
    {
        return new StateBuilder<TState, TEvent>(state, stateDefinitionDictionary, factory);
    }

    public IHierarchySyntax<TState> DefineHierarchyOn(TState superStateId)
    {
        return new HierarchyBuilder<TState, TEvent>(superStateId, stateDefinitionDictionary, initiallyLastActiveStates);
    }

    public StateMachineDefinitionBuilder<TState, TEvent> WithInitialState(TState initialStateToUse)
    {
        initialState = initialStateToUse;
        isInitialStateConfigured = true;
        return this;
    }

    public StateMachineDefinition<TState, TEvent> Build()
    {
        if (!isInitialStateConfigured) throw new InvalidOperationException(ExceptionMessages.InitialStateNotConfigured);

        var stateDefinitions =
            new StateDefinitionDictionary<TState, TEvent>(stateDefinitionDictionary.ReadOnlyDictionary);
        return new StateMachineDefinition<TState, TEvent>(stateDefinitions, initiallyLastActiveStates, initialState);
    }
}