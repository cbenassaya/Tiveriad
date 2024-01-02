//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.ActionHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.GuardHolders;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Models;

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