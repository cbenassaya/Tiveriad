//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.ActionHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.GuardHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.States;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.Transitions;

public interface ITransitionDefinition<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    IStateDefinition<TState, TEvent> Source { get; }

    IStateDefinition<TState, TEvent> Target { get; }

    IGuardHolder Guard { get; }

    IEnumerable<IActionHolder> Actions { get; }

    bool IsInternalTransition { get; }
}