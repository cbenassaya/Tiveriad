//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.States;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine;

public interface IStateDefinitionDictionary<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    IStateDefinition<TState, TEvent> this[TState key] { get; }

    IEnumerable<IStateDefinition<TState, TEvent>> Values { get; }
}