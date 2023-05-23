//-------------------------------------------------------------------------------

//-------------------------------------------------------------------------------

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.States;

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine
{
    public interface IStateDefinitionDictionary<TState, TEvent>
        where TState : IComparable
        where TEvent : IComparable
    {
        IStateDefinition<TState, TEvent> this[TState key] { get; }

        IEnumerable<IStateDefinition<TState, TEvent>> Values { get; }
    }
}