//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.States;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine;

public class
    ImplicitAddIfNotAvailableStateDefinitionDictionary<TState, TEvent> :
        IImplicitAddIfNotAvailableStateDefinitionDictionary<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    private readonly Dictionary<TState, StateDefinition<TState, TEvent>> dictionary = new();

    public IReadOnlyDictionary<TState, IStateDefinition<TState, TEvent>> ReadOnlyDictionary =>
        dictionary
            .ToDictionary(
                pair => pair.Key,
                pair => (IStateDefinition<TState, TEvent>)pair.Value);

    public StateDefinition<TState, TEvent> this[TState stateId]
    {
        get
        {
            if (!dictionary.ContainsKey(stateId)) dictionary.Add(stateId, new StateDefinition<TState, TEvent>(stateId));

            return dictionary[stateId];
        }
    }
}