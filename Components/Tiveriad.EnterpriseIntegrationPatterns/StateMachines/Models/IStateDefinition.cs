//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.ActionHolders;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Models;

public interface IStateDefinition<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    TState Id { get; }

    IReadOnlyDictionary<TEvent, IEnumerable<ITransitionDefinition<TState, TEvent>>> Transitions { get; }

    IEnumerable<TransitionInfo<TState, TEvent>> TransitionInfos { get; }

    int Level { get; }

    IStateDefinition<TState, TEvent> InitialState { get; }

    HistoryType HistoryType { get; }

    IStateDefinition<TState, TEvent> SuperState { get; }

    IEnumerable<IStateDefinition<TState, TEvent>> SubStates { get; }

    IEnumerable<IActionHolder> EntryActions { get; }

    IEnumerable<IActionHolder> ExitActions { get; }
}