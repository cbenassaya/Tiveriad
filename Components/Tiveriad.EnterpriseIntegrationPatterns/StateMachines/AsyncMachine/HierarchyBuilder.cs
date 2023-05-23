//-------------------------------------------------------------------------------

#region

using Tiveriad.Commons.Guards;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.States;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncSyntax;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine;

public class HierarchyBuilder<TState, TEvent> :
    IHierarchySyntax<TState>,
    IInitialSubStateSyntax<TState>,
    ISubStateSyntax<TState>
    where TState : IComparable
    where TEvent : IComparable
{
    private readonly IDictionary<TState, TState> initiallyLastActiveStates;

    private readonly IImplicitAddIfNotAvailableStateDefinitionDictionary<TState, TEvent> stateDefinitions;
    private readonly StateDefinition<TState, TEvent> superState;

    public HierarchyBuilder(
        TState superStateId,
        IImplicitAddIfNotAvailableStateDefinitionDictionary<TState, TEvent> stateDefinitions,
        IDictionary<TState, TState> initiallyLastActiveStates)
    {
        NullGuard.AgainstNullArgument("states", stateDefinitions);

        this.stateDefinitions = stateDefinitions;
        this.initiallyLastActiveStates = initiallyLastActiveStates;
        superState = this.stateDefinitions[superStateId];
    }

    public IInitialSubStateSyntax<TState> WithHistoryType(HistoryType historyType)
    {
        superState.HistoryTypeModifiable = historyType;

        return this;
    }

    public ISubStateSyntax<TState> WithInitialSubState(TState stateId)
    {
        WithSubState(stateId);

        superState.InitialStateModifiable = stateDefinitions[stateId];
        initiallyLastActiveStates.Add(superState.Id, stateId);

        return this;
    }

    public ISubStateSyntax<TState> WithSubState(TState stateId)
    {
        var subState = stateDefinitions[stateId];

        CheckThatStateHasNotAlreadyASuperState(subState);

        subState.SuperStateModifiable = superState;
        superState.SubStatesModifiable.Add(subState);

        return this;
    }

    private void CheckThatStateHasNotAlreadyASuperState(StateDefinition<TState, TEvent> subState)
    {
        NullGuard.AgainstNullArgument("subState", subState);

        if (subState.SuperState != null)
            throw new InvalidOperationException(
                ExceptionMessages.CannotSetStateAsASuperStateBecauseASuperStateIsAlreadySet(
                    superState.Id,
                    subState));
    }
}